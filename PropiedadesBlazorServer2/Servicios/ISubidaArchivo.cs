using Microsoft.AspNetCore.Components.Forms;

namespace PropiedadesBlazorServer2.Servicios
{
    public interface ISubidaArchivo
    {
        Task<string> SubirArchivo(IBrowserFile archivo);

        bool BorrarArchivo(string nombre);
    }
}
