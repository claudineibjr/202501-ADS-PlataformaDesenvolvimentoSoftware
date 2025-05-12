<script setup lang="ts">
const model = defineModel();

type TextInputProps = {
  label: string;
  type: 'email' | 'password';
  id: string;
  helperText?: string;
};

defineProps<TextInputProps>();

</script>

<template>
  <div class="mb-3">
    <label :for="id" class="form-label">{{ label }}</label>
    <input :type="type" class="form-control" :id="id" v-model="model">
    <div :id="`${id}-helper`" class="form-text">{{ helperText }}</div>
  </div>
</template>