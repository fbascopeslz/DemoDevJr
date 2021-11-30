using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Validaciones;

namespace DemoDevJr.Utils
{
    public static class Utils
    {
        public static bool validarNumeroCelular(string celular)
        {
            return Validaciones.Validaciones.validarCelular(celular);
        }

        public static bool validarCedulaIdentidad(string ci)
        {
            return Validaciones.Validaciones.validarCI(ci);
        }
    }
}