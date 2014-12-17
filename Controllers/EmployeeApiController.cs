using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    
    public class EmployeeApiController : ApiController
    {
        public List<Designation> getDesignations()
        {
            Designation des = new Designation();
            return des.AllDesignations();
        }
        public Employee get(int id)
        { 
            Employee emp=new Employee();
            emp.ID=id;
            return emp.EmployeeInfo();
        }
        public string PostEmployee(Employee employee)
        {
            employee.Add();
           
            return "insert successfully";
        }
        [HttpGet]
        public List<Employee> Employees()
        {
            return new Employee().AllEmployee();
        }
        public string put(int id,Employee emp)
        {
            emp.Update(id);
            return "successfullly";
        }
        public string deleteEmployee(int id)
        {
            Employee emp = new Employee();
            emp.Delete(id);
            return "success fully";
        }
     
      [HttpPut]//update userProfile picture
        public void UploadFile(int id)
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    Employee emp = new Employee();
                    emp.ID = id;
                    emp.imagePath = "~/UploadedFiles/" + httpPostedFile.FileName;
                    emp.UpdatePicture();
                    
                }
            }
        }

       
    }
}
