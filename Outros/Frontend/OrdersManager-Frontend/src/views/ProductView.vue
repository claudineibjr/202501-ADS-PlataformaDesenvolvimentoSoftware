<script setup lang="ts">
import api from '@/api';
import { onMounted, ref } from 'vue';
import type { ProductType } from '@/models/Product';
import { formatCurrency } from '@/utils/formatCurrency';
import router, { routes } from '@/router';

type ProductViewProps = {
  id: string;
};
const props = defineProps<ProductViewProps>();
const productId = props.id;

const product = ref<ProductType>();

const isLoadingProduct = ref(false);

async function loadProduct() {
  console.log('Buscando produto...');

  try {
    isLoadingProduct.value = true;
    const productResult = await api.get<ProductType>(`/Produtos/${productId}`);

    console.log({ productResult }, '[Product]');

    product.value = productResult.data;
  } catch (error) {
    alert("Falha ao buscar produto");

    console.error({ error }, 'Falha ao buscar produto');
  } finally {
    isLoadingProduct.value = false;
  }
}

async function deleteProduct() {
  if (confirm("Confirma a exclusão do produto?")) {
    console.log('Deletado produto...');

    try {
      isLoadingProduct.value = true;
      await api.delete(`/Produtos/${productId}`);

      router.push(routes.products);
    } catch (error) {
      alert("Falha ao deletar produto");

      console.error({ error }, 'Falha ao deletar produto');
    } finally {
      isLoadingProduct.value = false;
    }
  }
}

function navigateToProductEdit() {
  router.push(`${routes.product}/${productId}/atualizar`);
}

onMounted(() => {
  loadProduct();
});

</script>

<template fluid>
  <div class="product-page">
    <h1>Produto <b>{{ props.id }}</b></h1>

    <br/>
    <br/>

    <div v-if="isLoadingProduct">
      Carregando...
    </div>
    <div v-else-if="!isLoadingProduct && Boolean(product)" class="product-info">
      <div>
        Nome: {{ product!.nome }}
      </div>
      
      <div>
        Valor: {{ formatCurrency(product!.preco) }}
      </div>

      <button @click="navigateToProductEdit">Editar produto</button>
      <button @click="deleteProduct">Excluir produto</button>
    </div>
  </div>
  
</template>


<style scoped>
.product-page {
  display: flex;
  flex-direction: column;
}

.product-info {
  display: flex;
  flex-direction: column;
}
</style>