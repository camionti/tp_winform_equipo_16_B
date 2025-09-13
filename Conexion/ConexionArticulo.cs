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
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion,A.IdMarca AS IdMarca,A.IdCategoria AS IdCategoria,A.Precio, C.Descripcion AS TipoCategoria, M.Descripcion AS TipoMarca FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Idmarca = (int)datos.Lector["IdMarca"];
                    aux.Idcategoria = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Descripcion = (string)datos.Lector["TipoMarca"];
                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.NombreCategoria = (string)datos.Lector["TipoCategoria"];

                    lista.Add(aux);
                }

                return lista;

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public class ConexionMarca
        {
            public List<Marca> ListarMarcas()
            {
                List<Marca> lista = new List<Marca>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setarConsulta("SELECT Id, Descripcion FROM Marcas");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Marca aux = new Marca();
                        aux.IDMarca = (int)datos.Lector["Id"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                        lista.Add(aux);
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
        }

        public class ConexionCategoria
        {
            public List<Categoria> ListarCategorias()
            {
                List<Categoria> lista = new List<Categoria>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setarConsulta("SELECT Id, Descripcion FROM Categorias");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Categoria aux = new Categoria();
                        aux.IdCategoria = (int)datos.Lector["Id"];
                        aux.NombreCategoria = (string)datos.Lector["Descripcion"];

                        lista.Add(aux);
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }

        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) " +
                     "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria)");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.Idmarca);
                datos.setearParametro("@IdCategoria", nuevo.Idcategoria);

                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@IdMarca", articulo.Idmarca);
                datos.setearParametro("@IdCategoria", articulo.Idcategoria);
                datos.setearParametro("@Id", articulo.Id);



                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar (int id)
        {
            try
            {
                AccesoDatos datos= new AccesoDatos();
                datos.setarConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro ("@id", id);
                datos.ejecutarAccion ();

            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
    }
}
