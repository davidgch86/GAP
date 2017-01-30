using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperZapatosAPI.Data
{
    public class Article
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public int total_in_shelf { get; set; }

        [Required]
        public int total_in_vault { get; set; }

        // Foreign Key
        [Required]
        public int store_id { get; set; }

    }
}