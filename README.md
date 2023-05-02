# Family Shopping List
This webapp gives you and your partner/family a simple, no-hassle way to prepare a weekly shopping list for groceries and other household products a typical family or a couple needs.

## Manifest
Here are a few points to give this project a good direction and some boundaries to its features:

### Features
- No sign-ups, accounts, ads - yet it's free to use, and open source
  - The aim of this app is to provide a free service. I am designing it to be able to use completely anonymously - with a single unique code for each family. As long as you have the code, you have access to the shopping list.
- Place to store links to recipes,
- You can tick-off items as you put them in your cart in the store - and whoever shares the app with you sees the change immediately. That makes is easy to split responsibilities with others.
- The webapp keeps the screen on, so you don't have to constantly login again and again, or fiddle with the screen so the phone wouldn't go to sleep.
- A button to empty the current list
- Realtime updates between as many users as there are at the given moment
  - Uses diff to inteligently merge changes.
  - Indicates other users with an eye icon in the corner, and a number to indicate how many there are.
- Grouping of groceries by food category
  - These categories should be moveable and the position should be persisted, so you can organize it exactly the way your favourite store is.
  - Later: Automatic categorization of entered groceries
  - Later: Change the order of categories by geolocation, so the order is automatically correct for the shop you're in
- Multiple language support
  - Starting with English, Danish and Czech
- Later: Automatic parsing of recipes
  - In-build iframe browser, where you enter the URL of your recipe, and then a parser will get the recipe name from the page title, picture from meta tags, and ingredients from the page body.
- Later: Analyzing the shopping cart and finding out which grocery store chain would be the cheapest to go shopping
  - requires researching APIs to get the grocery prices
  - there should be a filter for "Eco" products

### Competitor analysis - why using SF Shopping List?
- Evernote:
  - While this has been our family's go-to solution for shopping lists, sync doesn't work well. I've lost the shopping list one-too-many times to keep up with this app.
  - They are very agressive in trying to make you pay for the whole product.
- Listonic:
  - Looked promising, but I couldn't get the list sharing to work
- AnyList:
  - Too general-purpose,
  - Clunky interface
- Any store-chain app
  - Varied user experience, ties you into a given chain of stores.
  - Typically plagued with self-promotion
  - Clunky interfaces
- Using Google docs/sheets
  - Has nice realtime multiple users indication, but:
  - Difficult to clear the list (you'd have to keep a template and then copy&paste over)
  - No easy checkbox interface
  - Nothing to help you with the repetitive tasks: searching recipes for ingredients, and categorizing them to make the shopping experience smoother.
