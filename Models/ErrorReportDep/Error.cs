using System;
using System.Collections.Generic;

namespace LearningPractice_Launcher_.Models.ErrorReportDep
{
    public partial class Error
    {
        public int ErroriD { get; set; }
        public string ErrorDescription { get; set; } = null!;
        public string ErrorStatus { get; set; } = null!;
        public DateOnly? ErrorDetectedDate { get; set; }
        public DateOnly? ErrorFixedDate { get; set; }
        public string? Version { get; set; }
        public string? VersionDownloadUrl { get; set; }
    }
}
