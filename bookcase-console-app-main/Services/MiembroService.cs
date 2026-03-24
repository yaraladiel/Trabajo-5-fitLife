class MiembroService(MiembroRepository MiembroRepository) {
    private readonly MiembroRepository _MiembroRepository = MiembroRepository;

    public List<MiembroModel> SelectAll() {
        return _MiembroRepository.SelectAll();
    }
    public int Delete(int id) {
        return _MiembroRepository.Delete(id);
    }
    public int Insert(string Nombre, string Cedula, string Telefono) {
        return _MiembroRepository.Insert(Nombre, Cedula, Telefono);
    }

    public int Update(string Nombre, string Cedula, string Telefono, int id) {
        return _MiembroRepository.Update(Nombre, Cedula, Telefono, id);
    }
}