using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
  public class ShoppingListContext : DbContext
  {
    public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ItemCategory>()
          .HasMany(left => left.Items)
          .WithOne(right => right.ItemCategory)
          .IsRequired();

      modelBuilder.Entity<ShoppingList>()
        .HasOne(e => e.Shop)
        .WithMany(e => e.ShoppingLists)
        .IsRequired();

      modelBuilder.Entity<Shop>()
        .HasMany(e => e.ItemCategories)
        .WithOne(e => e.Shop);



      var shops = new[] { new {
        ID = System.Guid.NewGuid(),
        DiscountChain = DiscountChainEnum.Lidl,
        Longitude = 0F,
        Latitude = 0F,
      },
      new {
        ID = System.Guid.NewGuid(),
        DiscountChain = DiscountChainEnum.Rema1000,
        Longitude = 0F,
        Latitude = 0F,
      }};

      var itemCategories = new[] {
        new {
          ID = System.Guid.NewGuid(),
          Name = "Vegetables",
          DateCreated = System.DateTime.UtcNow,
          LastChanged = System.DateTime.UtcNow
        },
        new {
          ID = System.Guid.NewGuid(),
          Name = "Meat",
          DateCreated = System.DateTime.UtcNow,
          LastChanged = System.DateTime.UtcNow
        },
        new {
          ID = System.Guid.NewGuid(),
          Name = "Dairy products",
          DateCreated = System.DateTime.UtcNow,
          LastChanged = System.DateTime.UtcNow
        },
      };
      var potatoes = new
      {
        ID = System.Guid.NewGuid(),
        Name = "Potatoes",
        DateCreated = System.DateTime.UtcNow,
        LastChanged = System.DateTime.UtcNow,
        ItemCategoryID = itemCategories[0].ID
      };
      var beef = new
      {
        ID = System.Guid.NewGuid(),
        Name = "Beef",
        DateCreated = System.DateTime.UtcNow,
        LastChanged = System.DateTime.UtcNow,
        ItemCategoryID = itemCategories[1].ID
      };
      var eggs = new
      {
        ID = System.Guid.NewGuid(),
        Name = "Eggs",
        DateCreated = System.DateTime.UtcNow,
        LastChanged = System.DateTime.UtcNow,
        ItemCategoryID = itemCategories[2].ID
      };
      var milk = new
      {
        ID = System.Guid.NewGuid(),
        Name = "Eggs",
        DateCreated = System.DateTime.UtcNow,
        LastChanged = System.DateTime.UtcNow,
        ItemCategoryID = itemCategories[2].ID
      };

      var shoppingList = new
      {
        ID = System.Guid.NewGuid(),
        Code = "ABC",
        RangeStart = System.DateTime.UtcNow,
        RangeEnd = System.DateTime.UtcNow,
        DateCreated = System.DateTime.UtcNow,
        LastChanged = System.DateTime.UtcNow,
        ShopID = shops[0].ID
      };

      var shoppingListItems = new[] {
        new
        {
          ItemId = potatoes.ID,
          ShoppingListId = shoppingList.ID
        },
        new
        {
          ItemId = milk.ID,
          ShoppingListId = shoppingList.ID
        }
      };

      modelBuilder.Entity<ItemCategory>().HasData(itemCategories);
      modelBuilder.Entity<Item>().HasData(new[] { potatoes, milk, eggs, beef });
      modelBuilder.Entity<ShoppingList>().HasData(new[] { shoppingList });
      modelBuilder.Entity<ShoppingListItem>().HasData(new[] {
        new { ID = System.Guid.NewGuid(), ItemID = potatoes.ID, ShoppingListID = shoppingList.ID },
        new { ID = System.Guid.NewGuid(), ItemID = milk.ID, ShoppingListID = shoppingList.ID },
        new { ID = System.Guid.NewGuid(), ItemID = eggs.ID, ShoppingListID = shoppingList.ID },
        new { ID = System.Guid.NewGuid(), ItemID = beef.ID, ShoppingListID = shoppingList.ID }
      });
      modelBuilder.Entity<Shop>().HasData(shops);
      modelBuilder.Entity<ShopItemCategories>().HasData(new[] {
        new { ID = System.Guid.NewGuid(), ItemCategoryID = itemCategories[0].ID, ShopID = shops[0].ID, Order = 1 },
        new { ID = System.Guid.NewGuid(), ItemCategoryID = itemCategories[1].ID, ShopID = shops[0].ID, Order = 0 },
        new { ID = System.Guid.NewGuid(), ItemCategoryID = itemCategories[2].ID, ShopID = shops[1].ID, Order = 0 },
      });
    }

    public DbSet<Shop> Shops { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<ShopItemCategories> ShopOrderedItemCategories { get; set; }
  }
}