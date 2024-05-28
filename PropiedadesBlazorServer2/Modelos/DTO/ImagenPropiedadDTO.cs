using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazorServer2.Modelos.DTO
{
    public class ImagenPropiedadDTO
    {
        [Key]
        public int Id { get; set; }
        public int PropiedadId { get; set; }

        public string UrlImagenPropiedad { get; set; }
        
    }
}
