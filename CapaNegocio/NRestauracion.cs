using CapaDatos;
using System;

namespace CapaNegocio
{
    public class NRestauracion
    {
        public static String GenerarBackUp()
        {
            return new DRestauracion().GenerarBackUp();
        }

        public static String RestaurarBackUp(String parNombreArchivo)
        {
            return new DRestauracion().RestaurarBackUp(parNombreArchivo);
        }
    }
}