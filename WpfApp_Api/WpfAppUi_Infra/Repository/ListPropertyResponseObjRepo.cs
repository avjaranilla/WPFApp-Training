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

        /// <summary>
        /// http client setup.
        /// </summary>
        /// <param name="client"></param>
        public void ClientSetUp(HttpClient client)
        {
            string StrUri = "http://localhost:8080/";

            client.BaseAddress = new Uri(StrUri);
            client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Get all list.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListPropertyResponseObj>> GetLists()
        {
            List<ListPropertyResponseObj> listPropertyResponseObj = new List<ListPropertyResponseObj>();

            using (var client = new HttpClient())
            {
                ClientSetUp(client);

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

        /// <summary>
        /// Insert new list.
        /// </summary>
        /// <param name="ListPropertyResponseObj"></param>
        /// <returns></returns>
        public async Task<string> InsertList(ListPropertyResponseObj ListPropertyResponseObj)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                ClientSetUp(client);

                var resp = new HttpResponseMessage();
                resp = await client.PostAsJsonAsync("api/ListProperty/InsertList", ListPropertyResponseObj).ConfigureAwait(false);
                response = resp.StatusCode.ToString();
                resp.Dispose();
            }
            return response;
        }

        /// <summary>
        /// Update list.
        /// </summary>
        /// <param name="ListPropertyResponseObj"></param>
        /// <returns></returns>
        public async Task<string> UpdateList(ListPropertyResponseObj ListPropertyResponseObj)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                ClientSetUp(client);

                var resp = new HttpResponseMessage();
                resp = await client.PutAsJsonAsync("api/ListProperty/UpdateList", ListPropertyResponseObj).ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;

        }

        /// <summary>
        /// Delete list.
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public async Task<string> Deletelist(int ListID)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                ClientSetUp(client);

                var resp = new HttpResponseMessage();
                resp = await client.DeleteAsync($"api/ListProperty/DeleteList/{ListID}").ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;
        }


     
    }
}

