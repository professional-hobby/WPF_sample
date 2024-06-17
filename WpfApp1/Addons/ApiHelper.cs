using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Addons
{
    public static class ApiHelper
    {
        static HttpClient httpClient = new HttpClient();

        //  const string Address = "https://localhost:44335/api/";
          const string Address = "https://nicelabel.ambrovision.eu/api/";


        public static async Task<LoginResponseModel> Login(LoginRequestModel LoginData)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(LoginData.UserName + LoginData.Password);

            SHA512 encryptor = SHA512.Create();

            LoginRequestInternalModel internalModel = new LoginRequestInternalModel(LoginData.UserName, BitConverter.ToString(encryptor.ComputeHash(bytes)));

            string response = await callApi("Login", JsonConvert.SerializeObject(internalModel));

            return (LoginResponseModel)JsonConvert.DeserializeObject(response, typeof(LoginResponseModel));
        }

        public static async Task<RegisterResponseModel> Register(RegisterRequestModel LoginData)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(LoginData.UserName + LoginData.Password);

            SHA512 encryptor = SHA512.Create();

            RegisterRequestInternalModel internalModel = new RegisterRequestInternalModel(LoginData.UserName, BitConverter.ToString(encryptor.ComputeHash(bytes)));

            string response = await callApi("Register", JsonConvert.SerializeObject(internalModel));

            return (RegisterResponseModel)JsonConvert.DeserializeObject(response, typeof(RegisterResponseModel));
        }

        public static async Task<AddQuantityResponseModel> AddQuantity(AddQuantityRequestModel Data)
        {
            string response = await callApi("AddQuantity", JsonConvert.SerializeObject(Data));

            return (AddQuantityResponseModel)JsonConvert.DeserializeObject(response, typeof(AddQuantityResponseModel));
        }

        private static async Task<string> callApi(string Action, string Data)
        {
            StringContent stringContent = new StringContent(Data, Encoding.UTF8, "application/json");
            stringContent.Headers.TryAddWithoutValidation("allow", "application/json");

            HttpResponseMessage httpResponse = await httpClient.PostAsync(Address + Action, stringContent);

            string answer;
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                byte[] responseBinary=await httpResponse.Content.ReadAsByteArrayAsync();

                answer = Encoding.UTF8.GetString(responseBinary);
            }
            else
            {
                answer = "";
            }

            return answer;
        }
    }
}
