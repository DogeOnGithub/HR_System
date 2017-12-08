namespace Model
{
    public class StaffPayment
    {

        public int Id { get; set; }

        public int StaffSalaryId { get; set; }

        public int PaymentId { get; set; }

        public decimal OddAmout { get; set; }

        public decimal MinusAmout { get; set; }

    }
}
