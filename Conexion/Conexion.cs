using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using dominio;
using Conexion2;

namespace Conexion2

{
    public class Conexion
    {
    public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();

            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server = .\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, Precio, C.Descripcion TipoCategoria, M.Descripcion TipoMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca And A.IdCategoria = C.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                   

                    aux.Id = (int)lector["Id"];
                    aux.Codigo = lector["Codigo"].ToString();
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Idmarca = (int)lector["IdMarca"];
                    aux.Idcategoria = (int)lector["IdCategoria"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Descripcion = (string)lector["TipoMarca"];
                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.NombreCategoria = (string)lector["TipoCategoria"];
                    
                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}