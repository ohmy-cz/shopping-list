
namespace Backend.Models
{
  public class ShopItemCategories
  {
    public Guid ID { get; set; }
    public int Order { get; set; }
    public ItemCategory? ItemCategory { get; set; }
    public Shop? Shop { get; set; }
  }
}