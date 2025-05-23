namespace MyPaymentApp.Models
{
    public class PaymentModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string UpiId { get; set; }
        public string PhoneNumber { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
    }
}
