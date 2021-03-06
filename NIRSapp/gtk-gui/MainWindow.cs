
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.HBox hbox1;

	private global::Gtk.VBox vbox1;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView FileListView;

	private global::Gtk.Button AddFileButton;

	private global::Gtk.VBox vbox7;

	private global::Gtk.Notebook notebook1;

	private global::Gtk.VBox vbox2;

	private global::Gtk.VBox vbox3;

	private global::Gtk.Label FileNameLabel;

	private global::Gtk.HBox hbox2;

	private global::Gtk.Label TlimLabel;

	private global::Gtk.SpinButton TlimMinutesSpinButton;

	private global::Gtk.HBox hbox14;

	private global::Gtk.SpinButton TlimSecondsSpinButton;

	private global::Gtk.Label label14;

	private global::Gtk.Label label13;

	private global::Gtk.HBox hbox3;

	private global::Gtk.Label ToccLabel;

	private global::Gtk.SpinButton ToccMinutesSpinButton;

	private global::Gtk.HBox hbox15;

	private global::Gtk.SpinButton ToccSecondsSpinButton;

	private global::Gtk.Label label16;

	private global::Gtk.Label label15;

	private global::Gtk.HBox hbox4;

	private global::Gtk.Label OcclusionDelayLabel;

	private global::Gtk.SpinButton OcclusionDelaySpinButton;

	private global::Gtk.Label label24;

	private global::Gtk.HBox hbox10;

	private global::Gtk.Label SlopeWindowLabel;

	private global::Gtk.SpinButton SlopeWindowSpinButton;

	private global::Gtk.Label label19;

	private global::Gtk.VBox vbox12;

	private global::Gtk.Label UpdateAlertLabel;

	private global::Gtk.Button UpdateValueButton;

	private global::Gtk.Button DeleteFileButton;

	private global::Gtk.Label label1;

	private global::Gtk.VBox vbox5;

	private global::NIRSapp.ResultsWidget TlimResults;

	private global::NIRSapp.ResultsWidget TisoResults;

	private global::Gtk.HBox hbox11;

	private global::Gtk.VBox vbox17;

	private global::Gtk.Label label21;

	private global::Gtk.Label label22;

	private global::Gtk.VBox vbox18;

	private global::Gtk.Label TlimEffValueLabel;

	private global::Gtk.Label TisoValueLabel;

	private global::Gtk.Label label23;

	private global::Gtk.Button analyseButton;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("NIRS");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		// Container child hbox1.Gtk.Box+BoxChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.FileListView = new global::Gtk.TreeView();
		this.FileListView.CanFocus = true;
		this.FileListView.Name = "FileListView";
		this.GtkScrolledWindow.Add(this.FileListView);
		this.vbox1.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
		w2.Position = 0;
		w2.Padding = ((uint)(15));
		// Container child vbox1.Gtk.Box+BoxChild
		this.AddFileButton = new global::Gtk.Button();
		this.AddFileButton.CanFocus = true;
		this.AddFileButton.Name = "AddFileButton";
		this.AddFileButton.UseUnderline = true;
		this.AddFileButton.Label = global::Mono.Unix.Catalog.GetString("Ajouter un fichier");
		global::Gtk.Image w3 = new global::Gtk.Image();
		w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-directory", global::Gtk.IconSize.Menu);
		this.AddFileButton.Image = w3;
		this.vbox1.Add(this.AddFileButton);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.AddFileButton]));
		w4.PackType = ((global::Gtk.PackType)(1));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		w4.Padding = ((uint)(15));
		this.hbox1.Add(this.vbox1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox1]));
		w5.Position = 0;
		w5.Padding = ((uint)(15));
		// Container child hbox1.Gtk.Box+BoxChild
		this.vbox7 = new global::Gtk.VBox();
		this.vbox7.Name = "vbox7";
		this.vbox7.Spacing = 6;
		// Container child vbox7.Gtk.Box+BoxChild
		this.notebook1 = new global::Gtk.Notebook();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 0;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox2 = new global::Gtk.VBox();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.FileNameLabel = new global::Gtk.Label();
		this.FileNameLabel.Name = "FileNameLabel";
		this.FileNameLabel.LabelProp = global::Mono.Unix.Catalog.GetString("<span foreground=\'red\' weight=\'bold\' font=\'14\'>Aucun fichier s??lectionn??</span>");
		this.FileNameLabel.UseMarkup = true;
		this.vbox3.Add(this.FileNameLabel);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.FileNameLabel]));
		w6.Position = 0;
		w6.Expand = false;
		w6.Fill = false;
		w6.Padding = ((uint)(15));
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.TlimLabel = new global::Gtk.Label();
		this.TlimLabel.Name = "TlimLabel";
		this.TlimLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Tlim");
		this.TlimLabel.Justify = ((global::Gtk.Justification)(3));
		this.hbox2.Add(this.TlimLabel);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.TlimLabel]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		w7.Padding = ((uint)(15));
		// Container child hbox2.Gtk.Box+BoxChild
		this.TlimMinutesSpinButton = new global::Gtk.SpinButton(0D, 1000D, 1D);
		this.TlimMinutesSpinButton.CanFocus = true;
		this.TlimMinutesSpinButton.Name = "TlimMinutesSpinButton";
		this.TlimMinutesSpinButton.Adjustment.PageIncrement = 10D;
		this.TlimMinutesSpinButton.ClimbRate = 0.1D;
		this.TlimMinutesSpinButton.Numeric = true;
		this.hbox2.Add(this.TlimMinutesSpinButton);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.TlimMinutesSpinButton]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.hbox14 = new global::Gtk.HBox();
		this.hbox14.Name = "hbox14";
		this.hbox14.Spacing = 6;
		// Container child hbox14.Gtk.Box+BoxChild
		this.TlimSecondsSpinButton = new global::Gtk.SpinButton(0D, 59D, 1D);
		this.TlimSecondsSpinButton.CanFocus = true;
		this.TlimSecondsSpinButton.Name = "TlimSecondsSpinButton";
		this.TlimSecondsSpinButton.Adjustment.PageIncrement = 10D;
		this.TlimSecondsSpinButton.ClimbRate = 1D;
		this.TlimSecondsSpinButton.Numeric = true;
		this.hbox14.Add(this.TlimSecondsSpinButton);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.TlimSecondsSpinButton]));
		w9.Position = 0;
		w9.Expand = false;
		w9.Fill = false;
		// Container child hbox14.Gtk.Box+BoxChild
		this.label14 = new global::Gtk.Label();
		this.label14.Name = "label14";
		this.label14.LabelProp = global::Mono.Unix.Catalog.GetString("s");
		this.hbox14.Add(this.label14);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.label14]));
		w10.Position = 1;
		w10.Expand = false;
		w10.Fill = false;
		this.hbox2.Add(this.hbox14);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.hbox14]));
		w11.PackType = ((global::Gtk.PackType)(1));
		w11.Position = 2;
		// Container child hbox2.Gtk.Box+BoxChild
		this.label13 = new global::Gtk.Label();
		this.label13.Name = "label13";
		this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("min");
		this.hbox2.Add(this.label13);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label13]));
		w12.PackType = ((global::Gtk.PackType)(1));
		w12.Position = 3;
		w12.Expand = false;
		w12.Fill = false;
		this.vbox3.Add(this.hbox2);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox2]));
		w13.Position = 1;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.ToccLabel = new global::Gtk.Label();
		this.ToccLabel.Name = "ToccLabel";
		this.ToccLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Tocc");
		this.hbox3.Add(this.ToccLabel);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.ToccLabel]));
		w14.Position = 0;
		w14.Expand = false;
		w14.Fill = false;
		w14.Padding = ((uint)(15));
		// Container child hbox3.Gtk.Box+BoxChild
		this.ToccMinutesSpinButton = new global::Gtk.SpinButton(0D, 1000D, 1D);
		this.ToccMinutesSpinButton.CanFocus = true;
		this.ToccMinutesSpinButton.Name = "ToccMinutesSpinButton";
		this.ToccMinutesSpinButton.Adjustment.PageIncrement = 10D;
		this.ToccMinutesSpinButton.ClimbRate = 0.1D;
		this.ToccMinutesSpinButton.Numeric = true;
		this.hbox3.Add(this.ToccMinutesSpinButton);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.ToccMinutesSpinButton]));
		w15.Position = 1;
		w15.Expand = false;
		w15.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.hbox15 = new global::Gtk.HBox();
		this.hbox15.Name = "hbox15";
		this.hbox15.Spacing = 6;
		// Container child hbox15.Gtk.Box+BoxChild
		this.ToccSecondsSpinButton = new global::Gtk.SpinButton(0D, 59D, 1D);
		this.ToccSecondsSpinButton.CanFocus = true;
		this.ToccSecondsSpinButton.Name = "ToccSecondsSpinButton";
		this.ToccSecondsSpinButton.Adjustment.PageIncrement = 10D;
		this.ToccSecondsSpinButton.ClimbRate = 1D;
		this.ToccSecondsSpinButton.Numeric = true;
		this.hbox15.Add(this.ToccSecondsSpinButton);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.ToccSecondsSpinButton]));
		w16.Position = 0;
		w16.Expand = false;
		w16.Fill = false;
		// Container child hbox15.Gtk.Box+BoxChild
		this.label16 = new global::Gtk.Label();
		this.label16.Name = "label16";
		this.label16.LabelProp = global::Mono.Unix.Catalog.GetString("s");
		this.label16.UseMarkup = true;
		this.hbox15.Add(this.label16);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.label16]));
		w17.Position = 1;
		w17.Expand = false;
		w17.Fill = false;
		this.hbox3.Add(this.hbox15);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.hbox15]));
		w18.PackType = ((global::Gtk.PackType)(1));
		w18.Position = 2;
		// Container child hbox3.Gtk.Box+BoxChild
		this.label15 = new global::Gtk.Label();
		this.label15.Name = "label15";
		this.label15.Xalign = 0F;
		this.label15.LabelProp = global::Mono.Unix.Catalog.GetString("min");
		this.hbox3.Add(this.label15);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label15]));
		w19.PackType = ((global::Gtk.PackType)(1));
		w19.Position = 3;
		w19.Expand = false;
		w19.Fill = false;
		this.vbox3.Add(this.hbox3);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox3]));
		w20.Position = 2;
		w20.Expand = false;
		w20.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.OcclusionDelayLabel = new global::Gtk.Label();
		this.OcclusionDelayLabel.Name = "OcclusionDelayLabel";
		this.OcclusionDelayLabel.LabelProp = global::Mono.Unix.Catalog.GetString("D??lai avant l\'occlusion :");
		this.hbox4.Add(this.OcclusionDelayLabel);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.OcclusionDelayLabel]));
		w21.Position = 0;
		w21.Expand = false;
		w21.Fill = false;
		w21.Padding = ((uint)(15));
		// Container child hbox4.Gtk.Box+BoxChild
		this.OcclusionDelaySpinButton = new global::Gtk.SpinButton(-500D, 500D, 1D);
		this.OcclusionDelaySpinButton.CanFocus = true;
		this.OcclusionDelaySpinButton.Name = "OcclusionDelaySpinButton";
		this.OcclusionDelaySpinButton.Adjustment.PageIncrement = 10D;
		this.OcclusionDelaySpinButton.ClimbRate = 1D;
		this.OcclusionDelaySpinButton.Digits = ((uint)(2));
		this.OcclusionDelaySpinButton.Numeric = true;
		this.hbox4.Add(this.OcclusionDelaySpinButton);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.OcclusionDelaySpinButton]));
		w22.Position = 1;
		w22.Expand = false;
		w22.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.label24 = new global::Gtk.Label();
		this.label24.Name = "label24";
		this.label24.LabelProp = global::Mono.Unix.Catalog.GetString("s");
		this.hbox4.Add(this.label24);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label24]));
		w23.Position = 2;
		w23.Expand = false;
		w23.Fill = false;
		this.vbox3.Add(this.hbox4);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
		w24.PackType = ((global::Gtk.PackType)(1));
		w24.Position = 3;
		w24.Expand = false;
		w24.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox10 = new global::Gtk.HBox();
		this.hbox10.Name = "hbox10";
		this.hbox10.Spacing = 6;
		// Container child hbox10.Gtk.Box+BoxChild
		this.SlopeWindowLabel = new global::Gtk.Label();
		this.SlopeWindowLabel.Name = "SlopeWindowLabel";
		this.SlopeWindowLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Moyennage pour le calcul de la pente sur + ou - : ");
		this.hbox10.Add(this.SlopeWindowLabel);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.SlopeWindowLabel]));
		w25.Position = 0;
		w25.Expand = false;
		w25.Fill = false;
		w25.Padding = ((uint)(15));
		// Container child hbox10.Gtk.Box+BoxChild
		this.SlopeWindowSpinButton = new global::Gtk.SpinButton(0D, 10000D, 1D);
		this.SlopeWindowSpinButton.CanFocus = true;
		this.SlopeWindowSpinButton.Name = "SlopeWindowSpinButton";
		this.SlopeWindowSpinButton.Adjustment.PageIncrement = 10D;
		this.SlopeWindowSpinButton.ClimbRate = 1D;
		this.SlopeWindowSpinButton.Numeric = true;
		this.hbox10.Add(this.SlopeWindowSpinButton);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.SlopeWindowSpinButton]));
		w26.Position = 1;
		w26.Expand = false;
		w26.Fill = false;
		// Container child hbox10.Gtk.Box+BoxChild
		this.label19 = new global::Gtk.Label();
		this.label19.Name = "label19";
		this.label19.LabelProp = global::Mono.Unix.Catalog.GetString("s");
		this.hbox10.Add(this.label19);
		global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.label19]));
		w27.Position = 2;
		w27.Expand = false;
		w27.Fill = false;
		this.vbox3.Add(this.hbox10);
		global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox10]));
		w28.PackType = ((global::Gtk.PackType)(1));
		w28.Position = 4;
		w28.Expand = false;
		w28.Fill = false;
		this.vbox2.Add(this.vbox3);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
		w29.Position = 0;
		w29.Expand = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox12 = new global::Gtk.VBox();
		this.vbox12.Name = "vbox12";
		// Container child vbox12.Gtk.Box+BoxChild
		this.UpdateAlertLabel = new global::Gtk.Label();
		this.UpdateAlertLabel.Name = "UpdateAlertLabel";
		this.UpdateAlertLabel.LabelProp = global::Mono.Unix.Catalog.GetString("<span foreground=\'red\' font=\'12\'>N\'oubliez pas d\'enregistrer vos modifications en" +
				" utilisant le bouton \"Mettre ?? jour\".</span>");
		this.UpdateAlertLabel.UseMarkup = true;
		this.vbox12.Add(this.UpdateAlertLabel);
		global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.UpdateAlertLabel]));
		w30.Position = 0;
		w30.Expand = false;
		w30.Fill = false;
		w30.Padding = ((uint)(15));
		// Container child vbox12.Gtk.Box+BoxChild
		this.UpdateValueButton = new global::Gtk.Button();
		this.UpdateValueButton.CanFocus = true;
		this.UpdateValueButton.Name = "UpdateValueButton";
		this.UpdateValueButton.UseUnderline = true;
		this.UpdateValueButton.Label = global::Mono.Unix.Catalog.GetString("Mettre ?? jour");
		this.vbox12.Add(this.UpdateValueButton);
		global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.UpdateValueButton]));
		w31.Position = 1;
		w31.Expand = false;
		w31.Fill = false;
		// Container child vbox12.Gtk.Box+BoxChild
		this.DeleteFileButton = new global::Gtk.Button();
		this.DeleteFileButton.CanFocus = true;
		this.DeleteFileButton.Name = "DeleteFileButton";
		this.DeleteFileButton.UseUnderline = true;
		this.DeleteFileButton.Label = global::Mono.Unix.Catalog.GetString("Supprimer le fichier");
		this.vbox12.Add(this.DeleteFileButton);
		global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.DeleteFileButton]));
		w32.Position = 2;
		w32.Expand = false;
		w32.Fill = false;
		this.vbox2.Add(this.vbox12);
		global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox12]));
		w33.PackType = ((global::Gtk.PackType)(1));
		w33.Position = 1;
		w33.Expand = false;
		w33.Fill = false;
		w33.Padding = ((uint)(15));
		this.notebook1.Add(this.vbox2);
		// Notebook tab
		this.label1 = new global::Gtk.Label();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Configuration");
		this.notebook1.SetTabLabel(this.vbox2, this.label1);
		this.label1.ShowAll();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox5 = new global::Gtk.VBox();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 5;
		// Container child vbox5.Gtk.Box+BoxChild
		this.TlimResults = new global::NIRSapp.ResultsWidget();
		this.TlimResults.Events = ((global::Gdk.EventMask)(256));
		this.TlimResults.Name = "TlimResults";
		this.TlimResults.ResultsLabel = "Tlim";
		this.vbox5.Add(this.TlimResults);
		global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.TlimResults]));
		w35.Position = 0;
		w35.Expand = false;
		w35.Fill = false;
		w35.Padding = ((uint)(5));
		// Container child vbox5.Gtk.Box+BoxChild
		this.TisoResults = new global::NIRSapp.ResultsWidget();
		this.TisoResults.Events = ((global::Gdk.EventMask)(256));
		this.TisoResults.Name = "TisoResults";
		this.TisoResults.ResultsLabel = "Tiso";
		this.vbox5.Add(this.TisoResults);
		global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.TisoResults]));
		w36.Position = 1;
		w36.Expand = false;
		w36.Fill = false;
		w36.Padding = ((uint)(5));
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox11 = new global::Gtk.HBox();
		this.hbox11.Name = "hbox11";
		this.hbox11.Spacing = 6;
		// Container child hbox11.Gtk.Box+BoxChild
		this.vbox17 = new global::Gtk.VBox();
		this.vbox17.Name = "vbox17";
		this.vbox17.Spacing = 6;
		// Container child vbox17.Gtk.Box+BoxChild
		this.label21 = new global::Gtk.Label();
		this.label21.Name = "label21";
		this.label21.LabelProp = global::Mono.Unix.Catalog.GetString("Tlim effectif : ");
		this.vbox17.Add(this.label21);
		global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox17[this.label21]));
		w37.Position = 0;
		w37.Expand = false;
		w37.Fill = false;
		// Container child vbox17.Gtk.Box+BoxChild
		this.label22 = new global::Gtk.Label();
		this.label22.Name = "label22";
		this.label22.LabelProp = global::Mono.Unix.Catalog.GetString("Tiso effectif :");
		this.vbox17.Add(this.label22);
		global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox17[this.label22]));
		w38.Position = 1;
		w38.Expand = false;
		w38.Fill = false;
		this.hbox11.Add(this.vbox17);
		global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.vbox17]));
		w39.Position = 0;
		w39.Expand = false;
		w39.Fill = false;
		w39.Padding = ((uint)(15));
		// Container child hbox11.Gtk.Box+BoxChild
		this.vbox18 = new global::Gtk.VBox();
		this.vbox18.Name = "vbox18";
		this.vbox18.Spacing = 6;
		// Container child vbox18.Gtk.Box+BoxChild
		this.TlimEffValueLabel = new global::Gtk.Label();
		this.TlimEffValueLabel.Name = "TlimEffValueLabel";
		this.TlimEffValueLabel.LabelProp = global::Mono.Unix.Catalog.GetString("0");
		this.vbox18.Add(this.TlimEffValueLabel);
		global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox18[this.TlimEffValueLabel]));
		w40.Position = 0;
		w40.Expand = false;
		w40.Fill = false;
		// Container child vbox18.Gtk.Box+BoxChild
		this.TisoValueLabel = new global::Gtk.Label();
		this.TisoValueLabel.Name = "TisoValueLabel";
		this.TisoValueLabel.LabelProp = global::Mono.Unix.Catalog.GetString("0");
		this.vbox18.Add(this.TisoValueLabel);
		global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox18[this.TisoValueLabel]));
		w41.Position = 1;
		w41.Expand = false;
		w41.Fill = false;
		this.hbox11.Add(this.vbox18);
		global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.vbox18]));
		w42.Position = 1;
		w42.Expand = false;
		w42.Fill = false;
		this.vbox5.Add(this.hbox11);
		global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox11]));
		w43.PackType = ((global::Gtk.PackType)(1));
		w43.Position = 2;
		w43.Expand = false;
		w43.Fill = false;
		w43.Padding = ((uint)(15));
		this.notebook1.Add(this.vbox5);
		global::Gtk.Notebook.NotebookChild w44 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox5]));
		w44.Position = 1;
		w44.TabFill = false;
		// Notebook tab
		this.label23 = new global::Gtk.Label();
		this.label23.Name = "label23";
		this.label23.LabelProp = global::Mono.Unix.Catalog.GetString("R??sultats");
		this.notebook1.SetTabLabel(this.vbox5, this.label23);
		this.label23.ShowAll();
		this.vbox7.Add(this.notebook1);
		global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.notebook1]));
		w45.Position = 0;
		w45.Expand = false;
		w45.Padding = ((uint)(15));
		// Container child vbox7.Gtk.Box+BoxChild
		this.analyseButton = new global::Gtk.Button();
		this.analyseButton.CanFocus = true;
		this.analyseButton.Name = "analyseButton";
		this.analyseButton.UseUnderline = true;
		this.analyseButton.Label = global::Mono.Unix.Catalog.GetString("Lancer l\'analyse");
		this.vbox7.Add(this.analyseButton);
		global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.analyseButton]));
		w46.PackType = ((global::Gtk.PackType)(1));
		w46.Position = 1;
		w46.Expand = false;
		w46.Fill = false;
		w46.Padding = ((uint)(15));
		this.hbox1.Add(this.vbox7);
		global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox7]));
		w47.Position = 1;
		w47.Padding = ((uint)(5));
		this.Add(this.hbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 962;
		this.DefaultHeight = 838;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.FileListView.CursorChanged += new global::System.EventHandler(this.OnFileListViewCursorChanged);
		this.AddFileButton.Clicked += new global::System.EventHandler(this.OnAddFileButtonClicked);
		this.UpdateValueButton.Clicked += new global::System.EventHandler(this.OnUpdateValueButtonClicked);
		this.DeleteFileButton.Clicked += new global::System.EventHandler(this.OnDeleteFileButtonClicked);
		this.analyseButton.Clicked += new global::System.EventHandler(this.OnAnalyseButtonClicked);
	}
}
