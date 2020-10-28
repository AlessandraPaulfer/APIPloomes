using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPloomes.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public List<Users> Users { get; set; }
        public List<Tag> Tags { get; set; }
        public int ContactId { get; set; }
        public int DealId { get; set; }
        public object UserId { get; internal set; }
        public Boolean Finished { get; set; }
        public string Comments { get; set;}
    }
    public class Users  {
        public int UserId { get; set; } 
    }

    public class Tag    {
        public int TagId { get; set; } 
    }
}
