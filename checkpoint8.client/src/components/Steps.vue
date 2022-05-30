<template>
  <div class="step-card rounded shadow">
    <div class="text-center p-2 bg-info rounded square-bottom">
      <h2>Steps</h2>
    </div>
    <div class="p-2 f-14">
      <span class="d-flex p-1" v-for="s in steps" :key="s.id">
        <p>{{ s.position }}</p>
        <p class="ms-1">
          {{ s.body }}
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
      steps: computed(() => AppState.activeSteps)
    }
  }
}
</script>


<style lang="scss" scoped>
.step-card {
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