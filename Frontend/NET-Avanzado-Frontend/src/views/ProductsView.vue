<script setup lang="ts">
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import { onMounted, ref } from "vue";
import Button from 'primevue/button';

const products = ref([]);

const getProductList = async () => {
    const res = await fetch('http://localhost:5000/api/products'); // le pego a la api de productos
    const data = await res.json();
    products.value = data.productList;
}

onMounted(async () => {
    await getProductList();
});

</script>

<template>
    <div class="grid">
        <div class="col-12">
            <h2 class="text-center">Productos</h2>
            <div class="card">
                <DataTable :value="products" paginator :rows="5" :rowsPerPageOptions="[5, 10, 20, 50]" tableStyle="min-width: 50rem" showGridlines>
                    <Column field="serialCode" header="Código"></Column>
                    <Column field="name" header="Nombre"></Column>
                    <Column field="description" header="Descripción"></Column>
                    <Column field="price" header="Precio"></Column>
                    <Column field="stock" header="Stock"></Column>
                </DataTable>
            </div>
        </div>
    </div>
    <div class="col-12">
        <router-link
            to="/"
            custom
            v-slot="{ navigate }">
            <Button label="Home" severity="success" @click="navigate" role="link" />
        </router-link>
    </div>
</template>
