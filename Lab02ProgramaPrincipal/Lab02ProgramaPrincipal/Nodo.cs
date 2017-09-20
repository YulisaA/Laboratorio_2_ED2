using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02ProgramaPrincipal
{
    [Serializable()]
    public class Nodo
    {

        public char caracter { get; set; }
        public Nodo izq { get; set; }
        public Nodo derecho { get; set; }
        public int frecuencia { get; set; }

        public override string ToString()
        {
            return caracter + " " + frecuencia + " ";
        }

        public List<bool> AgregarCeroOUno(char Caracter, List<bool> texto)
        {
            if (derecho == null && izq == null)
            {
                if (Caracter.Equals(this.caracter))
                {
                    return texto;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> Izquierdo = null;
                List<bool> Derecho = null;

                if (izq != null)
                {
                    List<bool> rutaIzquierdo = new List<bool>();
                    rutaIzquierdo.AddRange(texto);
                    rutaIzquierdo.Add(false);

                    Izquierdo = izq.AgregarCeroOUno(Caracter, rutaIzquierdo);


                }
                if (derecho != null)
                {
                    List<bool> rutaDerecho = new List<bool>();
                    rutaDerecho.AddRange(texto);
                    rutaDerecho.Add(true);
                    Derecho = derecho.AgregarCeroOUno(Caracter, rutaDerecho);


                }
                if (Izquierdo != null)
                {
                    return Izquierdo;
                }
                else
                {
                    return Derecho;
                }

            }
        }
    }
}
