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
        //Logger logger = LogManager.GetCurrentClassLogger();

        internal static void ConvertImage(string path,string nameofresuldetfile)
        {                    
            try
            {
                using (Bitmap bitmap = new Bitmap(path))
                {
                    bitmap.Save(nameofresuldetfile, ImageFormat.Jpeg);
                    //logger.Info("Файл успешно создан");
                }               
            }
            catch (Exception ex)
            {
                //logger.Error("Ошибка конвертация графического файла - " + ex.ToString());
            }      
        }

    }
}
