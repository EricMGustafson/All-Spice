<template>
  <div
    class="ing-card rounded shadow d-flex flex-column justify-content-between"
  >
    <div>
      <div class="text-center p-2 bg-info rounded square-bottom">
        <h2>Ingredients</h2>
      </div>
      <div class="p-2 f-14 d-flex flex-column step-scroll">
        <div
          class="d-flex justify-content-between p-1"
          v-for="i in ingredients"
          :key="i.id"
        >
          <div class="d-flex">
            <p>{{ i.quantity }}</p>
            <p class="ms-1">
              {{ i.name }}
            </p>
          </div>
          <div>
            <i
              v-if="account.id == i.creatorId"
              class="mdi mdi-delete selectable"
              @click.stop="deleteIngredient(i.id)"
              title="Delete Ingredient"
            ></i>
          </div>
        </div>
      </div>
    </div>
    <div class="step-input">
      <form @submit.prevent="addIngredient" class="d-flex">
        <div class="w-60">
          <label for="newIngredientQuantity" class="form-label"></label>
          <input
            type="text"
            class="form-control inline"
            name="newIngredientQuantity"
            id="newIngredientQuantity"
            aria-describedby="newIngredientQuantity"
            placeholder="Measurement..."
            v-model="formData.quantity"
          />
        </div>
        <div class="input-group">
          <input
            type="text"
            class="form-control square-top"
            placeholder="Item Name..."
            aria-label="Item Name..."
            aria-describedby="button-addon2"
            v-model="formData.name"
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
import { ingredientsService } from '../services/IngredientsService'
export default {
  setup() {
    let formData = ref({})
    return {
      formData,
      async addIngredient() {
        try {
          formData.value.recipeId = AppState.activeRecipe.id
          formData.value.creatorId = AppState.activeRecipe.creatorId
          await ingredientsService.addIngredient(formData.value)
          formData.value = {}
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteIngredient(ingredientId) {
        try {
          if (await Pop.confirm()) {
            await ingredientsService.deleteIngredient(ingredientId, AppState.activeRecipe.id)
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      ingredients: computed(() => AppState.activeIngredients),
      account: computed(() => AppState.account)
    }
  }
}
</script>


<style lang="scss" scoped>
.ing-card {
  width: 100%;
  height: 40vh;
}
p {
  margin-bottom: 0;
}
.w-60 {
  width: 80%;
}
.inline {
  display: inline-block;
}
.step-scroll {
  max-height: 29.6vh !important;
  overflow-y: auto !important;
}
::-webkit-scrollbar {
  width: 1px;
}
</style>