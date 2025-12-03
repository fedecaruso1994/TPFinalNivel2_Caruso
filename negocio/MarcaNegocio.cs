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

    }
}

