using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02ProgramaPrincipal
{
    [Serializable()]
    class Utilidades
    {
        BitArray textoEnBits;

        ArbolBinario huffmanArbol;
        String Final = "";

        public void CrearArbol(string ruta)
        {
            System.IO.StreamReader reader;

            reader = new System.IO.StreamReader(ruta, System.Text.Encoding.UTF8);
            String empty = reader.ReadToEnd();

            byte[] bytes = Encoding.Default.GetBytes(reader.ReadToEnd());
            Final = empty;
        }

        public void EscribirArchivoKeyValue()
        {
            var list = huffmanArbol.Frecuencias.ToList();


            foreach (KeyValuePair<char, int> element in list.OrderBy(i => i.Value))
            {
                Console.Write("Caracter = {0}, Frecuencia = {1}", element.Key, element.Value);
                Console.WriteLine("");
            }

        }

        public void CodificarTexto(String texto, string rutaCodificado)
        {
            BitArray textoCodificado = huffmanArbol.Encode(texto);
            textoEnBits = textoCodificado;

            StringBuilder resultString = new StringBuilder();
            String result = "Encode: " + System.Environment.NewLine;
            resultString.AppendLine(result);
            StringBuilder sb = new StringBuilder();

            foreach (bool bit in textoCodificado)
            {

                sb.Append(string.Format((bit ? 1 : 0) + ""));
            }

            Console.WriteLine("");
            Console.WriteLine("El archivo fue comprimido exitosamente.");
            EscrituraArchivoCodificado(sb.ToString(), rutaCodificado);
        }

        public void EscrituraArchivoCodificado(string textoCod, string rutaCodfiicado)
        {
            using (StreamWriter outputFile = new StreamWriter(rutaCodfiicado, true))
            {
                outputFile.WriteLine(textoCod);
            }

        }

        public void Codificar(string ruta, string rutaCodificado)
        {

            CrearArbol(ruta);
            huffmanArbol = new ArbolBinario();
            huffmanArbol.Agregar(Final);
            EscribirArchivoKeyValue();

            CodificarTexto(Final, rutaCodificado);

        }
        public void Decodificar(string rutaDecodificado)
        {
            if (textoEnBits != null)
            {
                String resultado = huffmanArbol.Decodificar(textoEnBits);

                Console.WriteLine("");

                EscrituraArchivoDecodificado(resultado, rutaDecodificado);
                Console.WriteLine("El archivo fue descomprimido exitosamente.");
            }
            else if (textoEnBits == null)
            {
                Console.WriteLine("Error al codificar.");
            }
        }

        public void EscrituraArchivoDecodificado(string resultado, string rutaDecodificado)
        {
            using (StreamWriter outputFile = new StreamWriter(rutaDecodificado, true))
            {
                outputFile.WriteLine(resultado);
            }

        }
    }
}
