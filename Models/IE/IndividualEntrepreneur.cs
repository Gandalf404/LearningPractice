using System;
using System.Collections.Generic;

namespace LearningPractice_IE_.Models.IE
{
    public partial class IndividualEntrepreneur
    {
        public int EntrepreneurId { get; set; }
        public string EntrepreneurSurname { get; set; } = null!;
        public string EntrepreneurName { get; set; } = null!;
        public string EntrepreneurPatronymic { get; set; } = null!;
        public long EntrepreneurItn { get; set; }
        public string EntrepreneurAddress { get; set; } = null!;
        public long EntrepreneurAccountNumber { get; set; }
        public string EntrepreneurAccountBank { get; set; } = null!;
        public string EntrepreneurLogin { get; set; } = null!;
        public string EntrepreneurPassword { get; set; } = null!;
    }
}
