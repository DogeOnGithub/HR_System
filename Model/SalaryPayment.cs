using System;

namespace Model
{
    public class SalaryPayment
    {

        public int Id { get; set; }

        public string FileNumber { get; set; }

        public int TotalPerson { get; set; }

        public decimal TotalAmout { get; set; }

        public DateTime RegistTime { get; set; }

        public int FileState { get; set; }

    }
}
