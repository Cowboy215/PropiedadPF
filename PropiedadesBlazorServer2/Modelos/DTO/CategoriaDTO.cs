using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazorServer2.Modelos.DTO
{
    public class CategoriaDTO
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre de la Categoria es Obligatorio.")]
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
