using System.ComponentModel.DataAnnotations;

namespace ItauXPay.Models;

public class Payment
{
    public int Id { get; set; }

    [Required]
    public string PayerName { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    [Required]
    public string Status { get; set; }
}