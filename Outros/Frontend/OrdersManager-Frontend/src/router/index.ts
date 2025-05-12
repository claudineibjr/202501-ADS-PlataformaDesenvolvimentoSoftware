import { createRouter, createWebHistory } from 'vue-router'
import ProductView from '@/views/ProductView.vue'
import ProductsView from '@/views/ProductsView.vue'
import ProductCreateView from '@/views/ProductCreateView.vue'
import ProductUpdateView from '@/views/ProductUpdateView.vue'
import CustomersView from '@/views/CustomersView.vue'
import CustomerView from '@/views/CustomerView.vue'
import CustomerCreateView from '@/views/CustomerCreateView.vue'
import CustomerUpdateView from '@/views/CustomerUpdateView.vue'

export const routes = {
  products: '/produtos',
  product: '/produto',
  createProduct: '/produtos/novo',

  customers: '/clientes',
  customer: '/cliente',
  createCustomer: '/clientes/novo',
}

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

    {
      path: routes.customers,
      name: routes.customers,
      component: CustomersView,
      props: true,
    },
    {
      path: `${routes.customer}/:id`,
      name: routes.customer,
      component: CustomerView,
      props: true,
    },
    {
      path: routes.createCustomer,
      name: routes.createCustomer,
      component: CustomerCreateView,
      props: true,
    },
    {
      path: `${routes.customer}/:id/atualizar`,
      name: 'UpdateCustomer',
      component: CustomerUpdateView,
      props: true,
    },
  ],
})

export default router
