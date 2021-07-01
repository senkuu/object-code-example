using System;
using System.Linq;
using Gtk;

using NIRScore.data;

public partial class MainWindow : Gtk.Window
{
  private ListStore FileListStore;

  private NIRScore.Sessions Sessions;
  private NIRScore.Session SelectedSession;

  private TreeIter SelectedFileIter;

  private bool isAnalyzeDone;

  public MainWindow() : base(Gtk.WindowType.Toplevel)
  {
    this.Sessions = new NIRScore.Sessions();
    this.isAnalyzeDone = false;
    Build();
    InitializeFileList();
    ResetFields();
  }

  private Tuple<double, double> GetMinutesAndSecondsFromSeconds(double seconds)
  {
    double minutes = Math.Floor(seconds / 60);
    double remainingSeconds = Math.Floor(seconds % 60);

    return new Tuple<double, double>(minutes, remainingSeconds);
  }

  private void InitializeFileList()
  {
    TreeViewColumn fileColumn = new TreeViewColumn();
    fileColumn.Title = "Fichiers";
    FileListView.AppendColumn(fileColumn);

    CellRendererText fileNameCell = new CellRendererText();
    fileColumn.PackStart(fileNameCell, true);
    fileColumn.AddAttribute(fileNameCell, "text", 0);

    FileListStore = new ListStore(typeof(string));
    FileListView.Model = FileListStore;
  }

  private void UpdateTree()
  {
    if (this.SelectedSession != null)
    {
      //Gtk.TreePath path = new Gtk.TreePath(SelectedSession.fileName);
      int index = Sessions.sessions.Count - 1;
      Gtk.TreePath path = new Gtk.TreePath(Convert.ToString(index));
      Console.WriteLine(path.ToString());
      FileListView.Selection.SelectPath(path);
      FileListView.Model.GetIter(out TreeIter iter, path);
      this.SelectedFileIter = iter;

      //FileListView.SetCursor(0);
    }
  }

  private void ResetFields()
  {
    OcclusionDelaySpinButton.Value = 0;
  }

  private void UpdateConfig()
  {
    if (this.SelectedSession != null)
    {
      UpdateUiTlimAndToccValues(SelectedSession.Tlim, SelectedSession.OcclusionDuration);
      UpdateUiSlopeWindowValue(SelectedSession.SlopeWindow);
      UpdateConfigLabel(SelectedSession.fileName);
      UpdateUiOcclusionDelayValue(SelectedSession.OcclusionDelay);
    }
  }

  private void UpdateResults()
  {
    if (this.SelectedSession != null)
    {
      // Il faudra mettre les bons types dans la fonction qui se situe dans ResultWidget.cs
      //TlimResults.UpdateUiWithValues(this.SelectedSession.DeltaLim, this.SelectedSession.DeltaLimRelative, this.SelectedSession.DeltaSlopeLim, this.SelectedSession.DeltaSlopeLimRelative, 420.69);
      //TisoResults.UpdateUiWithValues(this.SelectedSession.DeltaIso, this.SelectedSession.DeltaIsoRelative, this.SelectedSession.DeltaSlopeIso, this.SelectedSession.DeltaSlopeIsoRelative, 50.25, 13.54);
      TlimResults.UpdateUiWithSession(this.SelectedSession, "lim");
      TisoResults.UpdateUiWithSession(this.SelectedSession, "iso");
      UpdateUiTlimEff(this.SelectedSession.TlimEff, this.SelectedSession.Tlim);
    }
    UpdateUiTiso(Sessions.effectiveTiso, Sessions.trueTiso);
  }

  private void UpdateUiTlimAndToccValues(double tlim, double tocc)
  {
    Tuple<double, double> tlimValues = this.GetMinutesAndSecondsFromSeconds(tlim);

    TlimMinutesSpinButton.Value = tlimValues.Item1;
    TlimSecondsSpinButton.Value = tlimValues.Item2;

    Tuple<double, double> toccValues = this.GetMinutesAndSecondsFromSeconds(tocc);

    ToccMinutesSpinButton.Value = toccValues.Item1;
    ToccSecondsSpinButton.Value = toccValues.Item2;
  }

  private void UpdateUiSlopeWindowValue(int SlopeWindow)
  {
    SlopeWindowSpinButton.Value = SlopeWindow;
  }

