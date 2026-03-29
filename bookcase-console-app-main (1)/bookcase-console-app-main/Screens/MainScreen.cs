namespace MiembroApp.Screens;

class MainScreen(MiembroService MiembroService) {
  private bool running = true;
  private readonly MiembroService _MiembroService = MiembroService;
  private readonly (string Text, int Value)[] choices = [
    ("1. Mostrar los Miembros", 1),
    ("2. Agregar un nuevo Miembro", 2),
    ("3. Eliminar un Miembro", 3),
    ("4. Actualizar un Miembro", 4),
    ("5. Salir", 0)
  ];
  public void Show() {
    while (running) {

      // Menu selection
      var selection = new SelectionPrompt<(string Text, int Value)>()
        .Title("Bienvenido a la App GYM")
        .AddChoices(choices)
        .UseConverter(c => $"{c.Text}");

      // Get user choice
      var choiced = AnsiConsole.Prompt(selection);

      // Choose an option from the menu
      switch (choiced.Value) {
        case 1:
          var table = new Table();

          table.AddColumn("Id");
          table.AddColumn("Nombre");
          table.AddColumn("Cedula");
          table.AddColumn("Telefono");

          foreach (var Miembro in _MiembroService.SelectAll()) {
            table.AddRow(
              $"{Miembro.Id}",
              $"{Miembro.Nombre}",
              $"{Miembro.Cedula}",
              $"{Miembro.Telefono}"
            );
          }
          AnsiConsole.Write(table);
          break;
        case 2:
          AnsiConsole.Clear();
          var Nombre = AnsiConsole.Ask<string>("Nombre del Miembro: ");
          var Cedula = AnsiConsole.Ask<string>("Cedula del Miembro: ");
          var Telefono = AnsiConsole.Ask<string>("Telefono del Miembro: ");

          _MiembroService.Insert(Nombre, Cedula, Telefono);

          AnsiConsole.Clear();

          break;
        case 3:
          AnsiConsole.Clear();
          var id = AnsiConsole.Ask<int>("Inserte el id del miembro a eliminar: ");
          _MiembroService.Delete(id);
          AnsiConsole.Clear();
          break;
        case 4:
          AnsiConsole.Clear();
          var updateId = AnsiConsole.Ask<int>("Inserte el id del Miembro a actualizar: ");
          var updateNombre = AnsiConsole.Ask<string>("Nombre del Miembro: ");
          var updateCedula = AnsiConsole.Ask<string>("Cedula del Miembro: ");
          var updateTelefono = AnsiConsole.Ask<string>("Telefono del Miembro: ");

          _MiembroService.Update(updateNombre, updateCedula, updateTelefono, updateId);

          AnsiConsole.Clear();
          break;
        case 0:
          AnsiConsole.Clear();
          Console.WriteLine("Saliendo de la app");
          running = false;
          break;
      }
    }
  }
}