global using Spectre.Console;
using MiembroApp.Database;
using MiembroApp.Screens;

class Program {
  public static void Main(string[] args) {
    Database database = new("Miembrocase.db");
    database.CreateMiembroTable(); // asegura la tabla antes de usarla
    MiembroRepository MiembroRepository = new(database);
    MiembroService MiembroService = new(MiembroRepository);

    MainScreen mainScreen = new(MiembroService);
    mainScreen.Show();
  }
}