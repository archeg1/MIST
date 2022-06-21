using MIST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MIST
{
    public class EmployeesService
    {
        const string Url = "http://192.168.0.181:5000/api/employees"; // обращайте внимание на конечный слеш
        // настройки для десериализации для нечувствительности к регистру символов

        JsonSerializerSettings options = new JsonSerializerSettings()
        {
            Converters = { new EmployeeConverter() }
        };

// настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех работников
        public async Task<object> Get()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<IEmployee>>(result, options);
        }

        // добавляем одного работника
        public async Task<IEmployee> Add(IEmployee employee)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(employee),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseStr = await response.Content.ReadAsStringAsync();

            var resultObject = JsonConvert.DeserializeObject<IEmployee>(responseStr, options);

            return resultObject;
        }
        // обновляем работника
        public async Task<IEmployee> Update(IEmployee employee)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(employee),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<IEmployee>(await response.Content.ReadAsStringAsync(), options);
        }

        // удаляем работника
        public async Task<IEmployee> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/"+id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var resultObject = JsonConvert.DeserializeObject<IEmployee>(
                await response.Content.ReadAsStringAsync(), options);

            return resultObject;
        }
    }
}
