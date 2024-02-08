using System;
using System.Collections.Generic;

namespace LearningPractice_IE_.Models.IE
{
    public partial class IncomeAndExpense
    {
        public int Id { get; set; }
        public DateOnly OriginalDocumentDate { get; set; }
        public string OperationDescription { get; set; } = null!;
        public decimal? Incomes { get; set; }
        public decimal? Expense { get; set; }
    }
}
