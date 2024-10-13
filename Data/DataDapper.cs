using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CSharpNotes.Data;


        // Dapper is one way for connecting to Databases in .NET
        //  IDbConnection is the interface for DB Connections, SqlConnection is class for Sql Client Instance
        // Query (Multiple Rows) or QuerySingle is used to return instances from DB
        // Execute is used to manipulate records in DB.
        
public class DataDapper{
    private IConfiguration config;
    private string ?_connectionString;

    public DataDapper(IConfiguration config)
    {
        this.config = config;
        _connectionString = config.GetConnectionString("mssql-connection");
    }

    // Convention to place _ at the beginning of private variables


    public IEnumerable<T> QueryData<T> (string sql){
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }

        public T QueryDataSingle<T> (string sql){
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        
        public int ExecuteSql(string sql){
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
            
}