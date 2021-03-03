using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Iqbal.Models
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        [Required(ErrorMessage = "This Field is Required!")]

        public string TrainerName { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }
        public decimal Salary { get; set; }

        public string Picture { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}