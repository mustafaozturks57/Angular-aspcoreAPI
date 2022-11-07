using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.DTO
{
    public class ProductDTO
    {
          public int ProductID { get; set; }
        
        public string Names { get; set; }

        public decimal Price { get; set; }
 
        public bool isActive  { get; set; }
     
     

    }
}