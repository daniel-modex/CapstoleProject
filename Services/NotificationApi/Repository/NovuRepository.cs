using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace NotificationApi.Repository
{
    

    public class NovuService
    {
        private readonly HttpClient _httpClient;
        private const string NovuApiUrl = "https://api.novu.co/v1/events/trigger";
        private const string NovuApiKey = "9aaebc3f3305d038856b75e525a267bb"; // Your Novu API Key

        // Constructor injects HttpClient
        public NovuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to trigger an event in Novu (sending a welcome email)
        public async Task TriggerEventAsync(string subscriberId, string email, string phone)
        {
            var payload = new
            {
                name = "welcome-onboarding-email", // Event name
                to = new
                {
                    subscriberId = subscriberId, 
                    email = email,
                    phone = phone
                },
                payload = new
                {
                    teamImage = "https://images.spr.so/cdn-cgi/imagedelivery/j42No7y-dcokJuNgXeA0ig/dca73b36-cf39-4e28-9bc7-8a0d0cd8ac70/standalone-gradient2x_2/w=128,quality=90,fit=scale-down",
                    userImage = "https://react-email-demo-48zvx380u-resend.vercel.app/static/vercel-user.png",
                    arrowImage = "https://react-email-demo-bdj5iju9r-resend.vercel.app/static/vercel-arrow.png"
                },
                bridgeUrl = "https://5adb7dd7-e385-4f22-be5f-a1cfeea75a72.novu.sh/api/novu" // Optional bridge URL
            };

            // Create HTTP request message
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, NovuApiUrl)
            {
                Headers = { { "Authorization", $"ApiKey {NovuApiKey}" } },
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
            };

            // Send request
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                // Successfully triggered the event
                Console.WriteLine("Event triggered successfully.");
            }
            else
            {
                // Handle failure
                Console.WriteLine($"Failed to trigger event: {response.ReasonPhrase}");
            }
        }
    }

}
