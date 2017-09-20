using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RLE;

namespace Lab02ProgramaPrincipal
{
    class Program
    {
        static void Main(string[] args)
        {
            Run_Lenght_Encode RLELibreria = new Run_Lenght_Encode();
            Estadísticas obj1 = new Estadísticas();
            Validaciones validar = new Validaciones();
            string textoIngresado = "";

            //Obtener comandos
            Console.WriteLine("Ingrese el comando y la ruta del archivo:");
            textoIngresado = Console.ReadLine();
            string DirecciónArchivoOriginal = validar.ObtenerDirección(textoIngresado);

            DirectoryInfo InfoArchivo = new DirectoryInfo(DirecciónArchivoOriginal);

            string DirecciónArchivoComprimido = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + InfoArchivo.Name+ ".rlex";

            //Comprimir
            if (validar.validarComprimir(textoIngresado) == true)
            {
                byte[] textoCodificado = RLELibreria.Codificar(DirecciónArchivoOriginal);
                RLELibreria.EscrituraArchivoCodificado(textoCodificado, InfoArchivo.Name);
                Console.WriteLine("Archivo comprimido exitosamente.");
                //INFORMACIÓN DE LOS ARCHIVOS
                Console.WriteLine("");
                Console.WriteLine("Estadísticas del archivo generado: ");
                Console.WriteLine("");
                System.IO.FileInfo infoOriginal = new System.IO.FileInfo(DirecciónArchivoOriginal);
                System.IO.FileInfo infoComprimido = new System.IO.FileInfo(DirecciónArchivoComprimido);

                Console.WriteLine("*Tamaño original: " + infoOriginal.Length);
                Console.WriteLine("*Tamaño final: " + infoComprimido.Length);
                Console.WriteLine("*Ratio de Compresión: " + obj1.RatioDeCompresion(DirecciónArchivoComprimido, DirecciónArchivoOriginal));
                Console.WriteLine("*Factor de Compresión: " + obj1.FactorDeCompresion(DirecciónArchivoComprimido, DirecciónArchivoOriginal));
                Console.WriteLine("*Porcentaje ahorrado: " + obj1.PorcentajeAhorrado(DirecciónArchivoComprimido, DirecciónArchivoOriginal) + " %");



            }
            //Descomprimir

            Console.WriteLine("Ingrese un nuevo comando: ");
            textoIngresado = Console.ReadLine();
            if (validar.validarDescomprimir(textoIngresado) == true)
            {
                byte[] textoCodificado = RLELibreria.Codificar(DirecciónArchivoOriginal);
                byte[] textoDecodificado = RLELibreria.Decodificar(textoCodificado);
                RLELibreria.EscrituraArchivoDecodificado(textoDecodificado, DirecciónArchivoOriginal, InfoArchivo.Name);
                Console.WriteLine("Archivo descomprimido exitosamente.");

            }
            Console.ReadLine();
        }
    }
}
