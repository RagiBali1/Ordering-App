using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Resources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WPF_Projekt.Model
{
    internal class ShopContext : DbContext
    {
        public string connection = null;
        public ShopContext()
        {
            connection = ConfigurationManager.AppSettings.Get("Dburl");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connection);
        }
    }
}
