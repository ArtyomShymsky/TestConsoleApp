using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Base64Converter
    {
        
        /// <summary>
       /// Преобразование изображения в строку Base64
       /// </summary>
       /// <param name="image">целевое изображение</param>
       /// <returns>строка Base64</returns>
        public static string ImageToBase64(Bitmap image)
        {
            try
            {
                //проверяем параметр
                if (image == null)
                {
                    throw new ArgumentException($"{nameof(image)} ");
                }

                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка преобразования изображения в строку "+ex.ToString());
            }

            return null;


           
        }


    }
}
