using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Projekt.Model;

namespace WPF_Projekt.Repository
{
    internal class SummaryRepository
    {
        private ShopContext shopcont;

        public SummaryRepository(ShopContext shopCont)
        {
            this.shopcont = shopCont;
        }
        public List<Order> GetSummary()
        {
            return shopcont.Orders.ToList();
        }
        public Order GetSummaryById(int id)
        {
            return shopcont.Orders.Find(id);
        }
        public void InsertSumary(Order order)
        {
            shopcont.Orders.Add(order);
        }
        public void Save()
        {
            shopcont.SaveChanges();
        }
    }
}
