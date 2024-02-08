using System;
using System.Collections.Generic;

namespace LearningPractice_IE_.Models.IE
{
    public partial class Error
    {
        public int ErrorId { get; set; }
        public string ErrorName { get; set; } = null!;
        public string ErrorDescription { get; set; } = null!;
        public string? ErrorStatus { get; set; }
        public DateOnly? ErrorDetectedDate { get; set; }
        public DateOnly? ErrorFixedDate { get; set; }
    }
}
