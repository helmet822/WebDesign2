using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace MvcMain.Models
{
    public class Main
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:G0}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Person { get; set; }
        [StringLength(50)]
        public string Memo { get; set; }

    }

    public class MainDBContext : DbContext
    {
        public DbSet<Main> Mains { get; set; }
    }
}