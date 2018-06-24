using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebCalculator.Api.Client.Model;

namespace WebCalculator.Api.Client
{
    public class WebCalculatorClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<WebCalculatorClient> logger;

        public WebCalculatorClient(HttpClient client, ILogger<WebCalculatorClient> logger)
        {
            this.httpClient = client;
            this.logger = logger;
        }

        public async Task<CalculationResult> GetCalculationAsync(string expression)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/calculate/{expression}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<CalculationResult>();
                
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"An error occured connecting to the web-calculator api: {ex}");
                return new CalculationResult();
            }
        }
    }
}
