using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopegy.Models
{
    public class productreivew
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public string ProductID { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}