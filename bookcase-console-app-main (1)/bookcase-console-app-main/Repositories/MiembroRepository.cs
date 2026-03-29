using MiembroApp.Database;

class MiembroRepository(Database db) {
  private readonly Database _db = db;

  public List<MiembroModel> SelectAll() {
    using var connection = _db.GetConnection();            
    using var command = connection.CreateCommand();

    command.CommandText = "SELECT * FROM Miembro;";

    using var reader = command.ExecuteReader();

    List<MiembroModel> Miembros = new List<MiembroModel>();

    while (reader.Read()) {
      Miembros.Add(
        new MiembroModel {
          Id = reader.GetInt32(0),
          Nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
          Cedula = reader.IsDBNull(2) ? null : reader.GetString(2),
          Telefono = reader.IsDBNull(3) ? null : reader.GetString(3)
        }
      );
    }

    return Miembros;

  }

  public int Delete(int id) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      DELETE FROM Miembro WHERE id_Miembro = @id;
    ";
    command.Parameters.AddWithValue("@id", id);

    int rowDeleted = command.ExecuteNonQuery();

    return rowDeleted;
  }

  public int Insert(string Nombre, string Cedula, string Telefono) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      INSERT INTO
        Miembro (Nombre, Cedula, Telefono)
      VALUES (@Nombre,@Cedula,@Telefono);
    ";

    command.Parameters.AddWithValue("@Nombre", Nombre);
    command.Parameters.AddWithValue("@Cedula", Cedula);
    command.Parameters.AddWithValue("@Telefono", Telefono);

    int rowInserted = command.ExecuteNonQuery();

    return rowInserted;
  }

  public int Update(string Nombre, string Cedula, string Telefono, int id) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      UPDATE 
        Miembro
      SET Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono
      WHERE id_Miembro = @id;
    ";

    command.Parameters.AddWithValue("@Nombre", Nombre);
    command.Parameters.AddWithValue("@Cedula", Cedula);
    command.Parameters.AddWithValue("@Telefono", Telefono);
    command.Parameters.AddWithValue("@id", id);

    int rowUpdated = command.ExecuteNonQuery();

    return rowUpdated;
  }
}