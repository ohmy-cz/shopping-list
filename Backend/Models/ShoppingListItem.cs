using System;
using System.Collections.Generic;

namespace Backend.Models
{
  public class ShoppingListItem
  {
    public Guid ID { get; set; }
    public Item? Item { get; set; }
    public ShoppingList? ShoppingList { get; set; }
  }
}