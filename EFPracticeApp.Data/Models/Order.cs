using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPracticeApp.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderTitle { get; set; }
        public int QuantityOfProduct { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
