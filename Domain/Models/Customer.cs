using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer : ΤEntity
    {
        public string Email { get; set; } 
        public string Name { get; set; }
    }
}
