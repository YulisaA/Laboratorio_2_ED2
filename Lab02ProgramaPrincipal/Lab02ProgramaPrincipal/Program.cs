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


            Console.WriteLine("SERIE 3: Seleccione un metodo para comprención de datos : 1) RLE / 2) Huffman");
            string seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case ("1"):
                    {
                        Run_Lenght_Encode RLELibreria = new Run_Lenght_Encode();
                        Estadísticas obj1 = new Estadísticas();
                        Validaciones validar = new Validaciones();
                        string textoIngresado = "";


                        string DirecciónArchivoComprimido = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Codificado.comp";

                        //Obtener comandos
                        Console.WriteLine("Ingrese el comando y la ruta del archivo:");
                        textoIngresado = Console.ReadLine();
                        string DirecciónArchivoOriginal = validar.ObtenerDirección(textoIngresado);

                        //Comprimir
                        if (validar.validarComprimir(textoIngresado) == true)
                        {
                            byte[] textoCodificado = RLELibreria.Codificar(DirecciónArchivoOriginal);
                            RLELibreria.EscrituraArchivoCodificado(textoCodificado);
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
                            RLELibreria.EscrituraArchivoDecodificado(textoDecodificado, DirecciónArchivoOriginal);
                            Console.WriteLine("Archivo descomprimido exitosamente.");

                        }
                        Console.ReadLine();
                    }
                    break;

                case ("2"):
                    {
                        Utilidades Huffman = new Utilidades();
                        Estadísticas obj2 = new Estadísticas();
                        Console.WriteLine("Ingrese la Ruta del Archivo");
                        string RutaOriginal = Console.ReadLine();
                        DirectoryInfo InfoArchivo = new DirectoryInfo(RutaOriginal);


                        string DirecciónArchivoComprimidoHuffman = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CodificadoHuffman.comp";
                        string DirecciónArchivoDescomprimidoHuffman = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+InfoArchivo.Name+"DecodificadoHuffman.comp";

                        Huffman.Codificar(RutaOriginal, DirecciónArchivoComprimidoHuffman);
                        Huffman.Decodificar(DirecciónArchivoDescomprimidoHuffman);

                        System.IO.FileInfo infoOriginal = new System.IO.FileInfo(RutaOriginal);
                        System.IO.FileInfo infoComprimido = new System.IO.FileInfo(DirecciónArchivoComprimidoHuffman);

                        Console.WriteLine("*Tamaño original: " + infoOriginal.Length);
                        Console.WriteLine("*Tamaño final: " + infoComprimido.Length);
                        Console.WriteLine("*Ratio de Compresión: " + obj2.RatioDeCompresion(DirecciónArchivoComprimidoHuffman, RutaOriginal));
                        Console.WriteLine("*Factor de Compresión: " + obj2.FactorDeCompresion(DirecciónArchivoComprimidoHuffman, RutaOriginal));
                        Console.WriteLine("*Porcentaje ahorrado: " + obj2.PorcentajeAhorrado(DirecciónArchivoComprimidoHuffman, RutaOriginal) + " %");


                        Console.ReadLine();


                    }
                    break;
                default:
                    Console.WriteLine("SELECCIONE UNA DE LAS DOS OPCIONES DADAS");
                    break;
            }
           
        }
    }
}
