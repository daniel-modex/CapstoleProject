using RestSharp;
using RestSharp.Authenticators;
using System;

namespace NotificationApi.Repository
{
    public class mailRepository
    {
        private readonly string _apiKey = "YOUR_API_KEY"; // Replace with your actual Mailgun API key
        private readonly string _domain = "sandbox61ddc2392bc4435db56f9261076bb176.mailgun.org"; // Replace with your Mailgun domain

        public RestResponse SendEmail(string toEmail, string subject, string messageBody)
        {
            RestClient client = new RestClient("https://api.mailgun.net/v3");

            RestRequest request = new RestRequest();
            request.AddParameter("domain", _domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandbox61ddc2392bc4435db56f9261076bb176.mailgun.org>");
            request.AddParameter("to", toEmail);
            request.AddParameter("subject", subject);
            request.AddParameter("text", messageBody);
            request.Method = Method.Post;

            return client.Execute(request);
        }
    }
}
