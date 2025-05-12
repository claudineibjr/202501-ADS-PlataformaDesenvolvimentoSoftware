<script setup lang="ts">
import api from '@/api'
import { onMounted, ref } from 'vue'
import { formatCurrency } from '@/utils/formatCurrency'
import router, { routes } from '@/router'
import type { CustomerType } from '@/models/Customer'

type CustomerViewProps = {
  id: string
}
const props = defineProps<CustomerViewProps>()
const customerId = props.id

const customer = ref<CustomerType>()

const isLoadingCustomer = ref(false)

async function loadCustomer() {
  console.log('Buscando cliente...')

  try {
    isLoadingCustomer.value = true
    const customerResult = await api.get<CustomerType>(
      `/Clientes/${customerId}`,
    )

    console.log({ customerResult }, '[Customer]')

    customer.value = customerResult.data
  } catch (error) {
    alert('Falha ao buscar cliente')

    console.error({ error }, 'Falha ao buscar cliente')
  } finally {
    isLoadingCustomer.value = false
  }
}

async function deleteCustomer() {
  if (confirm('Confirma a exclusão do cliente?')) {
    console.log('Deletado cliente...')

    try {
      isLoadingCustomer.value = true
      await api.delete(`/Clientes/${customerId}`)

      router.push(routes.customers)
    } catch (error) {
      alert('Falha ao deletar cliente')

      console.error({ error }, 'Falha ao deletar cliente')
    } finally {
      isLoadingCustomer.value = false
    }
  }
}

function navigateToCustomerEdit() {
  router.push(`${routes.customer}/${customerId}/atualizar`)
}

onMounted(() => {
  loadCustomer()
})
</script>

<template fluid>
  <div class="customer-page">
    <h1>
      Cliente <b>{{ props.id }}</b>
    </h1>

    <br />
    <br />

    <div v-if="isLoadingCustomer">Carregando...</div>
    <div
      v-else-if="!isLoadingCustomer && Boolean(customer)"
      class="customer-info"
    >
      <div>Nome: {{ customer!.nome }}</div>

      <div>Email: {{ customer!.email }}</div>

      <div>CPF: {{ customer!.cpf }}</div>

      <button @click="navigateToCustomerEdit">Editar cliente</button>
      <button @click="deleteCustomer">Excluir cliente</button>
    </div>
  </div>
</template>

<style scoped>
.customer-page {
  display: flex;
  flex-direction: column;
}

.customer-info {
  display: flex;
  flex-direction: column;
}
</style>
