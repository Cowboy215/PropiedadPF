using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazorServer2.Data;
using PropiedadesBlazorServer2.Modelos;
using PropiedadesBlazorServer2.Modelos.DTO;
using PropiedadesBlazorServer2.Repositorio.IRepositorio;

namespace PropiedadesBlazorServer2.Repositorio
{
    public class PropiedadRepositorio : IPropiedadRepositorio
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PropiedadRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            //Cada Vez que llamemos al constructor inicializa los atributo de esta clase.
            _db = db;
            _mapper = mapper;
        }

        public async Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO)
        {
            try
            {
                if (propiedadId == propiedadDTO.Id)
                {
                    //Valido para actualizar.
                    // El metodo .FindAsync Busca en la tabla propiedad por el id
                    Propiedad propiedad = await _db.Propiedad.FindAsync(propiedadId);
                    //La sintasis del maper es
                    //_mapper.Map<Tipo de dato Origen, Tipo de dato Destino>(ObjetosOrigen, Objetodestino)
                    Propiedad propie = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO, propiedad);
                    // Nota que DateTime es una propiedad estatica que llama metodo .now pero como es
                    // Una propiedad no necesita paretesis.
                    propie.FechaActualizacion = DateTime.Now;
                    var propiedadActualizada = _db.Propiedad.Update(propie);
                    //Guarda los cambios (Async ya que es un metodo asincrono)
                    await _db.SaveChangesAsync();
                    //Con este return estamos actualizado CategoiraDTO .Entity me permite acceder a la entidad.
                    return _mapper.Map<Propiedad, PropiedadDTO>(propiedadActualizada.Entity);
                }
                else
                {
                    //No se encuentra el id Propiedad
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> BorrarPropiedad(int propiedadId)
        {
            var propiedad = await _db.Propiedad.FindAsync(propiedadId);
            if (propiedad != null)
            {
                var todasImagenes = await _db.ImagenPropiedad.Where(x => x.Id == propiedadId).ToListAsync();
                _db.ImagenPropiedad.RemoveRange(todasImagenes);
                //Para borrar usamos .Remove
                _db.Propiedad.Remove(propiedad);
                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO)
        {
            Propiedad propiedad = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO);
            propiedad.FechaCreacion = DateTime.Now;
            // .AddAsync es para insertar
            //--->  Cuando interactuemos con metodos asyncronos siempre poner el await.
            var propiedadAgregada = await _db.Propiedad.AddAsync(propiedad);
            await _db.SaveChangesAsync();
            return _mapper.Map<Propiedad, PropiedadDTO>(propiedadAgregada.Entity);
        }

        public async Task<IEnumerable<PropiedadDTO>> GetAllPropiedad()
        {
            //Version 1
            //try
            //{
            //    IEnumerable<PropiedadDTO> propiedadsDTO =
            //        _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(_db.Propiedad);
            //    return (propiedadsDTO);
            //}
            //catch (Exception ex)
            //{

            //    return null;
            //}

            //Version 2 Inclullo las imagenes 
            try
            {
                IEnumerable<PropiedadDTO> propiedadsDTO =
                    _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>
                    (_db.Propiedad.Include(x => x.ImagenPropiedad).Include(c => c.Categoria));
                return propiedadsDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<PropiedadDTO> GetPropiedad(int propiedadId)
        {
            try
            {
                PropiedadDTO propiedadDTO =
                    _mapper.Map<Propiedad, PropiedadDTO>(await _db.Propiedad.FirstOrDefaultAsync(c => c.Id == propiedadId));
                return (propiedadDTO);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<PropiedadDTO> NombrePropiedadExiste(string Nombre)
        {
            try
            {
                PropiedadDTO propiedadDTO = _mapper.Map<Propiedad, PropiedadDTO>
                    (await _db.Propiedad.FirstOrDefaultAsync
                    (c => c.Nombre.ToLower() == Nombre.ToLower()));
                return propiedadDTO;
            }
            catch (Exception ex)
            {

                throw null;
            }
        }
    }
}
