using System;
using System.Collections.Generic;

namespace Backend.Models
{
  public class ItemCategory
  {
    public Guid ID { get; set; }
    public string? Name { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastChanged { get; set; }
    public ICollection<Item>? Items { get; set; }
    // TODO: Find a way to remove this
    public ICollection<Shop>? Shops { get; set; }
  }
}