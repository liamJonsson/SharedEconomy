using System;
using System.Collections.Generic;


//STEG 5 - BÖRJA HÄR

namespace SharedEconomy.Data.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual ICollection<SubAccount> SubAccounts { get; set; } = new List<SubAccount>();
}
