using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Iqbal.Models
{
    public class Trainee
    {
        public int TraineeID { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "You Must be Give Minimum 2 and Maximum 30 Chrecter")]

        public string TraineeName { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "You Must be Give Minimum 11 and Maximum 11 Chrecter")]
        [Display(Name = "Cell Phone No")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "You Must be Give Minimum 3 and Maximum 250 Chrecter")]
        public string ContactAddress { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [Range(10, 500, ErrorMessage = "Trainee Fee Must me 10 to 500 Tk.")]
        public string TraineeFee { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AdmisionDate { get; set; }

        public string UploadImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase Picture { get; set; }
        public int TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ExamDetail> ExamDetails { get; set; }
    }
}