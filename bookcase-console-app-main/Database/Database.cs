using Microsoft.Data.Sqlite;
namespace MiembroApp.Database;

class Database(string dbPath) {
  private readonly string _connectionPath = $"Data Source={dbPath}";

  public SqliteConnection GetConnection() {
    var connection = new SqliteConnection(_connectionPath);
    connection.Open();
    return connection;
  }
}