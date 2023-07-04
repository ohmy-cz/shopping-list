namespace Backend.Models
{
  public class Shop
  {
    public System.Guid ID { get; set; }
    public DiscountChainEnum DiscountChain { get; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }

    /// <summary>Used for storing the order of item categories, as you would physically see them in the store - from the moment of entry, until you'd see the cashier.</summary>
    public ICollection<ShopItemCategories> ItemCategories { get; set; } = new List<ShopItemCategories>();

    // TODO: Unncessary?
    public ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
  }
}