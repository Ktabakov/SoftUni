using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Output
{
    public class UsersOutputDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Product> SoldProducts { get; set; }
    }
}
