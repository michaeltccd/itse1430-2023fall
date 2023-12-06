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

        RefreshMovies(true);
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

            //tr-catch ::= try-block catch-block+ ;
            //try-block ::= try { S* }
            //catch-block ::= catch [ ( Exception [id] ) ] { S* }
            try
            {
                //Add movie to library         
                _database.Add(dlg.Movie);
                break;
            } catch (NotImplementedException)
            {
                //I really cannot do anything about this but I'll try...
                throw;
            } catch (InvalidOperationException)
            {
                MessageBox.Show(this, "Movie already exists", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (ArgumentException)
            {
                MessageBox.Show(this, "You messed up dude", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                //Error handling
                MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };                       
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

            try
            {
                _database.Update(movie.Id, dlg.Movie);
                break;
            } catch (InvalidOperationException)
            {
                MessageBox.Show(this, "Movie already exists", "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (ArgumentException)
            {
                MessageBox.Show(this, "You messed up dude", "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                //Error handling
                MessageBox.Show(this, ex.Message, "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
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
        try
        {
            _database.Delete(movie.Id);
        } catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
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

    private void RefreshMovies ( bool initial = false )
    {
        //_lstMovies.DataSource = null;

        IEnumerable<Movie> movies = null;
        try
        {
            movies = _database.GetAll();

            //Seed database if desired
            if (initial && !movies.Any() && Confirm("Seed", "Do you want to seed the database with movies?"))
            {
                _database.Seed();

                movies = _database.GetAll();
            };

            movies = from m in movies
                        orderby m.Title, m.ReleaseYear descending
                        select m;
        } catch (Exception ex)
        {
            MessageBox.Show(this, "Unable to retrieve movies.", "Get Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } finally
        {
            _lstMovies.DataSource = movies?.ToArray();
        };                
    }

    private readonly IMovieDatabase _database = new Sql.SqlMovieDatabase(Program.GetConnectionString("MovieDatabase"));//new IO.CsvMovieDatabase("movies.csv");

    private ValidatableObject _notUsed;
    #endregion
}