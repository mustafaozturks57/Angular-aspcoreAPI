using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Product
    {
        public int ProductID { get; set; }
        
        public string Names { get; set; }

        public decimal Price { get; set; }
     
     public bool IsActive { get; set; }
    
    }

}