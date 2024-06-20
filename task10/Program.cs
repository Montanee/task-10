using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiKey = "YOUR_API_KEY"; // Замените YOUR_API_KEY на ваш собственный ключ API от OpenWeatherMap
        string city = "Moscow"; // Замените на название города, для которого хотите получить данные

        using (var client = new HttpClient())
        {
            try
            {
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Данные о погоде:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine("Не удалось получить данные о погоде. Код ошибки: " + response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ошибка при выполнении запроса: {e.Message}");
            }
        }
    }
}
