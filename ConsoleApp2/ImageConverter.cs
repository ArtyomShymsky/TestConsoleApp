using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ImageConverter
    {

        internal static void ConvertImage(string path,string nameofresuldetfile)
        {                    
            try
            {
                using (Bitmap bitmap = new Bitmap(path))
                {
                    bitmap.Save(nameofresuldetfile, ImageFormat.Jpeg);
                }               
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при конвертации изображения" + ex.ToString());
            }      
        }

    }
}
