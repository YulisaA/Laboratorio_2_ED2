using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab02ProgramaPrincipal
{
    class Estadísticas
    {
        public double RatioDeCompresion(string DireccionArchivoComprimido, string DireccionArchivoOriginal)
        {
            double RatioFormula;

            FileInfo archivoComprimido = new FileInfo(DireccionArchivoComprimido);
            double tamañoArchivoComprimido = archivoComprimido.Length;

            FileInfo archivoOriginal = new FileInfo(DireccionArchivoOriginal);
            double tamañoArchivoOriginal = archivoOriginal.Length;

            RatioFormula = (tamañoArchivoComprimido / tamañoArchivoOriginal);

            return RatioFormula;
        }

        public double FactorDeCompresion(string DireccionArchivoComprimido, string DireccionArchivoOriginal)
        {
            double FactorFormula;

            FileInfo archivoComprimido = new FileInfo(DireccionArchivoComprimido);
            double tamañoArchivoComprimido = archivoComprimido.Length;

            FileInfo archivoOriginal = new FileInfo(DireccionArchivoOriginal);
            double tamañoArchivoOriginal = archivoOriginal.Length;

            FactorFormula = (tamañoArchivoOriginal / tamañoArchivoComprimido);

            return FactorFormula;
        }

        public double PorcentajeAhorrado(string DireccionArchivoComprimido, string DireccionArchivoOriginal)
        {
            double FactorFormula;

            FileInfo archivoComprimido = new FileInfo(DireccionArchivoComprimido);
            double tamañoArchivoComprimido = archivoComprimido.Length;

            FileInfo archivoOriginal = new FileInfo(DireccionArchivoOriginal);
            double tamañoArchivoOriginal = archivoOriginal.Length;

            FactorFormula = ((tamañoArchivoOriginal - tamañoArchivoComprimido) / tamañoArchivoOriginal) * 100;

            return FactorFormula;
        }
    }
}
