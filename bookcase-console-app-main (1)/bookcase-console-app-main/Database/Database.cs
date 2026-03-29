using Microsoft.Data.Sqlite;
namespace MiembroApp.Database;

class Database(string dbPath) {
  private readonly string _connectionPath = $"Data Source={dbPath}";

  public SqliteConnection GetConnection() {
    var connection = new SqliteConnection(_connectionPath);
    connection.Open();
    return connection;
  }

  public void PrintTableNames() {
    using var conn = GetConnection();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
    using var rdr = cmd.ExecuteReader();
    while (rdr.Read()) Console.WriteLine(rdr.GetString(0));
  }

  public void CreateMiembroTable() {
    using var conn = new SqliteConnection(_connectionPath);
    conn.Open();
    using var cmd = conn.CreateCommand();
    cmd.CommandText = @"
      CREATE TABLE IF NOT EXISTS Miembro (
        id_Miembro INTEGER PRIMARY KEY AUTOINCREMENT,
        Nombre TEXT,
        Cedula TEXT,
        Telefono TEXT
      );";
    cmd.ExecuteNonQuery();
  }
}