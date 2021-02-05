using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;
using WpfAppUi_Entities.Interface;

namespace WpfAppUi_Infra.Repository
{
    public class ListPropertyResponseObjRepo : IListPropertyResponseObjRepo
    {

        string StrUri = "http://localhost:5000/";
        //Get All list
        public async Task<IEnumerable<ListPropertyResponseObj>> GetLists()
        {
            List<ListPropertyResponseObj> listPropertyResponseObj = new List<ListPropertyResponseObj>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                var response = new HttpResponseMessage();
                response = await client.GetAsync("api/ListProperty/GetList").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    listPropertyResponseObj = JsonConvert.DeserializeObject<List<ListPropertyResponseObj>>(result);
                    response.Dispose();
                }
            }
            return listPropertyResponseObj;
        }

        //Insert new  List
        public async Task<string> InsertList(ListPropertyResponseObj ListPropertyResponseObj)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();

                resp = await client.PostAsJsonAsync("api/ListProperty/InsertList", ListPropertyResponseObj).ConfigureAwait(false);
                response = resp.StatusCode.ToString();
                resp.Dispose();
            }
            return response;
        }

        //Update List
        public async Task<string> UpdateList(ListPropertyResponseObj ListPropertyResponseObj)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();
                resp = await client.PutAsJsonAsync("api/ListProperty/UpdateList", ListPropertyResponseObj).ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;

        }

        //Delete List
        public async Task<string> Deletelist(int ListID)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/");
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();
                resp = await client.DeleteAsync($"api/ListProperty/DeleteList/{ListID}").ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;
        }
    }
}

