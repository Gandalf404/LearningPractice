using System;
using System.Collections.Generic;

namespace LearningPractice_App_.Models.Update
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Phone { get; set; }
    }
}
