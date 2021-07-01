using System;
using System.Collections.Generic;
using NIRScore.excel;
using NIRScore.data;

namespace NIRScore
{
  public class Session
  {
    public readonly string filePath;
    public readonly string fileName;

    private readonly ExcelManager file;
    private readonly Line[] lines;
    private readonly List<int> events;

    private readonly List<Occlusion> occlusions;

    private double _occlusionDuration = 20.0;
    private double _occlusionDelay = 0.0;

    private double _tlim = 0.0;
    private int tlimIndex;
    private int tlimIndexEff;

    private double _ts = 1.0;

    private int startIndex = -1;

    private int _slopeWindow = 1;

    public Occlusion baselineOcclusion;
    public Occlusion lastLimOcclusion;
    public Occlusion lastIsoOcclusion;

    public DataSet ValueBaseline;
    public DataSet ValueLim;
    public DataSet ValueIso;

    public DataSet DeltaLim;
    public DataSet DeltaLimRelative;
    public DataSet DeltaIso;
    public DataSet DeltaIsoRelative;

    public DataSet DeltaSlopeLim;
    public DataSet DeltaSlopeLimRelative;
    public DataSet DeltaSlopeIso;
    public DataSet DeltaSlopeIsoRelative;

    public double Tlim
    {
      get
      {
        return _tlim;
      }

      set
      {
        if (value > 0)
        {
          _tlim = value;
          UpdateTlimIndex();
        }
        else
        {
          _tlim = 0;
        }
      }
    }

    public double TlimEff
    {
      get
      {
        return this.IndexToTime(this.tlimIndexEff);
      }
    }

    public int TlimIndex
    {
      get
      {
        return tlimIndex + StartIndex;
      }
    }

    public int TlimEffIndex
    {
      get
      {
        return tlimIndexEff + StartIndex;
      }
    }

    public int StartIndex
    {
      get
      {
        return startIndex;
      }
    }

    public int Size
    {
      get
      {
        return file.DataSize;
      }
    }

    public double Ts
    {
      get
      {
        return _ts;
      }

      set
      {
        if (value > 0)
        {
          _ts = value;
          UpdateTlimIndex();
        }
      }
    }

    public double OcclusionDuration
    {
      get
      {
        return _occlusionDuration;
      }

      set
      {
        if (value > 0)
        {
          _occlusionDuration = value;
        }
      }
    }

    public int CountEvents
    {
      get
      {
        return events.Count;
      }
    }

    public bool HasOcclusions
    {
      get
      {
        return occlusions.Count > 0;
      }
    }

    public int SlopeWindow
    {
      get
      {
        return _slopeWindow;
      }

      set
      {
        if (value >= 0)
        {
          _slopeWindow = value;
#if DEBUG
          Console.Write("New slope window = ");
          Console.WriteLine(_slopeWindow);
#endif
          UpdateOcclusionsSlope();
        }
      }
    }

    public double OcclusionDelay
    {
      get
      {
        return _occlusionDelay;
      }

      set
      {
          _occlusionDelay = value;
#if DEBUG
          Console.Write("New occlusion delay = ");
          Console.WriteLine(_occlusionDelay);
#endif
          UpdateOcclusionsSlope();
      }
    }

    private bool _validFile = false;

    public bool IsValidFile
    {
      get
      {
        return _validFile;
      }
    }

    public Session SetOcclusionDuration(double duration)
    {
      OcclusionDuration = duration;
      return this;
    }

    public Session SetTlim(double time)
    {
      Tlim = time;
      return this;
    }

    public Session SetSampleRate(double samplerate)
    {
      if (samplerate > 0)
      {
        Ts = 1.0 / samplerate;
      }
      return this;
    }

    public Session SetParameters(double tlim, double occlusionDuration = 20.0, double samplerate = 1.0)
    {
      return SetTlim(tlim).SetOcclusionDuration(occlusionDuration).SetSampleRate(samplerate);
    }

    public int GetEventIndex(int index)
    {
      return events[index];
    }

    public Line GetLine(int index)
    {
      if (index < 0)
      {
        index += Size;
      }
      return lines[index];
    }

