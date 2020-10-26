using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using APIPloomes.Models;

namespace APIPloomes
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContactsGET();
            //ContactsPOST();
            //DealsPOST();
            //TasksPOST();
            //DealsPATCH();
            //TasksFinishPOST();
            //DealsWinPOST();
            InteractionRecordsPOST();

        }


        public static void ContactsGET()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            //HTTP GET
            var responseTask = client.GetAsync("Contacts?$top=10");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync().Result;
                JArray retorno = JsonConvert.DeserializeObject<JObject>(readTask)["value"] as JArray;

                foreach (JObject contato in retorno)
                    Console.WriteLine(contato["Id"]);
            }
        }

        public static void ContactsPOST() 
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var contact = new Contacts() { Name = "Steve", TypeId = 2, CountryId = 55};

            var postTask = client.PostAsJsonAsync<Contacts>("Contacts", contact);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Contacts>();
                readTask.Wait();

                var insertedContact = readTask.Result;

                Console.WriteLine("Contact {0} inserted with id: {1}", insertedContact.Name, insertedContact.Id, insertedContact.TypeId, insertedContact.CountryId);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }

        }

        public static void DealsPOST()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var deal = new Deals() { Title= "Proposta", ContactId = 9893108, OwnerId = 1337};

            var postTask = client.PostAsJsonAsync<Deals>("Deals", deal);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Deals>();
                readTask.Wait();

                var insertedDeal = readTask.Result;

                Console.WriteLine("Deal {0} inserted with id: {1}", insertedDeal.Title, insertedDeal.ContactId, insertedDeal.OwnerId);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }

        }

        public static void TasksPOST()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var task = new Tasks() { Description = "Tarefa de teste", DateTime = "2020-10-26T15:00:00", Users = new List<Users> { new Users() { UserId = 83614 } }, ContactId = 9893108, DealId = 3009678 };

            var postTask = client.PostAsJsonAsync<Tasks>("Tasks", task);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Tasks>();
                readTask.Wait();

                var insertedTask = readTask.Result;

                Console.WriteLine("Task {0} inserted with id: {1}", insertedTask.Description, insertedTask.DateTime, insertedTask.UserId, insertedTask.ContactId, insertedTask.DealId);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }

        }

        // public static void DealsPATCH()
        //{
           // using var client = new HttpClient();
            //client.BaseAddress = new Uri("https://api2.ploomes.com");
            //client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //var responseTask = client.GetAsync("Deals(3009678)");
            //responseTask.Wait();

            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
              //  var deal = new Deals() {OwnerId = 1777, Amount = 15000.00};

                //var postDeal = client.PatchAsJsonAsync<Deals>("Deals(3009678)", deal);
                //postDeal.Wait();

                //var readDeal = result.Content.ReadAsAsync<Deals>();
                //readDeal.Wait();

                //var insertedDeal = readDeal.Result;

                ///Console.WriteLine("Deal {0} inserted with id: {1}", insertedDeal.OwnerId, insertedDeal.Amount);

            //}
            //else
            //{
              //  Console.WriteLine(result.StatusCode);
            //}
        //}
        public static void TasksFinishPOST()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var task = new Tasks() { Finished = true, Comments = "Concluído com sucsso!"};

            var postTask = client.PostAsJsonAsync<Tasks>("Tasks(4244948)/Finish", task);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Tasks>();
                readTask.Wait();

                var insertedTask = readTask.Result;

                Console.WriteLine("Task {0} inserted with id: {1}", insertedTask.Finished, insertedTask.Comments);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }

        }
        public static void DealsWinPOST()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var deal = new Deals() { Orders = new List<Order> { new Order() {Discount = 0, Amount = 15000.00 } } };

            var postTask = client.PostAsJsonAsync<Deals>("Deals(3009678)/Win", deal);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Deals>();
                readTask.Wait();

                var insertedDeal = readTask.Result;

                Console.WriteLine("Deal {0} inserted with id: {1}", insertedDeal.Discount, insertedDeal.Amount);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }

        }
        public static void InteractionRecordsPOST()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var ir = new InteractionRecords() { ContactId = 9893108, Content = "Negócio fechado!"};

            var postTask = client.PostAsJsonAsync<InteractionRecords>("InteractionRecords", ir);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<InteractionRecords>();
                readTask.Wait();

                var insertedIR = readTask.Result;

                Console.WriteLine("Deal {0} inserted with id: {1}", insertedIR.ContactId, insertedIR.Content);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }

        }

    }
}

