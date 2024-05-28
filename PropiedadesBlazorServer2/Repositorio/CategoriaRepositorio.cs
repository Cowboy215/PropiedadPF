using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazorServer2.Data;
using PropiedadesBlazorServer2.Modelos;
using PropiedadesBlazorServer2.Modelos.DTO;
using PropiedadesBlazorServer2.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropiedadesBlazorServer2.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoriaRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            //Cada Vez que llamemos al constructor inicializa los atributo de esta clase.
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaId == categoriaDTO.Id)
                {
                    //Valido para actualizar.
                    // El metodo .FindAsync Busca en la tabla categoria por el id
                    Categoria categoria = await _db.Categoria.FindAsync(categoriaId);
                    //La sintasis del maper es
                    //_mapper.Map<Tipo de dato Origen, Tipo de dato Destino>(ObjetosOrigen, Objetodestino)
                    //En donde simplemete hace una copia de CategoriaDTO a Categoria
                    Categoria cate = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO, categoria);
                    // Nota que DateTime es una propiedad estatica que llama metodo .now pero como es
                    // Una propiedad no necesita paretesis.
                    cate.FechaActualizacion = DateTime.Now;
                    var categoriaActualizada = _db.Categoria.Update(cate);
                    //Guarda los cambios (Async ya que es un metodo asincrono)
                    await _db.SaveChangesAsync(); 
                    //Con este return estamos actualizado CategoiraDTO .Entity me permite acceder a la entidad.
                    return _mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);
                }
                else
                {
                    //No se encuentra el id Categoria
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> BorrarCategoria(int categoriaId)
        {
            var categoria = await _db.Categoria.FindAsync(categoriaId);
            if (categoria != null)
            {
                //Para borrar usamos .Remove
                _db.Categoria.Remove(categoria);
                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            categoria.FechaCreacion = DateTime.Now;
            // .AddAsync es para insertar
            //--->  Cuando interactuemos con metodos asyncronos siempre poner el await.
            var categoriaAgregada = await _db.Categoria.AddAsync(categoria);
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoriaAgregada.Entity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategoria()
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriasDTO = 
                    _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(_db.Categoria);
                return (categoriasDTO);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> GetCategoria(int categoriaId)
        {
            try
            {
                CategoriaDTO categoriaDTO =
                    _mapper.Map<Categoria, CategoriaDTO>(await _db.Categoria.FirstOrDefaultAsync(c => c.Id == categoriaId));
                return (categoriaDTO);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategoria()
        {
            try
            {
                IEnumerable<DropDownCategoriaDTO> dropDownCategoriaDTO =
                    _mapper.Map<IEnumerable<Categoria>, IEnumerable<DropDownCategoriaDTO>>(_db.Categoria);
                return (dropDownCategoriaDTO);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> NombreCategoriaExiste(string Nombre)
        {
            try
            {
                CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>
                    (await _db.Categoria.FirstOrDefaultAsync
                    (c => c.NombreCategoria.ToLower() == Nombre.ToLower()));
                return categoriaDTO;
            }
            catch (Exception ex)
            {

                throw null;
            }
        }
    }
}