    public bool InOcclusion(int index)
    {
      bool ret = false;
      foreach (Occlusion occlusion in occlusions)
      {
        if (occlusion.IsInside(index))
        {
          return true;
        }
      }
      return ret;
    }

    public bool InOcclusion(double time)
    {
      return InOcclusion(TimeToIndex(time));
    }

    // helper functions

    private void UpdateTlimIndex()
    {
      tlimIndex = (int)Math.Round(Tlim / Ts);
      tlimIndexEff = this.IndexBeforeOcclusion(TlimIndex) - StartIndex;
    }

    private void UpdateOcclusionsSlope()
    {
#if DEBUG
      Console.WriteLine("[UpdateOcclusionSlope]");
#endif
      foreach (Occlusion occlusion in occlusions)
      {
        occlusion.ComputeSlope();
      }
    }

    private int TimeToIndex(double time)
    {
      return (int)Math.Round(time / Ts);
    }

    private double IndexToTime(int index)
    {
      return Ts * index;
    }

    // Constructor
    public Session(string filePath)
    {
      events = new List<int>();
      occlusions = new List<Occlusion>();

      this.filePath = filePath;
      this.fileName = Session.GetNameFromPath(filePath);
      file = new ExcelManager(filePath, 52);
      lines = new Line[Size];

      bool t1 = file.TestCellAbsolute(12, 51, 13); // Teste la présence de la valeur 13 dans la cellule M52
      bool t2 = file.TestCellAbsolute(0, 51, 1); // Teste la présence de la valeur 1 dans la cellule A52
      bool t3 = file.TestCellAbsolute(0, 48, 13); // Teste la présence de la valeur 13 dans la cellule A49
      bool t4 = file.TestCellAbsolute(2, 4, "Hz"); // Teste la précence de la valeur "Hz" dans la cellule C5

      bool validFile = t1 && t2 && t3 && t4;

      if (!validFile)
      {
        _validFile = false;
      }
      else
      {
        _validFile = true;
        double rate = 1.0;
        if (file.IsNumericCellAbsolute(1,4)){
          rate = file.NumericCellValueAbsolute(1, 4);
        }
        else if (file.IsStringCellAbsolute(1,4)) {
          string srate = file.StringCellValueAbsolute(1,4);
          try {
            rate = double.Parse(srate, System.Globalization.CultureInfo.InvariantCulture);
          }
          catch (Exception e) {
#if DEBUG
            Console.WriteLine(e);
            Console.WriteLine("Unable to convert string rate to double : '" + srate + "'");
#endif
          }
        }
        
#if DEBUG
        Console.WriteLine("Sample Rate = " + Convert.ToString(rate));
#endif
        SetSampleRate(rate);
        ReadFile();
      }
    }

    public static string GetNameFromPath(string path)
    {
      string[] dividedPath;

      if (System.Environment.OSVersion.Platform == PlatformID.Unix)
      {
        dividedPath = path.Split('/');
      } else
      {
        dividedPath = path.Split('\\');
      }
      return dividedPath[dividedPath.Length - 1];
    }

