<script setup lang="ts">
import api from '@/api'
import { onMounted, ref } from 'vue'
import { formatCurrency } from '@/utils/formatCurrency'
import router, { routes } from '@/router'
import type { CustomerType } from '@/models/Customer'

const customers = ref<CustomerType[]>()

const isLoadingCustomers = ref(false)

async function loadCustomers() {
  console.log('Buscando clientes...')

  try {
    isLoadingCustomers.value = true
    const customersResult = await api.get<CustomerType[]>(`/Clientes/`)

    console.log({ customersResult }, '[Customers]')

    customers.value = customersResult.data
  } catch (error) {
    alert('Falha ao buscar clientes')

    console.error({ error }, 'Falha ao buscar clientes')
  } finally {
    isLoadingCustomers.value = false
  }
}

onMounted(() => {
  loadCustomers()
})

function navigateToCustomerDetails(customerId: string) {
  router.push(`${routes.customer}/${customerId}`)
}
</script>

<template fluid>
  <div class="customers-list">
    <h1>Clientes</h1>

    <br /><br />

    <router-link to="/clientes/novo">
      <button>Cadastrar novo cliente</button>
    </router-link>

    <br /><br />

    <div v-if="isLoadingCustomers">Carregando...</div>

    <div
      v-else-if="!isLoadingCustomers && Boolean(customers)"
      class="customer-info"
    >
      <table class="table table-striped table-hover">
        <thead class="table-light">
          <tr>
            <th scope="col">#</th>
            <th scope="col">Nome</th>
            <th scope="col">Preço</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="customer in customers"
            v-bind:key="customer.id"
            @click="navigateToCustomerDetails(customer.id)"
          >
            <th>{{ customer.id }}</th>
            <th>{{ customer.nome }}</th>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<style scoped>
.customers-list {
  width: 100%;
  margin: 0 auto;
  padding: 0;
  text-align: center;
}
</style>
