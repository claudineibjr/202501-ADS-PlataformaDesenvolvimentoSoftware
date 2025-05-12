import { createRouter, createWebHistory } from 'vue-router'
import ProductView from '@/views/ProductView.vue';
import ProductsView from '@/views/ProductsView.vue';
import ProductCreateView from '@/views/ProductCreateView.vue';
import ProductUpdateView from '@/views/ProductUpdateView.vue';

export const routes = {
  products: '/produtos',
  product: '/produto',
  createProduct: '/produtos/novo',
};

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: routes.products,
      name: routes.products,
      component: ProductsView,
      props: true,
    },
    {
      path: `${routes.product}/:id`,
      name: routes.product,
      component: ProductView,
      props: true,
    },
    {
      path: routes.createProduct,
      name: routes.createProduct,
      component: ProductCreateView,
      props: true,
    },
    {
      path: `${routes.product}/:id/atualizar`,
      name: 'Update product',
      component: ProductUpdateView,
      props: true,
    },
  ]
});

export default router;
