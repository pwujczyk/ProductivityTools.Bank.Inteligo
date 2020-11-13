using ProductivityTools.BankAccounts.Contract;
using ProductivityTools.SimpleHttpPostClient;
using System;
using System.Threading.Tasks;

namespace ProductivityTools.Bank.Inteligo.Caller
{
    public class HttpCaller
    {
        private readonly HttpPostClient client;

        public HttpCaller()
        {
            client = new HttpPostClient();
            //client.SetBaseUrl("https://localhost:44306");
            client.SetBaseUrl("https://localhost:9208");
        }

        public void SaveBasicData(BasicData basicData)
        {
            var result1 = client.PostAsync<object>(EndpointNames.AccountControllerName, EndpointNames.BasicDataMethodName, basicData);
        }

    }
}
