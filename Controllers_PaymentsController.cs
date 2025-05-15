using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItauXPay.Data;
using ItauXPay.Models;
using ItauXPay.Services;

namespace ItauXPay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly PaymentContext _context;
    private readonly ItauPaymentService _itauPaymentService;

    public PaymentsController(PaymentContext context, ItauPaymentService itauPaymentService)
    {
        _context = context;
        _itauPaymentService = itauPaymentService;
    }

    // POST: api/payments
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid payment data.");

        payment.Status = "Processing";
        payment.PaymentDate = DateTime.UtcNow;

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var itauResponse = await _itauPaymentService.ProcessPaymentAsync(payment);
        payment.Status = itauResponse.Status;

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
    }

    // GET: api/payments
    [HttpGet]
    public async Task<IActionResult> GetPayments()
    {
        var payments = await _context.Payments.ToListAsync();
        return Ok(payments);
    }

    // GET: api/payments/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
            return NotFound($"Payment with ID {id} not found.");

        return Ok(payment);
    }

    // PUT: api/payments/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment updatedPayment)
    {
        if (id != updatedPayment.Id)
            return BadRequest("Payment ID mismatch.");

        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
            return NotFound($"Payment with ID {id} not found.");

        payment.PayerName = updatedPayment.PayerName;
        payment.Amount = updatedPayment.Amount;
        payment.Status = updatedPayment.Status;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/payments/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
            return NotFound($"Payment with ID {id} not found.");

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}