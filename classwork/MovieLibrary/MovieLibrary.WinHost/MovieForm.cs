using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.WinHost;

public partial class MovieForm : Form
{
    public MovieForm ()
    {
        InitializeComponent();
    }

    /// <summary>Gets or sets the movie.</summary>
    public Movie Movie { get; set; }

    //Called to init form just before it is shown
    protected override void OnLoad ( EventArgs e )
    {
        base.OnLoad(e);

        //Load movie data, if any
        if (Movie != null)
        {
            Text = "Edit Movie";
            
            _txtTitle.Text = Movie.Title;
            _txtDescription.Text = Movie.Description;
            _txtGenre.Text = Movie.Genre;

            _cbRating.Text = Movie.Rating?.Name;
            _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            _txtRunLength.Text = Movie.RunLength.ToString();

            _chkIsBlackAndWhite.Checked = Movie.IsBlackAndWhite;
        };

        ValidateChildren();
    }

    private void OnSave ( object sender, EventArgs e )
    {
        //Validate and abort if necessary
        if (!ValidateChildren())
        {
            DialogResult = DialogResult.None;
            return;
        };        

        var button = sender as Button;

        var movie = new Movie();

        //Populate from the UI
        movie.Title = _txtTitle.Text;
        movie.Description = _txtDescription.Text;
        movie.Genre = _txtGenre.Text;

        movie.Rating = new Rating(_cbRating.Text);
        movie.ReleaseYear = GetInt32(_txtReleaseYear, 0);
        movie.RunLength = GetInt32(_txtRunLength, -1);

        movie.IsBlackAndWhite = _chkIsBlackAndWhite.Checked;

        //Validate        
        //if (!movie.TryValidate(out var error))
        if (!new ObjectValidator().TryValidate(movie, out var results))
        {
            var error = results.First();
            MessageBox.Show(this, error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DialogResult = DialogResult.None;
            return;                
        };

        Movie = movie;
        //DialogResult = DialogResult.OK;
        //Close();
    }

    private void OnCancel ( object sender, EventArgs e )
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private int GetInt32 ( Control control, int defaultValue )
    {
        if (Int32.TryParse(control.Text, out var value))
            return value;

        return defaultValue;
    }

    private void OnValidateTitle ( object sender, System.ComponentModel.CancelEventArgs e )
    {
        if (String.IsNullOrEmpty(_txtTitle.Text))
        {
            //Invalid
            _errors.SetError(_txtTitle, "Title is required");
            e.Cancel = true;
        } else
            _errors.SetError(_txtTitle, "");
    }

    private void OnValidateReleaseYear ( object sender, System.ComponentModel.CancelEventArgs e )
    {
        var value = GetInt32(_txtReleaseYear, 1);
        if (value < 1900)
        {
            //Invalid
            _errors.SetError(_txtReleaseYear, "Release Year must be at least 1900");
            e.Cancel = true;
        } else
            _errors.SetError(_txtReleaseYear, "");
    }

    private void OnValidateRunLength ( object sender, System.ComponentModel.CancelEventArgs e )
    {
        var value = GetInt32(_txtRunLength, -1);
        if (value < 0)
        {
            //Invalid
            _errors.SetError(_txtRunLength, "Run Length must be >= 0");
            e.Cancel = true;
        } else
            _errors.SetError(_txtRunLength, "");
    }

    private void OnValidateRating ( object sender, System.ComponentModel.CancelEventArgs e )
    {
        if (String.IsNullOrEmpty(_cbRating.Text))
        {
            //Invalid
            _errors.SetError(_cbRating, "Rating is required");
            e.Cancel = true;
        } else
            _errors.SetError(_cbRating, "");
    }
}
