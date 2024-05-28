using Microsoft.AspNetCore.Components.Forms;

namespace PropiedadesBlazorServer2.Servicios
{
    public class SubidaArchivo : ISubidaArchivo
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public SubidaArchivo(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public bool BorrarArchivo(string nombreArchivo)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\{nombreArchivo}";
                if (File.Exists(path)) 
                {
                    File.Delete(path);
                    return true ;
                }
                return false ;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> SubirArchivo(IBrowserFile archivo)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(archivo.Name);
                //El GuiD nos da un identificador unico. Y lo combinamos la extencion.
                var filename = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\ImagenesPropiedades";
                //Combina la ruta en una sola Nota:Cuidado con la ruta .Combine(Ya que si ponemos el folder ya tine)
                //La carperta ImagenesPropiedades.
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "ImagenesPropiedades", filename);

                var memoryStream = new MemoryStream();
                await archivo.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory))
                {
                    //Creamos el directorio si no existe
                    Directory.CreateDirectory(folderDirectory);
                }

                //El using es una estructura similar al try finally 
                //Garantisa que los recursos se liberen Correctamente.
                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }

                var url = $"{_configuration.GetValue<string>("ServerUrl")}";
                var fullpath = $"{url}ImagenesPropiedades/{filename}";
                return fullpath ;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
