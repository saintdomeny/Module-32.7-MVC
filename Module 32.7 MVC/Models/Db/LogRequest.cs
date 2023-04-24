using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Module_32._7_MVC.Models.Db
{
    [Table("LogRequests")]
    public class LogRequest
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
