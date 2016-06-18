using CapaDatos;
using System;

namespace CapaNegocio
{
    public class NConexion
    {
        public static String ChequearConexion()
        {
            return new DConexion().ChequearConexion();
        }
    }
}