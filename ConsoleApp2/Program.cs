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
    // imageadress = Console.ReadLine();
    //logger.Info("Веденный путь: " imageadress);

     imageadress = "F:\\dotNetCore\\TestConsoleApp\\ConsoleApp2\\file.png"; //Console.ReadLine();

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
//JObject jsonobj= new JObject();
HttpResponseMessage postresponse = new HttpResponseMessage();
try
{
    //string answer = HttpPost.POST(testhttpaddress, base64imagestring);
    //jsonobj = JObject.Parse(answer);
    postresponse  =  await HttpPost.HttpPostReq(testhttpaddress, base64imagestring);
   // jsonobj = JObject.Parse(postresponse.ToString());

}
catch (Exception ex)
{
    logger.Error("Ошибка post запроса " + ex.ToString());
}

try
{
    string jsonfile = AppDomain.CurrentDomain.BaseDirectory + "jsonfile.txt";

    //File.Create(jsonfile);
    File.AppendAllText(jsonfile, postresponse.ToString());

    //File.WriteAllText(jsonfile, postresponse.ToString());
    //using (FileStream fstream = new FileStream(jsonfile, FileMode.OpenOrCreate))
    //{
    //    fstream.Write(input, 0, input.Length);
    //}


    //using (StreamWriter file = File.CreateText(@jsonfile))
    //using (JsonTextWriter writer = new JsonTextWriter(file))
    //{
    //    jsonobj.WriteTo(writer);
    //}

}
catch (Exception ex)
{
    logger.Error("Ошибка post запроса " + ex.ToString());

}


