using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Conexion
{
    public class ConexionArticulo
    {
        public List<Articulo> Listar()
        {
            List<Articulo>lista = new List<Articulo> ();
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                return lista;

            }

            catch(Exception ex) 
            {
                throw ex;
            }
        }

  
    }
}
