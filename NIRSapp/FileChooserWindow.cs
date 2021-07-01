using System;
using Gtk;

namespace NIRSapp
{
    public partial class FileChooserWindow : Gtk.Window
    {
        public string[] SelectedFiles;
        public event EventHandler FileChosed;

        public FileChooserWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnFileChooserSelectionChanged(object sender, EventArgs e)
        {
            FileChooserWidget fileChooser = (FileChooserWidget)sender;

            SelectedFiles = fileChooser.Filenames;
        }

        protected void OnAddFileButtonClicked(object sender, EventArgs e)
        {
            EventHandler handler = FileChosed;
            handler?.Invoke(this, e);
        }
    }
}
