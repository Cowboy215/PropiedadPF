using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazorServer2.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

        //Relacion con Propiedad / tabla categoria

        public virtual ICollection<Propiedad> Propiedad { get; set; }
    }
}
