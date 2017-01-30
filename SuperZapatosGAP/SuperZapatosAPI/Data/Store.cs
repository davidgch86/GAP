using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperZapatosAPI.Data
{

    public class Store
    {
        public Store() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }
    }
}
