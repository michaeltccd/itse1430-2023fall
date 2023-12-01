/*
 * ITSE 1430
 * Fall 2023
 */
using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using Microsoft SQL Server.</summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        /// <summary>Initializes an instance of the <see cref="SqlMovieDatabase"/> class.</summary>
        /// <param name="connectionString">Connection string.</param>
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc />
        protected override Movie AddCore ( Movie movie ) => throw new NotImplementedException();

        /// <inheritdoc />
        protected override void DeleteCore ( int id ) => throw new NotImplementedException();

        /// <inheritdoc />
        protected override Movie FindById ( int id ) => throw new NotImplementedException();

        /// <inheritdoc />
        protected override Movie FindByTitle ( string title ) => throw new NotImplementedException();

        /// <inheritdoc />
        protected override IEnumerable<Movie> GetAllCore ()
        {
            //Open connection, do work, close connection
            using var conn = OpenConnection();

            //Buffered IO using DataSet and SqlDataAdapter
            //DataSet
            // In-memory database that supports CRUD operations on data
            // Discoverable schema
            // Supports multiple tables
            // Can make changes and push them back to database
            // Provides a "business layer" for applications that don't need one
            var ds = new DataSet();
            var da = new SqlDataAdapter() {                
                SelectCommand = new SqlCommand("GetMovies", conn) { CommandType = CommandType.StoredProcedure },
                //InsertCommand =,
                //UpdateCommand = ,
                //DeleteCommand = ,
            };
            da.Fill(ds);                

            //conn.Close();
            return Enumerable.Empty<Movie>();
        }

        /// <inheritdoc />
        protected override Movie GetCore ( int id ) => throw new NotImplementedException();

        /// <inheritdoc />
        protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();

        #region private Members

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
        #endregion
    }
}