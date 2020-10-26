using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace APIPloomes.Models
{
    public class Deals
    {
        public string Title { get; set; }
        public int ContactId { get; set; }
        public double Amount { get; set; }
        public int OwnerId { get; set; }
        public int StageId { get; set; }
        public List<OtherProperty> OtherProperties { get; set; }
        public List<Order> Orders { get; set;}
        public int Discount { get; internal set; }
    }
    public class OtherProperty
    {
        public string FieldKey { get; set; }
        public int IntegerValue { get; set; }
    }
    public class Order
    {
        public int Discount { get; set; }
        public double Amount { get; set; }
    }
}
