using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> listaArticulos = new List<Articulo>();
            try
            {
                accesoDatos.SetearConsulta(@"SELECT AR.Id, AR.Codigo as Código, AR.Nombre, AR.Descripcion , AR.Precio, AR.IdMarca, MA.Descripcion as Marca, AR.IdCategoria, CA.Descripcion as Categoria, AR.ImagenUrl
                                             FROM ARTICULOS AR 
                                             INNER JOIN MARCAS MA on AR.IdMarca = MA.Id
                                             INNER JOIN CATEGORIAS CA on AR.IdCategoria = CA.Id
                                             WHERE AR.Precio >= 0"); //La condicion del Where es porque la baja logica deja los articulos con precio negativos inactivos.
                accesoDatos.EjecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.Codigo = (string)accesoDatos.Lector["Código"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)accesoDatos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)accesoDatos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)accesoDatos.Lector["Categoria"];

                    if (!(accesoDatos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];

                    listaArticulos.Add(aux);
                }
                return listaArticulos;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
        public void Agregar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                string consulta = @"INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenURL, Precio)
                                    VALUES (@Codigo, @Nombre , @Descripcion , @IdMarca , @IdCategoria , @urlImagen , @Precio)";

                accesoDatos.SetearConsulta(consulta);

                accesoDatos.SetearParametro("@Codigo", articulo.Codigo);
                accesoDatos.SetearParametro("@Nombre", articulo.Nombre);
                accesoDatos.SetearParametro("@Descripcion", articulo.Descripcion);
                accesoDatos.SetearParametro("@IdMarca", articulo.Marca.Id);
                accesoDatos.SetearParametro("@IdCategoria", articulo.Categoria.Id);
                accesoDatos.SetearParametro("@urlImagen", articulo.ImagenUrl);
                accesoDatos.SetearParametro("@Precio", articulo.Precio);

                accesoDatos.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            { 
                accesoDatos.CerrarConexion();
            }

        }
        public void Modificar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                string consulta = @"UPDATE ARTICULOS 
                                    SET 
                                        Codigo = @codigo, 
	                                    Nombre =  @nombre, 
	                                    Descripcion = @descripcion, 
	                                    IdMarca = @idMarca, 
                                        IdCategoria = @idCategoria, 
	                                    ImagenUrl = @imagenURL, 
	                                    Precio = @precio
                                    WHERE Id = @id";

                accesoDatos.SetearConsulta(consulta);

                accesoDatos.SetearParametro("@codigo", articulo.Codigo);
                accesoDatos.SetearParametro("@nombre", articulo.Nombre);
                accesoDatos.SetearParametro("@descripcion", articulo.Descripcion);
                accesoDatos.SetearParametro("@idMarca", articulo.Marca.Id);
                accesoDatos.SetearParametro("@idCategoria", articulo.Categoria.Id);
                accesoDatos.SetearParametro("@imagenURL", articulo.ImagenUrl);
                accesoDatos.SetearParametro("@precio", articulo.Precio);
                accesoDatos.SetearParametro("@Id", articulo.Id);

                accesoDatos.EjecutarAccion();
            }
            catch (Exception)
            { 
                throw;
            }
            finally { 
                accesoDatos.CerrarConexion();
            }
        }

        public void EliminarFisico (int id) //Eliminado fisico, elimina completamente de BD. 
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                string consulta = "DELETE FROM ARTICULOS Where Id = @Id";
                accesoDatos.SetearConsulta(consulta);
                accesoDatos.SetearParametro("Id",id);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally{
                accesoDatos.CerrarConexion();
            }
        }

        public void EliminarLogico(int id) { //Definimos como regla de negocio que el eliminado lógico sera dejando los precios de los articulos en negativo, ya que no se nos permitia modificar la estructura de la BD. 

            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                string consulta = "Update ARTICULOS set Precio = (-Precio) Where Id = @Id";
                accesoDatos.SetearConsulta(consulta);
                accesoDatos.SetearParametro("Id", id);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
    }

    //Nos falta agregar un metodo filtrar, pero, como no especifica que criterios para filtrar pide. Probablemente, reutilicemos el metodo listar, para que pueda listar por crierios. 
    //A definir segun pantalla. 
}
