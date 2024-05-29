using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Projekt.Model;

namespace WPF_Projekt.Repository
{
    class OrderRepository
    {
        private ShopContext shop;

        public OrderRepository(ShopContext shop)
        {
            this.shop = shop;
        }
        public List<Stock> GetOrders()
        {
            return shop.Stocks.ToList();
        }

        public Stock GetOrderById(int id)
        {
            return shop.Stocks.Find(id);
        }

        public void InsertOrder(Stock stock)
        {
            shop.Stocks.Add(stock);
        }

        public void UpdateOrder(Stock stock)
        {
            shop.Stocks.Find(stock.Id).Planks = stock.Planks;
            shop.Stocks.Find(stock.Id).Beams = stock.Beams;
            shop.Stocks.Find(stock.Id).OSB = stock.OSB;
            shop.Stocks.Find(stock.Id).Panels = stock.Panels;
        }

        public void DeleteOrder(int id)
        {
            Stock orderDel = shop.Stocks.Find(id);
            shop.Stocks.Remove(orderDel);
        }

        public void Save()
        {
            shop.SaveChanges();
        }
    }
}