    public void ReadFile()
    {
      if (!IsValidFile)
      {
        return;
      }

#if DEBUG
      Console.WriteLine("Read File call");
#endif  

      events.Clear();
      for (int i = 0; i < file.DataSize; i++)
      {
        double TSI;
        double HHb1;
        double HHb2;
        double HHb3;
        double tHb1;
        double tHb2;
        double tHb3;
        double O2Hb1;
        double O2Hb2;
        double O2Hb3;

        file.TryCellValueAsNumeric(1, i, out TSI);

        
        file.TryCellValueAsNumeric(4,i, out HHb1);
        file.TryCellValueAsNumeric(7,i, out HHb2);
        file.TryCellValueAsNumeric(10,i, out HHb3);

        file.TryCellValueAsNumeric(5,i, out tHb1);
        file.TryCellValueAsNumeric(8,i, out tHb2);
        file.TryCellValueAsNumeric(11,i, out tHb3);

        file.TryCellValueAsNumeric(3,i, out O2Hb1);
        file.TryCellValueAsNumeric(6,i, out O2Hb2);
        file.TryCellValueAsNumeric(9,i, out O2Hb3);
        /*
        TSI = file.NumericCellValue(1, i);
        
        HHb1 = file.NumericCellValue(4, i);
        HHb2 = file.NumericCellValue(7, i);
        HHb3 = file.NumericCellValue(10, i);
        
        tHb1 = file.NumericCellValue(5, i);
        tHb2 = file.NumericCellValue(8, i);
        tHb3 = file.NumericCellValue(11, i);
        
        O2Hb1 = file.NumericCellValue(3, i);
        O2Hb2 = file.NumericCellValue(6, i);
        O2Hb3 = file.NumericCellValue(9, i);
        */

        string rawEvent = file.StringCellValue(12, i);

        Line tmp = new Line(i, TSI, HHb1, HHb2, HHb3, tHb1, tHb2, tHb3, O2Hb1, O2Hb2, O2Hb3, rawEvent);
        if (tmp.HasEvent)
        {
          events.Add(i);
        }
        lines[i] = tmp;
      }
    }

    public void ParseEvents()
    {
      if (!IsValidFile)
      {
        return;
      }

      occlusions.Clear();
      baselineOcclusion = null;
      lastLimOcclusion = null;
      lastIsoOcclusion = null;
      startIndex = -1;

      foreach (int eventIdx in events)
      {
        Line line = lines[eventIdx];
        if (!line.HasEvent)
        {
          Console.WriteLine("Error: no event at line " + Convert.ToString(eventIdx));
          continue;
        }
        if (line.EventType == "A" && startIndex < 0)
        {
          startIndex = eventIdx;
#if DEBUG
          Console.WriteLine("Event A " + eventIdx);
#endif
        }
        if (line.EventType == "B")
        {

#if DEBUG
          Console.WriteLine("Event B " + eventIdx);
#endif
          int endIndex = eventIdx + TimeToIndex(OcclusionDuration) - 1;

          Occlusion occlusion = new Occlusion(this, eventIdx, endIndex);
          if (startIndex < 0)
          {
            baselineOcclusion = occlusion;
          }
          occlusions.Add(occlusion);
        }
      }

      UpdateTlimIndex();  // To update TlimEff if there is some occlusion
    }

    // public analysis functions
    public DataSet ValuesAt(int index)
    {
      return lines[index].Values;
    }

    public DataSet Mean(int startIndex, int endIndex)
    {
#if DEBUG
      Console.WriteLine("\tMean call (" + Convert.ToString(startIndex) + " to " + Convert.ToString(endIndex) + ")");
#endif

      int qty = 0;

      DataSet ret = new DataSet
      {
        TSI = 0.0,
        HHb = 0.0,
        tHb = 0.0,
        O2Hb = 0.0
      };

      if (!IsValidFile)
      {
        return ret;
      }

      for (int i = startIndex; i <= endIndex; i++)
      {
        if (i < 0)
        {
          continue;
        }
        if (i >= Size)
        {
          break;
        }
        qty += 1;

        ret = DataSet.Add(ret, ValuesAt(i));
      }

#if DEBUG
      Console.WriteLine("\t\twith qty = " + Convert.ToString(qty));
#endif 

      return DataSet.Div(ret, qty);
    }

    public void ComputeBaseline()
    {
      if (!IsValidFile)
      {
        return;
      }

      int duration = TimeToIndex(30.0);
#if DEBUG
      Console.WriteLine("[ComputeBaseline] " + Convert.ToString(startIndex));
#endif
      ValueBaseline = Mean(startIndex - duration + 1, startIndex);
    }

    public void ComputeLim()
    {
      if (!IsValidFile)
      {
        return;
      }

      int duration = TimeToIndex(10.0);
#if DEBUG
      Console.WriteLine("[ComputeLim] " + Convert.ToString(TlimEffIndex));
#endif
      ValueLim = Mean(TlimEffIndex - duration + 1, TlimEffIndex);
      DeltaLim = DataSet.Sub(ValueLim, ValueBaseline);
      DeltaLimRelative = DataSet.Div(DeltaLim, ValueBaseline);
    }

