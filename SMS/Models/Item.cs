using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemDiscription { get; set; } = null!;
}
