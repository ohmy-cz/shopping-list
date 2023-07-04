using System;
using System.Collections.Generic;

namespace Backend.Models
{
  public class Item
  {
    public Guid ID { get; set; }
    /// <summary>English name of the item</summary>
    public string? Name { get; set; }
    public ItemCategory? ItemCategory { get; set; }
    public ICollection<ShoppingList>? ShoppingLists { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime LastChanged { get; set; }
  }
}