<script setup lang="ts">
import Card from 'primevue/card';
import Button from 'primevue/button';

</script>

<template>
  <main class="p-3">
    <div class="row">
      <div class="col-sm-12">
        <div class="card mt-3 text-center">
          <Card>
              <template #title >Cubits</template>
              <template #subtitle >Curso .NET Avanzado</template>
              <template #content>
                <div class="card flex justify-content-center flex-wrap gap-3">
                  <router-link
                    to="/products"
                    custom
                    v-slot="{ navigate }">
                    <Button label="Productos" severity="success" @click="navigate" role="link" />
                  </router-link>
                </div>
              </template>
          </Card>
        </div>
      </div>
    </div>
  </main>
</template>
