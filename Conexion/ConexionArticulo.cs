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
                datos.setarConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, Precio, C.Descripcion TipoCategoria,C.Id IdCategoria , M.Descripcion TipoMarca, M.Id IdMarca, I.ImagenUrl UrlImagen from ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I where M.Id = A.IdMarca And A.IdCategoria = C.Id AND I.Id = (SELECT MIN(Id) FROM IMAGENES WHERE IdArticulo = A.Id);");
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
                    aux.Imagen = new Imagen();
                    aux.Imagen.UrlImagen = (string)datos.Lector["UrlImagen"];

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
            AccesoDatos datos2 = new AccesoDatos();

            try
            {
                datos.setarConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) " +
                     "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria); SELECT CAST(SCOPE_IDENTITY() AS int);");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.Idmarca);
                datos.setearParametro("@IdCategoria", nuevo.Idcategoria);
                
                string url = string.IsNullOrWhiteSpace(nuevo?.Imagen?.UrlImagen)
                    ? "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png"
                    : nuevo.Imagen.UrlImagen.Trim();


                datos.ejecutarLectura();

                //LEO EL ID DEL NUEVO ARTICULO
                int idArticulo = 0;
                if (datos.Lector.Read())
                    idArticulo = datos.Lector.GetInt32(0);
                datos.cerrarConexion();

                //Seteo la imagen en la tabla Imagenes
                datos2.setarConsulta(
                    "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)"
                );
                datos2.setearParametro("@ImagenUrl", url);
                datos2.setearParametro("@IdArticulo", idArticulo);
                datos2.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                datos.cerrarConexion();
                datos2.cerrarConexion();
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

        public List<Articulo> filtroAvanzado(string campo, string criterio, string filtro, int precioMinimo, int precioMaximo)
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos BaseDeDatos = new AccesoDatos();

            try
            {

                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, Precio, C.Descripcion TipoCategoria,C.Id IdCategoria , M.Descripcion TipoMarca, M.Id IdMarca, I.ImagenUrl UrlImagen from ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I where M.Id = A.IdMarca And A.IdCategoria = C.Id AND I.Id = (SELECT MIN(Id) FROM IMAGENES WHERE IdArticulo = A.Id) AND ";

                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Categoría":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                //Agrego los precios a la consulta
                consulta += " AND Precio >= " + precioMinimo + " AND Precio <= " + precioMaximo;

                BaseDeDatos.setarConsulta(consulta);
                BaseDeDatos.ejecutarLectura();

                 while (BaseDeDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                   

                    aux.Id = (int)BaseDeDatos.Lector["Id"];
                    aux.Codigo = BaseDeDatos.Lector["Codigo"].ToString();
                    aux.Nombre = (string)BaseDeDatos.Lector["Nombre"];
                    aux.Descripcion = (string)BaseDeDatos.Lector["Descripcion"];
                    aux.Idmarca = (int)BaseDeDatos.Lector["IdMarca"];
                    aux.Idcategoria = (int)BaseDeDatos.Lector["IdCategoria"];
                    aux.Precio = (decimal)BaseDeDatos.Lector["Precio"];
                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Descripcion = (string)BaseDeDatos.Lector["TipoMarca"];
                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.NombreCategoria = (string)BaseDeDatos.Lector["TipoCategoria"];
                    aux.Imagen = new Imagen();
                    aux.Imagen.UrlImagen = (string)BaseDeDatos.Lector["UrlImagen"];

                    listaArticulos.Add(aux);
                }

                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
