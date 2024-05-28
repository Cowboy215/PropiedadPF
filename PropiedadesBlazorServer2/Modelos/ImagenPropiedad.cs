using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazorServer2.Modelos
{
    public class ImagenPropiedad
    {
        [Key]
        public int Id { get; set; }
        public int PropiedadId { get; set; }

        public string UrlImagenPropiedad { get; set; }
        [ForeignKey("PropiedadId")]
        public virtual Propiedad Propiedad { get; set; }
    }
}
