using System;
using System.Collections.Generic;

namespace SharedEconomy.Data.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string? Comment { get; set; }

    public DateTime Date { get; set; }

    public int SubAccountId { get; set; }

    public virtual SubAccount SubAccount { get; set; } = null!;
}
