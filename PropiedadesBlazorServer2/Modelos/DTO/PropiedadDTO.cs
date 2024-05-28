using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazorServer2.Modelos.DTO
{
    public class PropiedadDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(30, MinimumLength =5, ErrorMessage ="Minimo 5 caracteres. Maximo 30")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "La descripcion Minimo 20 caracteres. Maximo 300 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Area es obligatorio")]
        [Range(1, 5000, ErrorMessage = "Minimo 1 caracteres. Maximo 5000")]
        public int Area { get; set; }
        [Required(ErrorMessage = "La habitacion es obligatoria")]
        [Range(1, 10, ErrorMessage = "Minimo 1 caracteres. Maximo 10")]
        public int Habitaciones { get; set; }
        [Required(ErrorMessage = "El Bano es obligatorio")]
        [Range(1, 5, ErrorMessage = "Minimo 1 caracteres. Maximo 5")]
        public int Banios { get; set; }
        [Required(ErrorMessage = "El Estacionamiento es obligatorio")]
        [Range(1, 20, ErrorMessage = "Minimo 1 caracteres. Maximo 20")]
        public int Parqueadero { get; set; }
        [Required(ErrorMessage = "El Precio es obligatorio")]
        public double Precio { get; set; }
        [Required]
        public bool Activo { get; set; }

        public DateTime FechaActualizacion { get; set; }

        //Relacion propiedad/categoria 
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<ImagenPropiedad> ImagenPropiedad { get; set; }

        public List<string> UrlImagenes { get; set; }
    }
}
