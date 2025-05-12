<script setup lang="ts">
import api from '@/api';
import OrdersTableHeader from '@/components/OrdersTableHeader.vue';
import OrdersTableItem from '@/components/OrdersTableItem.vue';
import type { OrderType } from '@/models/Order';
import { onMounted, ref } from 'vue';

const orders = ref<OrderType[]>();

onMounted(async () => {
  console.log('Buscando pedidos...');

  try {
    const ordersResult = await api.get<OrderType[]>('/Order');

    console.log({ ordersResult }, '[Orders]');

    orders.value = ordersResult.data;

  } catch (error) {
    alert("Falha ao buscar pedidos");

    console.error({ error }, 'Falha ao buscar pedidos');
  }
});

</script>

<template fluid>
  <div class="orders-list">
    <h1>Pedidos</h1>

    <br/>

    <table class="table table-striped table-hover">
      <OrdersTableHeader />
      <tbody>
        <tr v-for="order in orders" v-bind:key="order.id">
          <OrdersTableItem :order="order" />
        </tr>
      </tbody>
    </table>
  </div>
  
</template>


<style scoped>
.orders-list {
  width: 100%;
  margin: 0 auto;
  padding: 0;
  text-align: center;
}
</style>