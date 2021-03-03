using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Iqbal.Models
{
    public class ExamDetailDTO
    {
        public ExamDetail ExamDetailData { get; set; }
        public List<ExamDetail> ExamDetailList { get; set; }
    }
}