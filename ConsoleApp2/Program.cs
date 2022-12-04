// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System.Threading.Tasks;

Logger logger = LogManager.GetCurrentClassLogger();
string imageadress="";
string testhttpaddress = "https://httpbin.org/post";

Console.WriteLine("Введите адрес изображения");

try
{
    imageadress = Console.ReadLine();
    logger.Info("Веденный путь: " + imageadress);
    if (!File.Exists(imageadress))
    {

        throw new Exception("Указанного файла не существует или путь введен некорректно.");
    }    

}
catch(Exception ex)
{
    logger.Error("Некорректно введен путь к графическому файлу. "+ex.ToString());
}
try
{
    ImageConverter.ConvertImage(imageadress, "newimage.jpeg");
    logger.Info("Файл успешно создан");
}
catch (Exception ex)
{
    logger.Error("Ошибка конвертация графического файла - " + ex.ToString());
}

string base64imagestring="";

try
{
    base64imagestring = Base64Converter.ImageToBase64(new System.Drawing.Bitmap(AppDomain.CurrentDomain.BaseDirectory + "newimage.jpeg"));
    logger.Info("Строка Base64 создана");   
 
}
catch (Exception ex)
{
    logger.Error("Ошибка создания строки- " + ex.ToString());

}
HttpResponseMessage postresponse = new HttpResponseMessage();
try
{
    postresponse  =  await HttpPost.HttpPostReq(testhttpaddress, base64imagestring);

}
catch (Exception ex)
{
    logger.Error("Ошибка post запроса " + ex.ToString());
}

try
{
    string jsonfile = AppDomain.CurrentDomain.BaseDirectory + "jsonfile.txt";
    File.AppendAllText(jsonfile, postresponse.ToString());
    File.AppendAllText(jsonfile, HttpPost.ResponseJson.ToString());
    logger.Info(postresponse.ToString());
    logger.Info(HttpPost.ResponseJson.ToString());



}
catch (Exception ex)
{
    logger.Error("Ошибка post запроса " + ex.ToString());

}


