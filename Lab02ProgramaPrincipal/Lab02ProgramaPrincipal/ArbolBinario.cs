using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab02ProgramaPrincipal
{

    [Serializable()]
    public class ArbolBinario : ISerializable
    {

        //elementos en el árbol binario
        public BitArray TextoCoficado;
        public List<Nodo> nodos = new List<Nodo>();
        public Nodo Raiz { get; set; }
        public Dictionary<char, int> Frecuencias = new Dictionary<char, int>();

        public ArbolBinario()
        {

        }
        public ArbolBinario(SerializationInfo texto, StreamingContext contexto)
        {
            TextoCoficado = (BitArray)texto.GetValue("bitArray", typeof(BitArray));
            Raiz = (Nodo)texto.GetValue("raiz", typeof(Nodo));
        }

        /// <summary>
        /// Implementación de la interfaz, convertir el texto a un formato diferente<bits></bits>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("bitArray", TextoCoficado);
            info.AddValue("raiz", Raiz);
        }
        public void Agregar(String data)
        {
            //Agregar las frecuencias de los caracteres
            for (int i = 0; i < data.Length; i++)
            {
                if (!Frecuencias.ContainsKey(data[i]))
                {
                    Frecuencias.Add(data[i], 0);
                }
                Frecuencias[data[i]]++;
            }

            //Char para el caracter, int para la frecuencia
            foreach (KeyValuePair<char, int> caracter in Frecuencias)
            {
                nodos.Add(new Nodo() { caracter = caracter.Key, frecuencia = caracter.Value });

            }
            while (nodos.Count > 1)
            {
                //Agregar nodos al arbol.
                List<Nodo> obtenerNodos = nodos.OrderBy(nodo => nodo.frecuencia).ToList<Nodo>();
                if (nodos.Count >= 1)
                {
                    //Se obtienen los dos más pequeños según su frecuencia.
                    List<Nodo> NodosObtenidos = obtenerNodos.Take(2).ToList<Nodo>();

                    Nodo padre = new Nodo() { caracter = '*', frecuencia = NodosObtenidos[0].frecuencia + NodosObtenidos[1].frecuencia, izq = NodosObtenidos[0], derecho = NodosObtenidos[1] };
                    nodos.Remove(NodosObtenidos[0]);
                    nodos.Remove(NodosObtenidos[1]);
                    nodos.Add(padre);
                }
                this.Raiz = nodos.FirstOrDefault();
            }

        }

        public bool VerificarSiEsHoja(Nodo nodo)
        {
            if (nodo.izq == null && nodo.derecho == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarVacio()
        {
            if (Raiz == null)
            {
                return true;
            }

            return false;
        }

        //Este método retorna el texto en bits.
        public System.Collections.BitArray Encode(string texto)
        {
            List<bool> textoCodificado = new List<bool>();
            for (int i = 0; i < texto.Length; i++)
            {
                if (this.Raiz != null)
                {
                    List<bool> caracteres = this.Raiz.AgregarCeroOUno(texto[i], new List<bool>());
                    textoCodificado.AddRange(caracteres);
                }
            }

            BitArray textoEnBits = new BitArray(textoCodificado.ToArray());
            return textoEnBits;
        }

        public string Decodificar(BitArray textoEnBits)
        {
            Nodo actual = this.Raiz;
            string strDecodificar = "";

            foreach (bool bit in textoEnBits)
            {
                if (bit)
                {
                    if (actual.derecho != null)
                    {
                        actual = actual.derecho;
                    }

                }
                else
                {
                    if (actual.izq != null)
                    {
                        actual = actual.izq;
                    }
                }

                if (VerificarSiEsHoja(actual))
                {
                    strDecodificar += actual.caracter;
                    actual = this.Raiz;
                }
            }
            return strDecodificar;
        }


    }

}

