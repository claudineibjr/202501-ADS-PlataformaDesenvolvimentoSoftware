<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import api from '@/api'
import { routes } from '@/router'

const nome = ref('')
const email = ref('')
const cpf = ref('')

const router = useRouter()

async function createCustomer() {
  console.log('Cadastrando cliente...')

  try {
    await api.post('/Clientes', {
      id: '',
      nome: nome.value,
      cpf: cpf.value,
      email: email.value,
    })

    alert('Cliente cadastrado com sucesso!')
    router.push(routes.customers)
  } catch (error) {
    alert('Falha ao cadastrar cliente')

    console.error({ error }, 'Falha ao cadastrar cliente')
  }
}
</script>

<template>
  <div class="form-container">
    <h2>Cadastro de Cliente</h2>

    <label>
      Nome:
      <input v-model="nome" type="text" />
    </label>

    <label>
      Email:
      <input v-model="email" type="email" />
    </label>

    <label>
      CPF
      <input v-model="cpf" type="text" />
    </label>
    <button @click="createCustomer">Cadastrar</button>
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
