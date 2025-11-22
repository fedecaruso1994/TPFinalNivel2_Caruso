using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentacion
{
    class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> listaArticulos = new List<Articulo>();
            try
            {
                accesoDatos.SetearConsulta("SELECT Codigo, Nombre, Descripcion, Precio FROM ARTICULOS");
                accesoDatos.EjecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.Precio = (double)accesoDatos.Lector["Precio"];

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

    }
}
