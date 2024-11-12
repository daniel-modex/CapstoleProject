using System.ComponentModel.DataAnnotations;

namespace BookingApi.Models
{
    public class BookingResponse
    {
        [Key]
        public int ResponseId { get; set; }
        public int BookingId { get; set; }
        public bool ServiceResponse { get; set; }=false;
        public string? ServiceMessage { get; set; }
        public bool paymentResponse { get; set; } =false;
        public string? PaymentMessage { get; set; }
        public bool CancallationResponse { get; set; } = false;
    }
}
