using APIPloomes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIPloomes
{
    public class InterviewPloomes
    {
        public int FakeUserId = 83614;
        public double DealAmount = 15000.00;
        public string TaskComment = "Tarefa finalizada!";
        public int DealDiscount = 0;
        public string DealFinishMessage = "Negócio fechado!";
        public void RunInterviewPloomes ()
        {
            var contact = CreateContact();
            contact.Id = 9921058;
            CreateDeal(contact.Id, 1337);
            CreateTask(3021337, contact.Id, new List<Users> { new Users() { UserId = FakeUserId }});
            UpdateDeal(3021337, 1337, DealAmount);
            FinishTask(4260974, TaskComment);
            WinDeal(3021337, new List<Order> { new Order() { Discount = DealDiscount, Amount = DealAmount } });
            CreateInteractionRecords(contact.Id, DealFinishMessage);
        }

        public HttpClient ClientBuilder()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", "05EC8DE67A529319DA84464878005930165E6D33F126612C44750A65BF09BB2D77A399600FE01C5FD9185F78257BBE7B1A78537BFBA2528A2FD9A31187D1D53E");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            return client;
        }

        public Contacts CreateContact() 
        {
            var contact = new Contacts() { Name = "Steve teste", TypeId = 2, CountryId = 55 };

            var postTask = ClientBuilder().PostAsJsonAsync<Contacts>("Contacts", contact);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Contacts>();
                readTask.Wait();

                var insertedContact = readTask.Result;
                Console.WriteLine("Contact {0} inserted with id: {1}", insertedContact.Name, insertedContact.Id, insertedContact.TypeId, insertedContact.CountryId);
                return insertedContact;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
            return null;

        }

        public Deals CreateDeal(int contactId, int ownerId) 
        {
            var deal = new Deals() { Title = "Proposta", ContactId = contactId, OwnerId = ownerId };

            var postTask = ClientBuilder().PostAsJsonAsync<Deals>("Deals", deal);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Deals>();
                readTask.Wait();

                var insertedDeal = readTask.Result;

                Console.WriteLine("Deal {0} inserted with id: {1}", insertedDeal.Title, insertedDeal.ContactId, insertedDeal.OwnerId);
                return insertedDeal;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
            return null;
        }

        public Tasks CreateTask(int dealId, int contactId, List<Users> users) 
        {
            var task = new Tasks() { Description = "Nova tarefa", DateTime = DateTime.Now.ToString(), Users = users, ContactId = contactId, DealId = dealId };

            var postTask = ClientBuilder().PostAsJsonAsync<Tasks>("Tasks", task);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Tasks>();
                readTask.Wait();

                var insertedTask = readTask.Result;

                Console.WriteLine("Task {0} inserted with id: {1}", insertedTask.Description, insertedTask.DateTime, insertedTask.UserId, insertedTask.ContactId, insertedTask.DealId);

                return insertedTask;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
            return null;
        }

        public Deals UpdateDeal(int dealId, int ownerId, double amount) 
        {
            var deal = new Deals() { OwnerId = ownerId, Amount = amount};

            var postDeal = ClientBuilder().PatchJsonAsync($"Deals({dealId}))?$expand=Stages,Tags,Products,Contacts,OtherProperties", typeof(Deals), deal);
            postDeal.Wait();

            var result = postDeal.Result;
            if (result.IsSuccessStatusCode)
            {

                var readDeal = result.Content.ReadAsAsync<Deals>();
                readDeal.Wait();

                var insertedDeal = readDeal.Result;

                Console.WriteLine("Deal {0} inserted with id: {1}", insertedDeal.OwnerId, insertedDeal.Amount);

                return insertedDeal;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
            return null;
        }

        public Tasks FinishTask(int taskId, string comments) 
        {
            var task = new Tasks() { Finished = true, Comments = comments, Id = taskId };

            var postTask = ClientBuilder().PostAsJsonAsync<Tasks>($"Tasks({taskId})/Finish", task);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Tasks>();
                readTask.Wait();

                var insertedTask = readTask.Result;

                Console.WriteLine("Task {0} inserted with id: {1}", insertedTask.Finished, insertedTask.Comments);

                return insertedTask;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
            return null;
        }

        public Deals WinDeal(int dealId, List<Order> orders)
        {
            var deal = new Deals() { Orders = orders};

            var postTask = ClientBuilder().PostAsJsonAsync<Deals>($"Deals({dealId})/Win", deal);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Deals>();
                readTask.Wait();

                var insertedDeal = readTask.Result;

                Console.WriteLine("Deal {0} inserted with id: {1}", insertedDeal.Discount, insertedDeal.Amount);

                return insertedDeal;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
            return null;
        }

        public void CreateInteractionRecords(int contactId, string content)
        {
            var ir = new InteractionRecords() { ContactId = contactId, Content = content };

            var postTask = ClientBuilder().PostAsJsonAsync<InteractionRecords>("InteractionRecords", ir);
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
