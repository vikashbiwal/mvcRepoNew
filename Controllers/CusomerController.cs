using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class CusomerController : ApiController
    {
        public List<Customer> getAllCustomers()
        {
            List<Customer> customers = new List<Customer> { new Customer { CustomerName = "vikash", CompanyName = "Tops", City = "Jaipur" },
            new Customer{CustomerName="Yogesh",CompanyName="Tops" ,City="Nadiyad"},
            new Customer{CustomerName="Tejash",CompanyName="TCS",City="Nadiyad"}
            };


            return customers;
        }
        //public List<Customer> getAllCustomer()
        //{

        //    List<Customer> customers = new List<Customer> { new Customer { CustomerName = "vikash", CompanyName = "Tops", City = "Jaipur" },
        //    new Customer{CustomerName="Brijesh",CompanyName="Tops" ,City="Nadiyad"},
        //    new Customer{CustomerName="Tejash",CompanyName="TCS",City="Nadiyad"}
        //    };
           
        //    return customers;
        //}
    }
}
