# Migrations

## Adding a migration

See [this link](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).

## Updating the database

Pending migrations are applied on startup.

For manual update from your terminal, run `dotnet ef database update --connection "ShoppingListContext"`, where ShoppingListContext is value from appsettings.json with host changed to `localhost`.