  private void UpdateUiTiso(double effectiveTiso, double trueTiso)
  {
    TisoValueLabel.LabelProp = $"{effectiveTiso}s (réel : {trueTiso}s)";
  }

  private void UpdateUiOcclusionDelayValue(double OcclusionDelay)
  {
    OcclusionDelaySpinButton.Value = OcclusionDelay;
  }

  private void UpdateUiTlimEff(double effectiveTlim, double trueTlim)
  {
    TlimEffValueLabel.LabelProp = $"{effectiveTlim}s (réel : {trueTlim}s)";
  }

  private void UpdateConfigLabel(string label)
  {
    if (this.SelectedSession != null)
    {
      if (this.SelectedSession.IsValidFile)
      {
        FileNameLabel.LabelProp = label;
      }
      else
      {
        FileNameLabel.LabelProp = $"{label} <span foreground='red' weight='bold' font='14'>(Attention : le format du fichier est incorrect)</span>";
      }
    }
    else
    {
      FileNameLabel.LabelProp = label;
    }
  }

  protected void OnDeleteEvent(object sender, DeleteEventArgs a)
  {
    Application.Quit();
    a.RetVal = true;
  }

  protected void OnAddFileButtonClicked(object sender, EventArgs e)
  {
    NIRSapp.FileChooserWindow fileChooserWindow = new NIRSapp.FileChooserWindow();
    fileChooserWindow.FileChosed += OnFileAdded;
    fileChooserWindow.Show();
  }

  private void OnFileAdded(object sender, EventArgs e)
  {
    NIRSapp.FileChooserWindow fileChooserWindow = (NIRSapp.FileChooserWindow)sender;
    foreach (string filePath in fileChooserWindow.SelectedFiles)
    {
      string filename = NIRScore.Session.GetNameFromPath(filePath);
#if DEBUG
      Console.Write("Add file : " + filePath);
      Console.WriteLine(" (" + filename + ")");
#endif
      Sessions.AddSession(filePath);
      FileListStore.AppendValues(filename);
    }
    SelectedSession = Sessions.GetLastSession();
    UpdateConfig();
    UpdateTree();
    fileChooserWindow.Destroy();
  }

  protected void OnAnalyseButtonClicked(object sender, EventArgs e)
  {
    Sessions.ParseAllEvents();
    Sessions.Compute();

    this.isAnalyzeDone = true;

    UpdateResults();
    notebook1.NextPage();
  }

  protected void OnFileListViewCursorChanged(object sender, EventArgs e)
  {
    string selectedFileName = "";
    TreeSelection selection = (sender as TreeView).Selection;

    // Permet de savoir quel élément est séléctionné
    if (selection.GetSelected(out TreeModel model, out TreeIter iter))
    {
      this.SelectedFileIter = iter;
      selectedFileName = (string)model.GetValue(iter, 0);
    }
    else
    {
      return;
    }

    if (Sessions.sessions.Any())
    {
      // Récupere le File avec le nom correspondant
      this.SelectedSession = Sessions.sessions.Where(session => session.fileName == selectedFileName).ToList()[0];
    }
    else
    {
      this.SelectedSession = null;
    }

    UpdateConfig();

    if (isAnalyzeDone && notebook1.Page == 1)
    {
      UpdateResults();
    }
  }

  protected void OnDeleteFileButtonClicked(object sender, EventArgs e)
  {
    if (SelectedSession != null)
    {
      this.FileListStore.Remove(ref this.SelectedFileIter);
      this.Sessions.sessions.Remove(SelectedSession);
      SelectedSession = null;
      this.UpdateTree();
      UpdateConfigLabel("<span foreground='red' weight='bold' font='14'>Aucun fichier sélectionné</span>");
    }
  }

  protected void OnUpdateValueButtonClicked(object sender, EventArgs e)
  {
    if (SelectedSession != null)
    {
      SelectedSession.SetTlim(TlimMinutesSpinButton.Value * 60 + TlimSecondsSpinButton.Value);
      SelectedSession.SetOcclusionDuration(ToccMinutesSpinButton.Value * 60 + ToccSecondsSpinButton.Value);
      SelectedSession.OcclusionDelay = OcclusionDelaySpinButton.Value;
      SelectedSession.SlopeWindow = Convert.ToInt32(SlopeWindowSpinButton.Value);
    }
  }
}
