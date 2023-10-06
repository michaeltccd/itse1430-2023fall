namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Movie _movie;

        private void OnAddMovie ( object sender, EventArgs e )
        {
            MessageBox.Show("Add Not implemented");
        }

        private void EditToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            MessageBox.Show("Edit Not implemented");
        }

        private void DeleteToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            MessageBox.Show("Delete Not implemented");
        }
        //private MovieLibrary.Movie _movie;
    }
}