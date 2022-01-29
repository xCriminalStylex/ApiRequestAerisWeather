using RestSharp;
using System;
using System.Net;
using static System.Net.WebRequestMethods;
using System.IO;
using Newtonsoft.Json;
using ApiRequestAerisWeather.ResponseWeatherAPI;

namespace ApiRequestAerisWeather
{
    public class Program
    {
        static void Main(string[] args)
{

            string client_id = "56PkDc87dkjtbvHTmU8ot";
            string client_secret = "ECHkpRVzIOeCtB4RFy7I5C8ct6OmWe2IxmlfKYaF";
            //string url = $"http://api.aerisapi.com/observations/Dnipro,Ukraine?client_id={client_id}&client_secret={client_secret}&limit=1";
            string url = $"http://api.aerisapi.com/observations/Paris,France?client_id={client_id}&client_secret={client_secret}&limit=1";


            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            System.Threading.Thread.Sleep(2000);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            System.Threading.Thread.Sleep(2000);
            string response;
            using(StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            ResponseWeather responseWeather = JsonConvert.DeserializeObject<ResponseWeather>(response);

            Console.WriteLine($"Succes       :{responseWeather.success}");
            Console.WriteLine($"Id           :{responseWeather.response.id}");
            Console.WriteLine($"Name         :{responseWeather.response.place.name}");
            Console.WriteLine($"City         :{responseWeather.response.place.city}");
            Console.WriteLine($"Country      :{responseWeather.response.place.country}");
            Console.WriteLine($"DateTimeISO  :{responseWeather.response.ob.dateTimeISO}");
            Console.WriteLine($"Humidity     :{responseWeather.response.ob.humidity}");
            Console.WriteLine($"Temperature  :{responseWeather.response.ob.tempC} C");
            Console.WriteLine($"Temperature  :{responseWeather.response.ob.tempF} F");
            Console.WriteLine($"Visibility   :{responseWeather.response.ob.visibilityKM} km");
            Console.WriteLine($"Weather      :{responseWeather.response.ob.weatherShort}");
            Console.WriteLine($"WindSpeed    :{responseWeather.response.ob.windSpeedKPH} km/h");

        }
    }
}
