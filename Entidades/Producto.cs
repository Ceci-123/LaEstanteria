using System;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        private string codigoDeBarra;
        private string marca;
        private float precio;

        public Producto(string codigoDeBarra, string marca, float precio)
        {
            this.codigoDeBarra = codigoDeBarra;
            this.marca = marca;
            this.precio = precio;
        }

        public string GetMarca()
        {
            return this.marca;
        }

        public float GetPrecio()
        {
            return this.precio;
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            if (p1 is not null && p2 is not null)
            {
                return p1.marca == p2.marca && p1.codigoDeBarra == p2.codigoDeBarra;

            }
            else return false;
        }
        public static bool operator ==(Producto p, string marca)
        {
            if (p is not null && marca is not null)
            {
                return p.marca == marca;

            }
            else return false;
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        public static bool operator !=(Producto p, string marca)
        {
            return !(p == marca);
        }

        public static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Marca del producto: {p.marca} Precio del producto: {p.precio}") ;
            sb.AppendLine($"Codigo de barras: {p.codigoDeBarra}");
            return sb.ToString();
        }

        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra;
        }
    }
}
