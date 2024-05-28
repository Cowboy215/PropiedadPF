using PropiedadesBlazorServer2.Modelos.DTO;

namespace PropiedadesBlazorServer2.Repositorio.IRepositorio
{
    public interface IPropiedadRepositorio
    {
        public Task<IEnumerable<PropiedadDTO>> GetAllPropiedad();
        public Task<PropiedadDTO> GetPropiedad(int propiedadId);
        public Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO);
        public Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO);

        public Task<PropiedadDTO> NombrePropiedadExiste(string Nombre);
        public Task<int> BorrarPropiedad(int propiedadId);

    }
}
