using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazorServer2.Data;
using PropiedadesBlazorServer2.Modelos;
using PropiedadesBlazorServer2.Modelos.DTO;
using PropiedadesBlazorServer2.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropiedadesBlazorServer2.Repositorio
{
    public class IMagenPropiedadRepositorio : IIMagenPropiedadRepositorio
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public IMagenPropiedadRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            //Cada Vez que llamemos al constructor inicializa los atributo de esta clase.
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> BorrarPropiedadImagenPorIdImagen(int imagenId)
        {
            var imagen = await _db.ImagenPropiedad.FindAsync(imagenId);
            _db.ImagenPropiedad.Remove(imagen);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> BorrarPropiedadImagenPorIdPropiedad(int propiedadId)
        {
            var listaImagenes = await _db.ImagenPropiedad.Where(x => x.Id == propiedadId).ToListAsync();
            //El metodo RemoveRange Borra un rango
            _db.ImagenPropiedad.RemoveRange(listaImagenes);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> BorrarPropiedadImagenPorUrlImagen(string imagenUrl)
        {
            var todasImagenes = await _db.ImagenPropiedad.FirstOrDefaultAsync
                (x => x.UrlImagenPropiedad.ToLower() == imagenUrl.ToLower());
            if (todasImagenes == null)
            {
                return 0;
            }
            _db.ImagenPropiedad.Remove(todasImagenes);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDTO)
        {
            var imagen = _mapper.Map<ImagenPropiedadDTO, ImagenPropiedad>(imagenDTO);
            await _db.ImagenPropiedad.AddAsync(imagen);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId)
        {
            return _mapper.Map<IEnumerable<ImagenPropiedad>, IEnumerable<ImagenPropiedadDTO>>(
                await _db.ImagenPropiedad.Where(x => x.Id == propiedadId).ToListAsync());
        }
    }
}
