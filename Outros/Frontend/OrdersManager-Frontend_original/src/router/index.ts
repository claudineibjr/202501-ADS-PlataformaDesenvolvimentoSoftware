import LoginView from '@/views/LoginView.vue';
import OrdersView from '@/views/OrdersView.vue';
import { createRouter, createWebHistory } from 'vue-router'
import authRoutes from './authRoutes';
import ProductView from '@/views/ProductView.vue';

export const routes = {
  login: '/login',
  orders: '/orders',
  product: '/product',
};

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: routes.login,
      name: 'login',
      component: LoginView,
      meta: {
        requiresAuthentication: false,
      },
    },
    {
      path: routes.orders,
      name: 'orders',
      component: OrdersView,
      meta: {
        requiresAuthentication: true,
      },
    },
    {
      path: `${routes.product}/:id`,
      name: 'product',
      component: ProductView,
      meta: {
        requiresAuthentication: true,
      },
      props: true,
    },
  ]
});

router.beforeEach(authRoutes);

export default router;
