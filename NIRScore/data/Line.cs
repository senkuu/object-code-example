using System;
namespace NIRScore.data
{

  public class Line
  {
    public readonly int sampleNumber;

    public readonly DataSet set1;
    public readonly DataSet set2;
    public readonly DataSet set3;

    public readonly DataSet Values;

    public readonly string rawEvent;

    public Line(int sampleNumber, double TSI, double HHb1, double HHb2, double HHb3, double tHb1, double tHb2, double tHb3, double O2Hb1, double O2Hb2, double O2Hb3, string rawEvent)
    {
      this.sampleNumber = sampleNumber;

      set1 = new DataSet
      {
        TSI = TSI,
        HHb = HHb1,
        tHb = tHb1,
        O2Hb = O2Hb1,
      };

      set2 = new DataSet
      {
        TSI = TSI,
        HHb = HHb2,
        tHb = tHb2,
        O2Hb = O2Hb2
      };

      set3 = new DataSet
      {
        TSI = TSI,
        HHb = HHb3,
        tHb = tHb3,
        O2Hb = O2Hb3
      };

      Values = DataSet.Mean(set1, set2, set3);

      this.rawEvent = rawEvent.Trim();
    }

    public bool HasEvent
    {
      get
      {
        return rawEvent.Length > 0;
      }
    }

    public string EventType
    {
      get
      {
        if (HasEvent)
        {
          return rawEvent.Substring(0, 1);
        }
        return "";
      }
    }
  }
}
