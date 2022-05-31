<template>
  <div
    class="step-card rounded shadow d-flex flex-column justify-content-between"
  >
    <div>
      <div class="text-center p-2 bg-info rounded square-bottom">
        <h2>Steps</h2>
      </div>
      <div class="p-2 f-14 d-flex flex-column step-scroll">
        <div
          class="d-flex justify-content-between p-1"
          v-for="s in steps"
          :key="s.id"
        >
          <div class="d-flex">
            <p>{{ s.position }}</p>
            <p class="ms-2">
              {{ s.body }}
            </p>
          </div>
          <div>
            <i
              v-if="account.id == i.creatorId"
              class="mdi mdi-delete selectable"
              @click.stop="deleteStep(s.id)"
              title="Delete Step"
            ></i>
          </div>
        </div>
      </div>
    </div>
    <div class="step-input">
      <form @submit.prevent="addStep()" class="d-flex">
        <div class="w-10">
          <label
            for="newStepPosition"
            class="visually-hidden form-label"
          ></label>
          <input
            type="number"
            class="form-control square-top square-right inline"
            name="newStepPosition"
            id="newStepPosition"
            aria-describedby="helpId"
            placeholder="Step"
            required
            v-model="formData.position"
          />
        </div>
        <div class="input-group">
          <input
            type="text"
            class="form-control square-top square-left"
            placeholder="Step instructions..."
            aria-label="Step instructions..."
            aria-describedby="button-addon2"
            required
            v-model="formData.body"
          />
          <button
            class="btn btn-outline-secondary bg-light square-top"
            type="submit"
            id="button-addon2"
          >
            <i class="mdi mdi-plus"></i>
          </button>
        </div>
      </form>
    </div>
  </div>
</template>


<script>
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { stepsService } from '../services/StepsService'
export default {
  setup() {
    let formData = ref({})
    return {
      formData,
      async addStep() {
        try {
          formData.value.recipeId = AppState.activeRecipe.id
          formData.value.creatorId = AppState.activeRecipe.creatorId
          await stepsService.addStep(formData.value)
          formData.value = {}
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteStep(stepId) {
        try {
          if (await Pop.confirm()) {
            await stepsService.deleteStep(stepId, AppState.activeRecipe.id)
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      steps: computed(() => AppState.activeSteps),
      account: computed(() => AppState.account)
    }
  }
}
</script>


<style lang="scss" scoped>
.step-card {
  width: 100%;
  height: 40vh;
}
p {
  margin-bottom: 0;
}
.w-10 {
  width: 35%;
}
.step-scroll {
  max-height: 29.6vh !important;
  overflow-y: auto !important;
}
::-webkit-scrollbar {
  width: 1px;
}
.inline {
  display: inline-block;
}
input:not(:placeholder-shown):valid,
textarea:not(:placeholder-shown):valid,
select:not(:placeholder-shown):valid {
  border: 1px solid #ced4da;
}
</style>