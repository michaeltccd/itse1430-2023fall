namespace MovieLibrary.IO;

public class CsvMovieDatabase : MovieDatabase
{
    public CsvMovieDatabase ( string filename )
    {
        _filename = filename;
    }

    protected override Movie AddCore ( Movie movie ) => throw new NotImplementedException();
    protected override void DeleteCore ( int id ) => throw new NotImplementedException();
    protected override Movie FindById ( int id ) => throw new NotImplementedException();
    protected override Movie FindByTitle ( string title ) => throw new NotImplementedException();
    protected override IEnumerable<Movie> GetAllCore ()
    {        
        return LoadMovies();
    }

    protected override Movie GetCore ( int id ) => throw new NotImplementedException();
    protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();

    private IEnumerable<Movie> LoadMovies ()
    {
        if (File.Exists(_filename))
        {
            //System.IO.File
            //string[] lines = File.ReadAllLines(_filename);
            //string text = File.ReadAllText(_filename);
            foreach (var line in File.ReadLines(_filename))
            {
                //TODO: Parse line
                yield return new Movie() { Title = line };
            };
        };        
    }

    private readonly string _filename;
}
