import { DiscountChainEnum } from "../Enums/DiscountChainEnum";
import { ShopItemCategories } from "./ShopItemCategories";

export interface Shop {
  id: string;
  discountChain: DiscountChainEnum;
  itemCategories: ShopItemCategories[];
  // TODO: Add more properties
}
