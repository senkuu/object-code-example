using System;
using NIRScore;
using NIRScore.data;

namespace NIRScli
{
  class MainClass
  {

    public static void WriteRawLine(Line line)
    {
      Console.Write(Convert.ToString(line.sampleNumber) + " ; ");

      Console.Write(Convert.ToString(line.set1.TSI) + " ; ");

      Console.Write(Convert.ToString(line.set1.HHb) + "/");
      Console.Write(Convert.ToString(line.set2.HHb) + "/");
      Console.Write(Convert.ToString(line.set3.HHb) + " ");

      Console.Write(Convert.ToString(line.set1.tHb) + "/");
      Console.Write(Convert.ToString(line.set2.tHb) + "/");
      Console.Write(Convert.ToString(line.set3.tHb) + " ; ");

      Console.Write(Convert.ToString(line.set1.O2Hb) + "/");
      Console.Write(Convert.ToString(line.set2.O2Hb) + "/");
      Console.Write(Convert.ToString(line.set3.O2Hb) + " ; ");

      Console.WriteLine("\"" + line.rawEvent + "\"");
    }

    public static void WriteComputedLine(Line line)
    {
      Console.Write(Convert.ToString(line.sampleNumber) + " ; ");

      WriteDataSet(line.Values);
      Console.Write(" ; ");

      Console.WriteLine("\"" + line.rawEvent + "\"");
    }

    public static void WriteDataSet(DataSet data)
    {
      Console.Write(data.TSI + " ; ");
      Console.Write(data.HHb + " / ");
      Console.Write(data.tHb + " / ");
      Console.Write(data.O2Hb);
    }

    public static void WriteDataSetLine(DataSet data, int linenumber)
    {
      Console.Write(Convert.ToString(linenumber) + " ; ");
      WriteDataSet(data);
      Console.WriteLine("");
    }

    public static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      const string filename = "../../../../data/5DLU/5DLU NHF (analysis).xlsx";
      //const string filename = "../../../../data/test/TENS2 BF.xlsx";

      Session s = new Session(filename);
      if (s.IsValidFile)
      {

        s.ParseEvents();
        s.SetTlim(195);

        Console.WriteLine("Tlim = " + Convert.ToString(s.Tlim));
        Console.WriteLine("Effective Tlim = " + Convert.ToString(s.TlimEff));

        Console.WriteLine("NbLines = " + Convert.ToString(s.Size));

        WriteRawLine(s.GetLine(0));
        WriteComputedLine(s.GetLine(0));
        //WriteRawLine(s.GetLine(-1));

        for (int i = 0; i < s.CountEvents; i++)
        {
          int idx = s.GetEventIndex(i);
          Line cur = s.GetLine(idx);
          Console.WriteLine("Event found at index " + Convert.ToString(idx) + " / " + cur.EventType);
        }

        Console.WriteLine("");
        Console.WriteLine("Start Index = " + Convert.ToString(s.StartIndex));

        s.ComputeBaseline();
        WriteComputedLine(s.GetLine(s.StartIndex));
        WriteDataSetLine(s.ValueBaseline, s.StartIndex);
        s.ComputeLim();
        WriteComputedLine(s.GetLine(s.TlimEffIndex));
        WriteDataSetLine(s.ValueLim, s.TlimEffIndex);
        Console.Write("Delta = ");
        WriteDataSetLine(s.DeltaLim, s.TlimEffIndex);
        Console.Write("Delta (%) = ");
        WriteDataSetLine(s.DeltaLimRelative, s.TlimEffIndex);

      }
      else
      {
        Console.WriteLine("Invalid file");
      }
    }
  }
}
