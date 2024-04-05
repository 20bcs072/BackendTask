using System.ComponentModel.DataAnnotations;

namespace product.Models
{
    public class Report
    {
        [Key]

        public int ReportID {get; set;}
        public DateOnly fromDate {get; set;}

        public DateOnly toDate {get; set;}

        public string ReportStatus {get; set;}
    }
}