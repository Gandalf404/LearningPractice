using System;
using System.Collections.Generic;

namespace LearningPractice_IE_.Models.IE
{
    public partial class Version
    {
        public int VersionId { get; set; }
        public string Version1 { get; set; } = null!;
        public string VersionUrl { get; set; } = null!;
        public DateOnly VersionUploadDate { get; set; }
    }
}
