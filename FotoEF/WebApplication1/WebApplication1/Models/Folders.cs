using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Folders
    {
        //[Key, Column(Order = 0)]
        //public int Id { get; set; }

        //[Column(Order = 1), StringLength(200)]
        //public string Name { get; set; }

        //[Column(Order = 2), StringLength(1000)]
        //public string Description { get; set; }

        //[Column(Order = 3), StringLength(200)]
        //public string Icon { get; set; }

        public decimal id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

        public Folders()
        { }
    }
}