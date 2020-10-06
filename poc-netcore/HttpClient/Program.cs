using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            dikGaan();
            // WebClient webClient = new WebClient();
            // webClient.Headers.Set("Content-Type", "application/json");
            // string url = "http://localhost:5188/api/file";
            //
            // FileChecksum upload = new FileChecksum()
            // {
            //     MD5Checksum = "7C6E0803AE1FAE3DC33F111819065E54",
            //     SessionID = Guid.Parse("4669465e-208b-4895-977d-6f662154edf4"),
            //     TokenID = Guid.Parse("90491416-5be5-4273-a99d-97a31e64a078")
            // };
            //
            // var uploadId = webClient.UploadString($"{url}/startupload", JsonConvert.SerializeObject(upload));
            // uploadId = JsonConvert.DeserializeObject<string>(uploadId);
            //
            // Console.WriteLine(uploadId);
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebrequest.sendchunked?view=netcore-3.1
        static void dikGaan()
        {
            // A new 'HttpWebRequest' object is created.
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5188/api/file/binary");
            myHttpWebRequest.SendChunked = true;
            // 'TransferEncoding' property is set to 'gzip'.
          //  myHttpWebRequest.TransferEncoding = "gzip, deflate, br";

          //  byte[] gb = File.ReadAllBytes(@"C:\Users\Niels\Downloads\1gb.test");
          var fileStream = File.OpenRead(@"C:\Users\Niels\Downloads\ffxivsetup_ft.exe");

          // 'Method' property of 'HttpWebRequest' class is set to POST.
            myHttpWebRequest.Method = "POST";
            // 'ContentType' property of the 'HttpWebRequest' class is set to "application/x-www-form-urlencoded".
            myHttpWebRequest.ContentType = "application/json";
            // 'ContentLength' property is set to Length of the data to be posted.
            myHttpWebRequest.ContentLength = fileStream.Length;

            Stream requestStream = myHttpWebRequest.GetRequestStream();

            int bytesRead;
            byte[] buffer = new byte[1024*1024];
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                byte[] readBuffer = buffer.Take(bytesRead).ToArray(); 
                requestStream.Write(readBuffer, 0,readBuffer.Length);
            }
            Console.WriteLine("\nData has been posted to the Uri\n\nPlease wait for the response..........");

            // The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            // Displaying the contents of the page to the console
            Stream streamResponse = myHttpWebResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);
            Console.WriteLine("\nThe contents of the HTML page are :  ");

            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                Console.WriteLine(outputData);
                count = streamRead.Read(readBuff, 0, 256);
            }
            // Release the response object resources.
            streamRead.Close();
            streamResponse.Close();
            myHttpWebResponse.Close();
        }
    }

    public class FileChecksum
    {
        public Guid SessionID { get; set; }
        public Guid TokenID { get; set; }

        public string MD5Checksum { get; set; }
    }
}
