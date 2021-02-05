
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
    public class ItemPropertyResponseObjRepo : IItemPropertyResponseObjRepo
    {

        string StrUri = "http://localhost:5000/";

        //Get All Items in a particular List
        public async Task<IEnumerable<ItemPropertyResponseObj>> GetItems(int ListID)
        {
            List<ItemPropertyResponseObj> ItemPropertyResponseObj = new List<ItemPropertyResponseObj>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                var response = new HttpResponseMessage();
                response = await client.GetAsync(string.Format("api/ItemProperty/GetItems?ListID={0}", ListID)).ConfigureAwait(false);
                 if (response.IsSuccessStatusCode)
                 {
                    string result = response.Content.ReadAsStringAsync().Result;
                    ItemPropertyResponseObj = JsonConvert.DeserializeObject<List<ItemPropertyResponseObj>>(result);
                    response.Dispose();
                 }
            }
            return ItemPropertyResponseObj;
        }

        public async Task<string> InsertItem(ItemPropertyResponseObj ItemPropertyResponseObj)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();

                resp = await client.PostAsJsonAsync("api/ItemProperty/InsertItem", ItemPropertyResponseObj).ConfigureAwait(false);
                response = resp.StatusCode.ToString();
                resp.Dispose();
            }
            return response;
        }

        public async Task<string> UpdateItem(ItemPropertyResponseObj ItemPropertyResponseObj)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();
                resp = await client.PutAsJsonAsync("api/ItemProperty/UpdateItem", ItemPropertyResponseObj).ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;
        }

        public async Task<string> DeleteItemByItemID(int ItemID)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();
                resp = await client.DeleteAsync($"api/ItemProperty/DeleteByItemID/{ItemID}").ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;
        }

        public async Task<string> DeleteItemByListID(int ListID)
        {
            string response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StrUri);
                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = new HttpResponseMessage();
                resp = await client.DeleteAsync($"api/ItemProperty/DeleteByListID/{ListID}").ConfigureAwait(false);
                response = resp.StatusCode.ToString();

                resp.Dispose();
            }
            return response;
        }

    }
}
