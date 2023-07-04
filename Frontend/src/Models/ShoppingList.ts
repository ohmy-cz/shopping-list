import { Item } from "./Item";
import { Shop } from "./Shop";

export interface ShoppingList {
  id: string;
  items: Item[];
  code: string;
  shop: Shop;
  rangeStart: Date;
  rangeEnd: Date;
  dateCreated: Date;
  lastChanged: Date;
}
