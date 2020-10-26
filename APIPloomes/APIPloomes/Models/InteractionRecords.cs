using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPloomes.Models
{
    public class InteractionRecords
    {
        public int ContactId { get; set; }
        public Contacts Contacts { get; set; }
        public string Content { get; set;}
    }
}
