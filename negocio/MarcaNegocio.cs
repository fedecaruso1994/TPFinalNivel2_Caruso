using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {

            AccesoDatos accesoDatos = new AccesoDatos();
            List<Marca> listaMarcas = new List<Marca>();

            try
            {
                accesoDatos.SetearConsulta("SELECT Id, Descripcion FROM MARCAS");
                accesoDatos.EjecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    listaMarcas.Add(new Marca
                    {
                        Id = (int)accesoDatos.Lector["Id"],
                        Descripcion = (string)accesoDatos.Lector["Descripcion"],
                    });
                }
                return listaMarcas;

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

        public void Agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO MARCAS (Descripcion) VALUES (@desc)");
                datos.SetearParametro("@desc", nuevo.Descripcion);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}