    public void ComputeSlopeLim()
    {
      if (!IsValidFile)
      {
        return;
      }

#if DEBUG
      Console.Write("[ComputeSlopeLim] ");
      Console.WriteLine(TlimEffIndex + StartIndex);
#endif
      Occlusion last = GetLastOcclusionBefore(TlimEff);
      this.lastLimOcclusion = last;

      if (last == null)
      {
        return;
      }

      if (baselineOcclusion == null)
      {
        return;
      }

#if DEBUG
      Console.Write("\tRetained last : ");
      Console.Write(last.beginIndex);
      Console.Write(" - ");
      Console.WriteLine(last.endIndex);
#endif

      DataSet V0 = baselineOcclusion.Slope;
      DataSet V1 = last.Slope;
      DeltaSlopeLim = DataSet.Sub(V1, V0);
      DeltaSlopeLimRelative = DataSet.Div(DeltaSlopeLim, V0);
    }

    public int GetIsoIndex(double tiso)
    {
      return TimeToIndex(tiso) + StartIndex;
    }

    public void ComputeIso(double tiso)
    {
      if (!IsValidFile)
      {
        return;
      }

      int isoIndex = GetIsoIndex(tiso);
      int duration = TimeToIndex(10.0);
#if DEBUG
      Console.WriteLine("[ComputeIso] " + Convert.ToString(isoIndex));
#endif
      ValueIso = Mean(isoIndex - duration + 1, isoIndex);
      DeltaIso = DataSet.Sub(ValueIso, ValueBaseline);
      DeltaIsoRelative = DataSet.Div(DeltaIso, ValueBaseline);
    }

    public void ComputeSlopeIso(double tiso)
    {
      if (!IsValidFile)
      {
        return;
      }

      int isoIndex = TimeToIndex(tiso);
#if DEBUG
      Console.WriteLine("[ComputeIsoSlope] " + Convert.ToString(isoIndex));
#endif
      Occlusion last = GetLastOcclusionBefore(tiso);
      this.lastIsoOcclusion = last;

      if (last == null)
      {
        return;
      }

      if (baselineOcclusion == null)
      {
        return;
      }

      DataSet V0 = baselineOcclusion.Slope;
      DataSet V1 = last.Slope;
      DeltaSlopeIso = DataSet.Sub(V1, V0);
      DeltaSlopeIsoRelative = DataSet.Div(DeltaSlopeIso, V0);
    }

    public int IndexBeforeOcclusion(int index)
    {
      int ret = index;
      foreach (Occlusion occlusion in occlusions)
      {
        if (occlusion.IsInside(index))
        {
          Console.Write("Inside occlusion ");
          Console.WriteLine(occlusion.beginIndex);
          return occlusion.beginIndex - 1;
        }
      }
      return ret;
    }

    public int IndexBeforeOcclusion(double time)
    {
      return IndexBeforeOcclusion(TimeToIndex(time));
    }

    public double TimeBeforeOcclusion(int index)
    {
      return IndexToTime(IndexBeforeOcclusion(index));
    }

    public double TimeBeforeOcclusion(double time)
    {
      return IndexToTime(IndexBeforeOcclusion(time));
    }

    public Occlusion GetLastOcclusionBefore(int index)
    {
      Occlusion curr = null;
#if DEBUG
      Console.Write("[GetLastOcclusionBefore/index] ");
      Console.WriteLine(index);
#endif
      foreach (Occlusion occlusion in occlusions)
      {
#if DEBUG
        Console.Write("\tocclusion ");
        Console.WriteLine(occlusion.endIndex);
#endif
        if (occlusion.endIndex > index)
        {
          break;
        }
        curr = occlusion;
      }
      return curr;
    }

    public Occlusion GetLastOcclusionBefore(double time)
    {
      int index = TimeToIndex(time);
      index += StartIndex;
      return GetLastOcclusionBefore(index);
    }
  }
}
