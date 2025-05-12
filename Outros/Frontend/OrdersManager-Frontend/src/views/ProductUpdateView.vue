<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import api from '@/api';
import { routes } from '@/router';
import type { ProductType } from '@/models/Product';

type ProductViewProps = {
  id: string;
};
const props = defineProps<ProductViewProps>();
const productId = props.id;

const product = ref<ProductType>();

const isLoadingProduct = ref(false);

const nome = ref('');
const preco = ref(0);

const router = useRouter();

async function updateProduct() {
  console.log('Atualizando produto...');

  try {
    await api.put(`/Produtos/${productId}`, {
      id: productId,
      nome: nome.value,
      preco: preco.value
    });

    alert("Produto atualizado com sucesso!");
    router.push(routes.products);
  } catch (error) {
    alert("Falha ao atualizar produto");

    console.error({ error }, 'Falha ao atualizar produto');
  }
}

async function loadProduct() {
  console.log('Buscando produto...');

  try {
    isLoadingProduct.value = true;
    const productResult = await api.get<ProductType>(`/Produtos/${productId}`);

    console.log({ productResult }, '[Product]');

    product.value = productResult.data;
    nome.value = product.value.nome;
    preco.value = product.value.preco;
  } catch (error) {
    alert("Falha ao buscar produto");

    console.error({ error }, 'Falha ao buscar produto');
  } finally {
    isLoadingProduct.value = false;
  }
}

onMounted(() => {
  loadProduct();
});

</script>

<template>
  <div class="form-container">
    <h1>Produto <b>{{ props.id }}</b></h1>
    
    <label>
      Nome:
      <input v-model="nome" type="text" />
    </label>

    <label>
      Preço:
      <input v-model="preco" type="number" />
    </label>

    <button @click="updateProduct">Atualizar</button>
  </div>
</template>

<style scoped>

.form-container {
  display: flex;
  flex-direction: column;
  gap: 10px;
  width: 300px;
}

</style>
