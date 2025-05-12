<script setup lang="ts">
import type { OrderType } from '@/models/Order';
import { formatDate } from '@/utils/formatDate';
import { formatCurrency } from '@/utils/formatCurrency';

type OrdersTableItem = {
  order: OrderType;
};

defineProps<OrdersTableItem>();
</script>

<template>
  <th>{{ order.id }}</th>
  <th>{{ formatDate(order.orderDate) }}</th>
  <th>
    <li v-for="product in order.products" v-bind:key="product.product.id">
      {{ `${product.quantity}x - ${product.product.name} (${formatCurrency(product.product.price)} / un)` }}
    </li>
  </th>
  <th>{{ formatCurrency(order.totalAmount) }}</th>
</template>
