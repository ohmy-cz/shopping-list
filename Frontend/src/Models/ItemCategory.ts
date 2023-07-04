import { Item } from "./Item";

export interface ItemCategory {
  id: string;
  name: string;
  items: Item[];
}
