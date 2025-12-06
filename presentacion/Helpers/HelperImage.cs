using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion.Helpers
{
   public static class HelperImage
    {
        private const string PLACEHOLDER_IMG = "https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg";
        public static void CargarImagen(PictureBox pb, string url)
        {
            try
            {
                pb.Load(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
                pb.Load(PLACEHOLDER_IMG);
            }
        }
    }
}

