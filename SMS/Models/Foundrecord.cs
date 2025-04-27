using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Foundrecord
{
    public string FoundDate { get; set; } = null!;

    public string? ClaimDate { get; set; }

    public int? ItemId { get; set; }

    public string? FounderId { get; set; }

    public string? ClaimantId { get; set; }

    public virtual Claimant? Claimant { get; set; }

    public virtual Founder? Founder { get; set; }

    public virtual Item? Item { get; set; }
}
