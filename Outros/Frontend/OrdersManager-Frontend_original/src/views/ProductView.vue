<script setup lang="ts">
import api from '@/api';
import { onMounted, ref } from 'vue';
import type { ProductType } from '@/models/Product';
import { formatCurrency } from '@/utils/formatCurrency';

const backendURL = import.meta.env.VITE_BACKEND_URL;

type ProductViewProps = {
  id: string;
};
const props = defineProps<ProductViewProps>();
const productId = props.id;

const product = ref<ProductType>();
const newImage = ref();

const isLoadingProduct = ref(false);
const isLoadingProductUpload = ref(false);

async function loadProduct() {
  console.log('Buscando produto...');

  try {
    isLoadingProduct.value = true;
    const productResult = await api.get<ProductType>(`/product/${productId}`);

    console.log({ productResult }, '[Product]');

    product.value = productResult.data;
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

function onFileChange(event: Event) {
  const target = event.target as HTMLInputElement;

  console.log({ files: target.files });

  if (target?.files && target?.files.length > 0) {
    console.log("Imagem salva");
    newImage.value = target.files[0];
  }
}

async function uploadImage() {
  console.log('Salvando imagem do produto...');

  const oldImageUrl = product.value?.imageUrl;

  try {
    if (!newImage.value) return;
    product.value!.imageUrl = undefined;

    isLoadingProductUpload.value = true;

    const formData = new FormData();
    formData.append('file', newImage.value);

    await api.post<string>(`/product/${productId}/UploadImage`, formData, {
      headers: { 'Content-Type': 'multipart/form-data' },
    });

    location.reload();
  } catch (error) {
    product.value!.imageUrl = oldImageUrl;

    alert("Falha ao salvar imagem do produto");

    console.error({ error }, 'Falha ao salvar imagem do produto');
  } finally {
    isLoadingProductUpload.value = false;
  }
}

</script>

<template fluid>
  <div class="product-page">
    Product {{ props.id }}

    <br/>
    <br/>

    <div v-if="isLoadingProduct">
      Loading...
    </div>
    <div v-else-if="!isLoadingProduct && Boolean(product)" class="product-info">
      <div>
        Nome: {{ product!.name }}
      </div>
      
      <div>
        Valor: {{ formatCurrency(product!.price) }}
      </div>

      <div v-if="isLoadingProductUpload">
        Loading...
      </div>

      <div v-else>
        <div v-if="product!.imageUrl">
          <img :src="`${backendURL}/${product?.imageUrl}`">
        </div>
        <div v-else>Sem imagem</div>

        <div>
          <input type="file" @change="onFileChange" />
          <button type="button" @click="uploadImage">Upload</button>
        </div>
      </div>
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