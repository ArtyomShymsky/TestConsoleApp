using Newtonsoft.Json.Linq;
using NLog.Targets.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class HttpPost
    {

        public static JObject ResponseJson { get { return json; } set { json = value; } }
        static JObject? json = new JObject();
        private static readonly HttpClient client = new HttpClient();
        public static async Task<HttpResponseMessage> HttpPostReq(string Url, string Data)
        {
            StringContent content = new StringContent(Data);
            using var request = new HttpRequestMessage(HttpMethod.Post, Url);
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);
            string responseText = await response.Content.ReadAsStringAsync();
            json = JObject.Parse(responseText);
            return response;
        }


        //public static string POST(string Url, string Data)
        //{
        //    try
        //    {

        //        WebRequest req = WebRequest.Create(Url);
        //        req.Method = "POST";
        //        req.Timeout = 100000;
        //        req.ContentType = "application/x-www-form-urlencoded";
        //        req.Headers.Add("Accept-Language: ru-ru");

        //        byte[] sentData = Encoding.ASCII.GetBytes(Data);
        //        req.ContentLength = sentData.Length;
        //        Stream sendStream = req.GetRequestStream();
        //        sendStream.Write(sentData, 0, sentData.Length);
        //        sendStream.Close();

        //        //StreamReader sr;
        //        //HttpWebResponse response = req.GetResponse() as HttpWebResponse;
        //        //using (Stream responseStream = response.GetResponseStream())
        //        //{
        //        //    sr = new StreamReader(responseStream, Encoding.ASCII);
        //        //}

        //        WebResponse res = req.GetResponse();
        //        Uri u = res.ResponseUri;
        //        Stream ReceiveStream = res.GetResponseStream();
        //        StreamReader sr = new StreamReader(ReceiveStream, Encoding.ASCII);


        //        Char[] read = new Char[256];
        //        int count = sr.Read(read, 0, 256);
        //        string Out = String.Empty;
        //        while (count > 0)
        //        {
        //            String str = new String(read, 0, count);
        //            Out += str;
        //            count = sr.Read(read, 0, 256);
        //        }
        //        return Out;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ошибка при выполнее post запроса" + ex.ToString());
        //    }
        //    return null;
      
        //}

    }
}
