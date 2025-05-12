import type { CustomerType } from './Customer';
import type { ProductItemType } from './Product';

export type OrderType = {
  id: string;
  orderDate: Date;
  customer: CustomerType;
  products: ProductItemType[];
  totalAmount: number;
};
