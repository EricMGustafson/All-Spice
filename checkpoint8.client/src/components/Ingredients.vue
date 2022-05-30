<template>
  <div class="ing-card rounded shadow">
    <div class="text-center p-2 bg-info rounded square-bottom">
      <h2>Ingredients</h2>
    </div>
    <div class="p-2 f-14">
      <span class="d-flex p-1" v-for="i in ingredients" :key="i.id">
        <p>{{ i.quantity }}</p>
        <p class="ms-1">
          {{ i.name }}
        </p>
      </span>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      ingredients: computed(() => AppState.activeIngredients),
    }
  }
}
</script>


<style lang="scss" scoped>
.ing-card {
  width: 100%;
  height: 40vh;
}
.scrolL-y {
  max-height: 20vh;
  overflow-y: auto;
}
p {
  margin-bottom: 0;
}
</style>