using MVC_Dropdown.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dropdown.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string connectionString = "Data Source=SELVAKUMAR\\SQLEXPRESS;Initial Catalog=mvc_dropdown;Integrated Security=True";

        // ...
        public ActionResult List()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Gender = (string)reader["Gender"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Course = (string)reader["Course"]
                        };

                        customers.Add(customer);
                    }
                }
            }

            return View(customers);
        }

        public ActionResult Create()
        {
            ViewBag.Genders = new List<string> { "Male", "Female", "Other" };
            ViewBag.Courses = new List<string> { "Course 1", "Course 2", "Course 3" };

            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Customer (Name, Email, Gender, PhoneNumber, Course) VALUES (@Name, @Email, @Gender, @PhoneNumber, @Course)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Gender", customer.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@Course", customer.Course);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("List");
            }

            ViewBag.Genders = new List<string> { "Male", "Female", "Other" };
            ViewBag.Courses = new List<string> { "Java", "Python", "Dotnet" };

            return View(customer);
        }

        public ActionResult Details(int id)
        {
            Customer customer = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer = new Customer
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Gender = (string)reader["Gender"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Course = (string)reader["Course"]
                        };
                    }
                }
            }

            return View(customer);
        }


    }

}
