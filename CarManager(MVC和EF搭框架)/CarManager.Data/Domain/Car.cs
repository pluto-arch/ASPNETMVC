using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data.Domain
{
    public class Car:BaseEntity
    {
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateTime { get; set; }

    }
}
