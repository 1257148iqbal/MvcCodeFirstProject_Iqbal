using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Iqbal.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "This Field is Required!!")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "You Must be Give Minimum 2 and Maximum 30 Chrecter")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "This Field is Required!!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required!!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "You Must be Give Minimum 2 and Maximum 30 Chrecter")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "This Field is Required!!")]
        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        public string TecherImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Teacher()
        {
            TecherImage = "~/Images/Capture.PNG";
        }


        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}