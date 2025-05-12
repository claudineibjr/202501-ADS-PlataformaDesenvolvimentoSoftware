<script setup lang="ts">
import api from '@/api';
import { onMounted, ref } from 'vue';
import type { ProductType } from '@/models/Product';
import { formatCurrency } from '@/utils/formatCurrency';
import router, { routes } from '@/router';

const products = ref<ProductType[]>();

const isLoadingProducts = ref(false);

async function loadProducts() {
  console.log('Buscando produtos...');

  try {
    isLoadingProducts.value = true;
    const productsResult = await api.get<ProductType[]>(`/Produtos/`);

    console.log({ productsResult }, '[Products]');

    products.value = productsResult.data;
  } catch (error) {
    alert("Falha ao buscar produtos");

    console.error({ error }, 'Falha ao buscar produtos');
  } finally {
    isLoadingProducts.value = false;
  }
}

onMounted(() => {
  loadProducts();
});

function navigateToProductDetails(productId: string) {
  router.push(`${routes.product}/${productId}`);
}

</script>

<template fluid>
  <div class="products-list">
    <h1>Produtos</h1>

    <br/><br/>

    <router-link to="/produtos/novo">
      <button>Cadastrar novo produto</button>
    </router-link>

    <br/><br/>

    <div v-if="isLoadingProducts">
      Carregando...
    </div>

    <div v-else-if="!isLoadingProducts && Boolean(products)" class="product-info">
      <table class="table table-striped table-hover">
        <thead class="table-light">
          <tr>
            <th scope="col">#</th>
            <th scope="col">Nome</th>
            <th scope="col">Preço</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" v-bind:key="product.id" @click="navigateToProductDetails(product.id)">
            <th>{{ product.id }}</th>
            <th>{{ product.nome }}</th>
            <th>{{ formatCurrency(product.preco) }}</th>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  
</template>


<style scoped>
.products-list {
  width: 100%;
  margin: 0 auto;
  padding: 0;
  text-align: center;
}
</style>