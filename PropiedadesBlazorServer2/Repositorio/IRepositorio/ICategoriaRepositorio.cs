using PropiedadesBlazorServer2.Modelos.DTO;

namespace PropiedadesBlazorServer2.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        public Task<IEnumerable<CategoriaDTO>> GetAllCategoria();
        public Task<CategoriaDTO> GetCategoria(int categoriaId);
        public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);
        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);

        public Task<CategoriaDTO> NombreCategoriaExiste(string Nombre);
        public Task<int> BorrarCategoria(int categoriaId);

        //Implementacion del dropdawn
        public Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategoria();

    }
}
