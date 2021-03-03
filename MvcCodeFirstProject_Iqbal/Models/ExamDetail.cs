using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Iqbal.Models
{
    public class ExamDetail
    {
        public int ExamDetailID { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "You Must be Give Minimum 2 and Maximum 30 Chrecter")]
        public string ExamName { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExamDate { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [Display(Name = "M C Q")]
        public int MCQ { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [Range(5, 50, ErrorMessage = "Evidence Number Must be Less than 5 more 50!!")]
        public int Evidence { get; set; }
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Total Marks")]
        public int Total
        {
            get { return MCQ + Evidence; }
        }
        public int TraineeID { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}