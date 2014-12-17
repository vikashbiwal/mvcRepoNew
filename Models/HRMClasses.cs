using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest.Models
{
    public class Designation
    {
        public int ID { get; set; }
        public string designation { get; set; }
        public List<Designation> AllDesignations()
        {
            DbOperation dOp=new DbOperation();
            List<Designation> list = new List<Designation>();
            foreach (tblDesignation tbl in dOp.getAllDesignations() as List<tblDesignation>)
            {
                Designation des = new Designation();
                des.ID = tbl.id;
                des.designation = tbl.designation;
                list.Add(des);
            }
            return list;
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int GrossSalary { get; set; }
        public Designation designation { get; set; }
        public string imagePath { get; set; }
        DbOperation db = new DbOperation();
        public void Add()
        {
            db.AddEmployee(this);
        }
        public List<Employee> AllEmployee()
        {
          return  db.getAllEmployee();
        }
        public Employee EmployeeInfo()
        {
          return  db.getEmployee(this.ID);
        }
        public void Update(int id)
        {
            db.updateEmployee(id, this);
        }
        public void Delete(int id)
        {
            db.deleteEmployee(id);
        }
        public void UpdatePicture()
        {
            db.updateEmployeePicture(this);
        }
    }
}