using System;
namespace NIRScore.data
{
  public class Occlusion
  {
    public readonly int beginIndex;
    public readonly int endIndex;

    private Session parent;

    private DataSet _slope;
    private bool isSlopeComputed = false;


    public DataSet ComputeSlope()
    {
      DataSet V0;
      DataSet V1;

      double delay = parent.OcclusionDelay;

      int idelay = (int)Math.Round(delay / parent.Ts);

      int trueBeginIndex = beginIndex + idelay;
      int trueEndIndex = endIndex + idelay;

      if (parent.SlopeWindow == 0)
      {
        V0 = parent.ValuesAt(trueBeginIndex);
        V1 = parent.ValuesAt(trueEndIndex);
      }
      else
      {
        int SlopeWindowIndex = (int)Math.Round(parent.SlopeWindow / parent.Ts);
#if DEBUG
        Console.Write("[ComputeSlope/mean] ");
        Console.WriteLine(SlopeWindowIndex);
#endif
        V0 = parent.Mean(trueBeginIndex - SlopeWindowIndex, trueBeginIndex + SlopeWindowIndex);
        V1 = parent.Mean(trueEndIndex - SlopeWindowIndex, trueEndIndex + SlopeWindowIndex);
      }

      _slope = DataSet.SubDiv(V1, V0, parent.OcclusionDuration);
      isSlopeComputed = true;

#if DEBUG
      Console.Write("[ComputeSlope/value] ");
      Console.WriteLine(_slope.tHb);
#endif

      return _slope;
    }

    public DataSet Slope
    {
      get
      {
        if (isSlopeComputed)
        {
          return _slope;
        }
        return ComputeSlope();
      }
    }

    public Occlusion(Session parent, int beginIndex, int endIndex)
    {
      this.parent = parent;
      this.beginIndex = beginIndex;
      this.endIndex = endIndex;
    }

    public bool IsInside(int index)
    {
      if (index >= beginIndex && index < endIndex)
      {
        return true;
      }
      return false;
    }


  }
}
