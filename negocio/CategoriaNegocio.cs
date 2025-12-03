using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {

            AccesoDatos accesoDatos = new AccesoDatos();
            List<Categoria> listaCategorias = new List<Categoria>();

            try
            {
                accesoDatos.SetearConsulta("SELECT Id,Descripcion FROM CATEGORIAS");
                accesoDatos.EjecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    listaCategorias.Add(new Categoria
                    {
                        Id = (int)accesoDatos.Lector["Id"],
                        Descripcion = (string)accesoDatos.Lector["Descripcion"],
                    });
                }
                return listaCategorias;

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
}
