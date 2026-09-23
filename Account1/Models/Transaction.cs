using System.ComponentModel.DataAnnotations;

namespace Account1.Models
{
    public enum TransactionType
    {
        Income,
        Expense,
        Capital
    }
    public enum FundSource
    {
        Owner,
        BankLoan,
        Transfer
    }

    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        // Filled by the AI classifier later — "Fuel", "Logistics", "Revenue", etc.
        // Only meaningful when Type is Income or Expense
        public string? Category { get; set; }

        // Only meaningful when Type == Capital — e.g. "Owner", "Bank Loan", "Transfer"
        public FundSource FundSource { get; set; }

        // Ties this transaction to its owning user (required — every transaction belongs to someone)
        public int UserId { get; set; }

        // Links this transaction to the invoice it's paying, if any.
        // Nullable because most transactions (fuel, capital injections) have no invoice at all.
        public int? InvoiceId { get; set; }
    }
}