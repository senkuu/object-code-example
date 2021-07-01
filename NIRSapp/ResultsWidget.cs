using System;
using Gtk;

using NIRScore.data;
using NIRScore;

namespace NIRSapp
{
  [System.ComponentModel.ToolboxItem(true)]
  public partial class ResultsWidget : Gtk.Bin
  {
    public ResultsWidget()
    {
      this.Build();
    }

    public string ResultsLabel
    {
      get { return GtkResultsLabel.Text; }
      set { GtkResultsLabel.Text = value; }
    }

    public void UpdateUiWithValues(DataSet Values, DataSet RelativeValues, DataSet Slope, DataSet SlopeRel, Occlusion Baseline, Occlusion End)
    {
      TsiValueLabel.Text = $"{Math.Round(Values.TSI, 6)} ({Math.Round(RelativeValues.TSI * 100, 6)}%)";
      HHbValueLabel.Text = $"{Math.Round(Values.HHb, 6)} ({Math.Round(RelativeValues.HHb * 100, 6)}%)";
      ThbValueLabel.Text = $"{Math.Round(Values.tHb, 6)} ({Math.Round(RelativeValues.tHb * 100, 6)}%)";
      // le build d'interface bug avec le O majuscule, du coup je l'ai mis en minuscule
      ohbValueLabel.Text = $"{Math.Round(Values.O2Hb, 6)} ({Math.Round(RelativeValues.O2Hb * 100, 6)}%)";

      if (Baseline != null)
      {
        PenteBaselineValueLabel.Text = $"{Math.Round(Baseline.Slope.tHb, 6)}";
      }
      else
      {
        PenteBaselineValueLabel.Text = "";
      }

      if (End != null)
      {
        PenteFinValueLabel.Text = $"{Math.Round(End.Slope.tHb, 6)}";
      }
      else
      {
        PenteFinValueLabel.Text = "";
      }

      PenteValueLabel.Text = $"{Convert.ToString(Math.Round(Slope.tHb, 6))} ({Math.Round(SlopeRel.tHb, 6)}%)";
    }

    public void UpdateUiWithSession(Session session, string type)
    {
      DataSet Values;
      DataSet RelValues;
      DataSet Slope;
      DataSet RelSlope;
      Occlusion Baseline = session.baselineOcclusion;
      Occlusion End;

      if (type == "iso")
      {
        Values = session.DeltaIso;
        RelValues = session.DeltaIsoRelative;
        Slope = session.DeltaSlopeIso;
        RelSlope = session.DeltaSlopeIsoRelative;
        End = session.lastIsoOcclusion;
      }
      else {
        Values = session.DeltaLim;
        RelValues = session.DeltaLimRelative;
        Slope = session.DeltaSlopeLim;
        RelSlope = session.DeltaSlopeLimRelative;
        End = session.lastLimOcclusion;
      }

      this.UpdateUiWithValues(
        Values,
        RelValues,
        Slope,
        RelSlope,
        Baseline,
        End
      );
    }
  }
}
