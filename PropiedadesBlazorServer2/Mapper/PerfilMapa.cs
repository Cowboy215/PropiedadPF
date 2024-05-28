using AutoMapper;
using PropiedadesBlazorServer2.Modelos;
using PropiedadesBlazorServer2.Modelos.DTO;

namespace PropiedadesBlazorServer2.Mapper
{
    public class PerfilMapa : Profile
    {
        public PerfilMapa()
        {
            //Esta es una forma de hacer la vinculacion Bidireccional
            //CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();
            //Esta linea es equivalente en un enlace bidireccional
            CreateMap<Propiedad, PropiedadDTO>().ReverseMap();
            CreateMap<Categoria, DropDownCategoriaDTO>().ReverseMap();
            CreateMap<ImagenPropiedad, ImagenPropiedadDTO>().ReverseMap();
        }
    }
}
