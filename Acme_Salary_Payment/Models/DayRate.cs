using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme_Salary_Payment.Models
{
    public class DayRate
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "char(2)")]
        public string code_day { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime hour_from { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime hour_to { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal rate { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int order { get; set; }
    }
}
