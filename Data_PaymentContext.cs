using Microsoft.EntityFrameworkCore;
using ItauXPay.Models;

namespace ItauXPay.Data;

public class PaymentContext : DbContext
{
    public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

    public DbSet<Payment> Payments { get; set; }
}