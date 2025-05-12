<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import api from '@/api';
import { routes } from '@/router';

const nome = ref('');
const preco = ref(0);

const router = useRouter();

async function createProduct() {
  console.log('Cadastrando produto...');

  try {
    await api.post('/Produtos', {
      id: '',
      nome: nome.value,
      preco: preco.value
    });

    alert("Produto cadastrado com sucesso!");
    router.push(routes.products);
  } catch (error) {
    alert("Falha ao cadastrar produto");

    console.error({ error }, 'Falha ao cadastrar produto');
  }
}
</script>

<template>
  <div class="form-container">
    <h2>Cadastro de Produto</h2>

    <label>
      Nome:
      <input v-model="nome" type="text" />
    </label>

    <label>
      Preço:
      <input v-model="preco" type="number" />
    </label>

    <button @click="createProduct">Cadastrar</button>
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
