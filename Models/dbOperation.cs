using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest.Models
{
    public class DbOperation
    {
        HRMDBEntities db = new HRMDBEntities();
        public object getAllDesignations()
        {
            return db.tblDesignations.ToList();
        }
        public void AddEmployee(Employee emp)
        {
            tblEmployee newRecord = new tblEmployee();
            newRecord.name = emp.Name;
            newRecord.address = emp.Address;
            newRecord.grossSalary = emp.GrossSalary;
            newRecord.designation = emp.designation.ID;
            db.tblEmployees.Add(newRecord);
            db.SaveChanges();
        }
        public List<Employee> getAllEmployee()
        {
            var data = from e in db.tblEmployees join d in db.tblDesignations on e.designation equals d.id select new { e, d };
            List<Employee> list = new List<Employee>();
            foreach (var emp in data)
            {
                Employee employee = new Employee();
                employee.Name = emp.e.name;
                employee.ID = emp.e.id;
                employee.Address = emp.e.address;
                employee.imagePath = emp.e.empImage;
                employee.GrossSalary = Convert.ToInt32(emp.e.grossSalary);
                Designation des = new Designation();
                des.designation = emp.d.designation;
                employee.designation = des;
                list.Add(employee);

            }
            return list;
        }
        public Employee getEmployee(int id)
        {
            var emp = db.tblEmployees.Single(e => e.id == id);
            Employee employee = new Employee();
            employee.Name = emp.name;
            employee.Address = emp.address;
            employee.GrossSalary =Convert.ToInt32( emp.grossSalary);
            Designation des = new Designation();
            des.ID =Convert.ToInt32( emp.designation);

            employee.designation = des;
            return employee;
        }
        public void updateEmployee(int id, Employee emp)
        {
            var row = db.tblEmployees.Single(e => e.id == id);
            row.name = emp.Name;
            row.grossSalary = emp.GrossSalary;
            row.address = emp.Address;
            row.designation = emp.designation.ID;
            db.SaveChanges();
        }
        public void deleteEmployee(int id)
        {
            var row = db.tblEmployees.Single(e => e.id == id);
            db.tblEmployees.Remove(row);
            db.SaveChanges();

           
        }
        public void updateEmployeePicture(Employee e)
        {
            var emp = db.tblEmployees.Single(s => s.id == e.ID);
            emp.empImage = e.imagePath;
            db.SaveChanges();
        }
    }
}