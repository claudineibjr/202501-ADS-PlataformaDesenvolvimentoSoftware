<script setup lang="ts">
import api from '@/api';
import TextInput from '@/components/TextInput.vue';
import router, { routes } from '@/router';
import type { AxiosResponse } from 'axios';
import { ref } from 'vue'

const email = ref("");
const password = ref("");

type SignInResultType = string;
type SignInParametersType = { email: string; password: string; };

async function submit() {
  const signInParameters = { email: email.value, password: password.value };
  
  console.log({ signInParameters }, 'Parâmetros do login');

  try {
    const signInResult = await api.post<SignInResultType, AxiosResponse<SignInResultType>, SignInParametersType>('/auth/signIn', signInParameters);
    
    window.localStorage.setItem("AUTH_TOKEN", signInResult.data);

    router.replace(routes.orders);
  } catch (error) {
    alert("Falha no login");

    console.error({ error }, 'Falha no login');
  }
}
</script>

<template>
  <form>
    <TextInput label="Nome de usuário" type="email" v-model="email" id="email" />
    <TextInput label="Senha" type="password" v-model="password" id="password" />

    <button type="button" class="btn btn-primary" @click="submit">Entrar</button>
  </form>  
</template>
