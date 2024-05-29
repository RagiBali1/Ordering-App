using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Projekt.Model;

namespace WPF_Projekt.Repository
{
    class PersonalDataRepository
    {
        private ShopContext shop_context;

        public PersonalDataRepository(ShopContext shop)
        {
            this.shop_context = shop;
        }

        public List<Customer> GetCustomers()
        {
            return shop_context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return shop_context.Customers.Find(id);
        }

        public void InsertCustomer(Customer customer)
        {
            shop_context.Customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = shop_context.Customers.Find(id);
            shop_context.Customers.Remove(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            shop_context.Customers.Find(customer.Id).Name = customer.Name;
            shop_context.Customers.Find(customer.Id).Email = customer.Email;
            shop_context.Customers.Find(customer.Id).City = customer.City;
        }

        public void Save()
        {
            shop_context.SaveChanges();
        }
    }
}
