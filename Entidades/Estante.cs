using System;
using System.Text;

namespace Entidades
{
    public class Estante
    {
        private Producto[] productos;
        private int ubicacionEstante;

        private Estante(int capacidad)
        {
            productos = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return this.productos;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ubicacion del estante: {e.ubicacionEstante} ");
            foreach (Producto item in e.productos)
            {
                sb.AppendLine(Producto.MostrarProducto(item));
            }

            sb.AppendLine("------------------------------");
            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            bool retorno = false;
            if (e is not null && p is not null)
            {
                foreach (Producto item in e.productos)
                {
                    if (item == p)
                    {
                        retorno = true;
                        break;
                    }
                }
            }



            return retorno;
        }
        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }
        public static bool operator +(Estante e, Producto p)
        {
            bool retorno = false;
            if (e is not null && p is not null)
            {
                int posicion = CalcularLibre(e);

                if (posicion >= 0 && NoEsta(e,p))
                {


                    e.productos[posicion] = p;
                    retorno = true;


                }
            }

            return retorno;

        }

        private static bool NoEsta(Estante e, Producto p)
        {
            bool retorno = false;
            if(e != p)
            {
                retorno = true;
            }
            return retorno;
        }

        private static int CalcularLibre(Estante e)
        {
            int retorno = -1;
            if (e is not null)
            {
                for (int i = 0; i < e.productos.Length; i++)
                {
                    if (e.productos[i] is null)
                    {
                        retorno = i;
                        break;
                    }
                }
            }


            return retorno;
        }

        public static Estante operator -(Estante e, Producto p)
        {
            Estante estanteRetorno = e;
            if (e is not null && p is not null)
            {
                if (!(e == p))
                {
                    for (int i = 0; i < e.productos.Length; i++)
                    {
                        if (e.productos[i] == p)
                        {
                            e.productos[i] = null;
                        }
                    }
                }
            }



            return e;
        }
    }
}
