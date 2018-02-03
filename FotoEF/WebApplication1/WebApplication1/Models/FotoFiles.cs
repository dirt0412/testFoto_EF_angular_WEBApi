using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FotoFiles
    {
        //[Key, Column(Order = 0)]
        //public int Id { get; set; }

        //[Column(Order = 1), StringLength(200)]
        //public string Name { get; set; }

        //[Column(Order = 2), StringLength(1000)]
        //public string Description { get; set; }

        //[Column(Order = 3)]
        //public int IdFolder { get; set; }

        public decimal id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal id_folder { get; set; }

        public FotoFiles()
        { }
    }
}