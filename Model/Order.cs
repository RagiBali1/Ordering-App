using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt.Model
{
    [Table("orders")]
    class Order
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("CustomerId")]
        public int CustId { get; set; }
        [Column("StockId")]
        public int StockId { get; set; }
    }
}
