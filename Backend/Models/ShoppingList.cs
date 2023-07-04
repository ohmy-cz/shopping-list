using System;
using System.Collections.Generic;

namespace Backend.Models
{
  public class ShoppingList
  {
    public Guid ID { get; set; }
    public string? Code { get; set; }
    /// <summary>Start of the date period of this shopping list</summary>
    public Shop? Shop { get; set; }
    public DateTime RangeStart { get; set; }

    /// <summary>End of the date period of this shopping list</summary>
    public DateTime RangeEnd { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastChanged { get; set; }
  }
}