using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RLE
{
    public class Run_Lenght_Encode
    {
        public const char Espacio = ' ';

        public static string Codificar(string Direccion)
        {
            try
            {
                string Lectura = "";
                string Linea = "";
                StreamReader Archivo = new StreamReader(Direccion);

                while ((Lectura = Archivo.ReadLine()) != null)
                {
                    Linea = Linea + Lectura;
                }


                string TextoCodificado = string.Empty;
                int contador = 1;
                for (int i = 0; i < Linea.Length - 1; i++)
                {
                    if (Linea[i] == Linea[i+1] || i == Linea.Length-2)
                    {
                        if (Linea[i] == Linea[i+1]  && i== Linea.Length-2)
                        {
                            contador++;
                            TextoCodificado += contador + (char.IsNumber(Linea[i]) ? "" + Espacio : "") + Linea[i];
                        }
                        if (Linea[i] != Linea[i+1] && i == Linea.Length -2)
                        {
                            TextoCodificado += (char.IsNumber(Linea[i + 1]) ? "" + Espacio : "") + Linea[i + 1];
                            contador = 1;
                        }
                        else
                        {
                            contador++;
                        }

                    }
                }
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                
                using (StreamWriter EscritorTexto = new StreamWriter(ruta + @"\ RLE.rlex"))
                {
                    foreach (var lineas in TextoCodificado)
                    {
                        EscritorTexto.Write(lineas);
                    }
                }

                string mensaje = "Comprension finalizada";


                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
