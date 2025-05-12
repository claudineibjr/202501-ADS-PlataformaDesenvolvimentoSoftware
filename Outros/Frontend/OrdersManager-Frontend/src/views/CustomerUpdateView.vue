<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'
import api from '@/api'
import { routes } from '@/router'
import type { CustomerType } from '@/models/Customer'

type CustomerViewProps = {
  id: string
}
const props = defineProps<CustomerViewProps>()
const customerId = props.id

const customer = ref<CustomerType>()

const isLoadingCustomer = ref(false)

const nome = ref('')
const email = ref('')
const cpf = ref('')

const router = useRouter()

async function updateCustomer() {
  console.log('Atualizando cliente...')

  try {
    await api.put(`/Clientes/${customerId}`, {
      id: customerId,
      nome: nome.value,
      cpf: cpf.value,
      email: email.value,
    })

    alert('Cliente atualizado com sucesso!')
    router.push(routes.customers)
  } catch (error) {
    alert('Falha ao atualizar cliente')

    console.error({ error }, 'Falha ao atualizar cliente')
  }
}

async function loadCustomer() {
  console.log('Buscando cliente...')

  try {
    isLoadingCustomer.value = true
    const customerResult = await api.get<CustomerType>(
      `/Clientes/${customerId}`,
    )

    console.log({ customerResult }, '[Customer]')

    customer.value = customerResult.data
    nome.value = customer.value.nome
    cpf.value = customer.value.cpf
    email.value = customer.value.email
  } catch (error) {
    alert('Falha ao buscar cliente')

    console.error({ error }, 'Falha ao buscar cliente')
  } finally {
    isLoadingCustomer.value = false
  }
}

onMounted(() => {
  loadCustomer()
})
</script>

<template>
  <div class="form-container">
    <h1>
      Cliente <b>{{ props.id }}</b>
    </h1>

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

    <button @click="updateCustomer">Atualizar</button>
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
