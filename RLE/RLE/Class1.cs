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


        public byte[] Codificar(string aDireccion)
        {
            try
            {

                using (var Archivo = new FileStream(aDireccion, FileMode.Open, FileAccess.Read))
                {
                    using (var LecturaBytes = new BinaryReader(Archivo))
                    {
                        byte[] BytesLeidos = new byte[Archivo.Length];
                        BytesLeidos = LecturaBytes.ReadBytes(Convert.ToInt32(Archivo.Length));

                        List<byte> BytesEnlistados = new List<byte>();
                        byte a = 0;
                        int conteo = 0;
                        byte CanditaddeBytes;



                        for (int i = 0; i < BytesLeidos.Length; i++)
                        {
                            if (i == 0)
                            {
                                a = BytesLeidos[i];
                                conteo = 1;
                            }
                            else
                            {
                                if (a == BytesLeidos[i])
                                {
                                    conteo++;
                                }
                                else
                                {
                                    if (conteo > 255)
                                    {
                                        for (int n = 0; n < conteo / 255; n++)
                                        {
                                            CanditaddeBytes = Convert.ToByte(255);
                                            BytesEnlistados.Add(CanditaddeBytes);
                                            BytesEnlistados.Add(BytesLeidos[i]);
                                        }

                                        CanditaddeBytes = Convert.ToByte(conteo % 255);
                                        BytesEnlistados.Add(a);
                                        BytesEnlistados.Add(BytesLeidos[i]);
                                        a = BytesLeidos[i];
                                        conteo = 1;
                                    }
                                    else
                                    {
                                        CanditaddeBytes = Convert.ToByte(conteo);
                                        BytesEnlistados.Add(CanditaddeBytes);
                                        BytesEnlistados.Add(a);
                                        a = BytesLeidos[i];
                                        conteo = 1;
                                    }
                                }

                            }
                            if (i == BytesLeidos.Length - 1)
                            {
                                CanditaddeBytes = Convert.ToByte(conteo);
                                BytesEnlistados.Add(CanditaddeBytes);
                                BytesEnlistados.Add(BytesLeidos[i]);
                            }

                        }
                        return BytesEnlistados.ToArray();
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Problema en Codificar RLE:" + e.Message);
                return null;
            }
        }
        public byte[] Decodificar(byte[] textoCodificado)
        {
            List<byte> BytesDecodificados = new List<byte>();
            try
            {

                for (int i = 0; i < textoCodificado.Length; i = i + 2)
                {
                    int Evaluador = Convert.ToInt32(textoCodificado[i]);
                    while (Evaluador > 0)
                    {
                        BytesDecodificados.Add(textoCodificado[i + 1]);
                        Evaluador--;
                    }
                }

                return BytesDecodificados.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("Probelma en Descompr in RLD:" + e.Message);
                return null;
            }
        }


        public void EscrituraArchivoCodificado(byte[] texto)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var outputFile = new FileStream(ruta+"\\Codificado.rlex", FileMode.Append))
            {
                using (var writer = new BinaryWriter(outputFile, Encoding.ASCII))
                {
                    foreach (var item in texto)
                    {
                        writer.Write(item);
                    }
                }
            }
        }


        public void EscrituraArchivoDecodificado(byte[] textoCod, string Ruta)
        {
            DirectoryInfo Extencion = new DirectoryInfo(Ruta);
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var outputFile = new FileStream(ruta+"\\Decodificado.rlex"+ Extencion.Extension, FileMode.Append))
            {
                using (var writer = new BinaryWriter(outputFile, Encoding.ASCII))
                {
                    foreach (var item in textoCod)
                    {
                        writer.Write(item);
                    }
                }
            }
        }

    }
}
