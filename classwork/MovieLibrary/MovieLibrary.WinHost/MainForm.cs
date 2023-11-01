using MovieLibrary.Memory;

namespace MovieLibrary.WinHost;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    //protected override void OnFormClosing ( FormClosingEventArgs e )
    //{
    //    if (_movie != null)
    //    {
    //        if (!Confirm("Do you want to exit?", "Exit"))
    //        {
    //            e.Cancel = true;
    //            return;
    //        }
    //    };

    //    base.OnFormClosing(e);
    //}

    protected override void OnLoad ( EventArgs e )
    {
        base.OnLoad(e);

        RefreshMovies();
    }

    #region Event Handlers

    private void OnFileExit ( object sender, EventArgs e )
    {
        Close();
    }

    private void OnAddMovie ( object sender, EventArgs e )
    {
        var dlg = new MovieForm();

        do
        {
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            //Add movie to library         
            var error = _database.Add(dlg.Movie);
            if (String.IsNullOrEmpty(error))
                break;
            MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } while (true);

        RefreshMovies();
    }

    private void OnEditMovie ( object sender, EventArgs e )
    {        
        var movie = GetSelectedMovie();
        if (movie == null)
            return;

        var dlg = new MovieForm();
        dlg.Movie = movie;

        do
        {
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            //Edit movie in library
            var error = _database.Update(movie.Id, dlg.Movie);
            if (String.IsNullOrEmpty(error))
                break;
            MessageBox.Show(this, error, "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } while (true);

        RefreshMovies();
    }
    
    private void OnDeleteMovie ( object sender, EventArgs e )
    {
        var movie = GetSelectedMovie();
        if (movie == null)
            return;

        if (!Confirm("Delete", $"Are you sure you want to delete '{movie.Title}'?"))
            return;

        //Delete movie
        _database.Delete(movie.Id);
        RefreshMovies();
    }

    private void OnHelpAbout ( object sender, EventArgs e )
    {
        var about = new AboutBox();
        about.ShowDialog(this);
    }
    #endregion

    #region Private Members

    private bool Confirm ( string title, string message )
    {
        return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    private Movie GetSelectedMovie()
    {
        return _lstMovies.SelectedItem as Movie;
    }

    private void RefreshMovies()
    {
        _lstMovies.DataSource = null;

        var movies = _database.GetAll();

        var source = new BindingSource() {
            DataSource = movies
        };
        _lstMovies.DataSource = source;
        
        //movies[0].Title = "None";
        //movies[2] = new Movie() { Title = "Bob" };

        //var movies2 = _database.GetAll();
    }

    private IMovieDatabase _database = new MemoryMovieDatabase();
    #endregion
}