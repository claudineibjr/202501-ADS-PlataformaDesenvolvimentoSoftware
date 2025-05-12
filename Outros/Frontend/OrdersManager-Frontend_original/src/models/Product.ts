export type ProductType = {
  id: string;
  name: string;
  price: number;
  imageUrl?: string;
};

export type ProductItemType = {
  product: ProductType;
  quantity: number;
};
