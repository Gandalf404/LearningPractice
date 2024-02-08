using System;
using System.Collections.Generic;

namespace LearningPractice_App_.Models.ErrorReportDep
{
    public partial class Developer
    {
        public int DeveloperId { get; set; }
        public string DeveloperSurname { get; set; } = null!;
        public string DeveloperName { get; set; } = null!;
        public string DeveloperLogin { get; set; } = null!;
        public string DeveloperPassword { get; set; } = null!;
        public bool IsTeamLeader { get; set; }
        public string? ErrorStatus { get; set; }
        public byte[]? ErrorRawMessage { get; set; }
        public TimeOnly? ErrorDetectedTime { get; set; }
        public TimeOnly? ErrorFixedTime { get; set; }
    }
}
