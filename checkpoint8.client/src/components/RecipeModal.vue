<template>
  <div
    class="modal fade"
    id="newRecipeModal"
    tabindex="-1"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="bg-info d-flex justify-content-between p-2">
          <h3 class="text-light" id="exampleModalLabel">New Recipe</h3>
          <h3>
            <i data-bs-dismiss="modal" class="mdi mdi-close selectable"></i>
          </h3>
        </div>
        <div class="p-2">
          <form @submit.prevent="createRecipe">
            <div class="d-flex w-100 justify-content-between">
              <div class="mb-3 w-45">
                <label
                  for="newRecipeTitle"
                  class="form-label visually-hidden"
                ></label>
                <input
                  type="text"
                  class="form-control"
                  name="newRecipeTitle"
                  id="newRecipeTitle"
                  aria-describedby="newRecipeTitle"
                  placeholder="Title..."
                  v-model="formData.title"
                  required
                />
              </div>
              <div class="mb-3 w-45">
                <label for="" class="form-label"></label>
                <select
                  class="form-control inline"
                  name="newRecipeCategory"
                  id="newRecipeCategory"
                  required
                  v-model="formData.category"
                >
                  <option selected>Category...</option>
                  <option value="Breakfast">Breakfast</option>
                  <option value="Lunch">Lunch</option>
                  <option value="Dinner">Dinner</option>
                  <option value="Snack">Snack</option>
                  <option value="Treat">Treat</option>
                  <option value="Party">Party</option>
                </select>
              </div>
            </div>
            <div>
              <div class="mb-3">
                <label for="newRecipePicture" class="form-label"></label>
                <input
                  type="url"
                  class="form-control inline"
                  name="newRecipePicture"
                  id="newRecipePicture"
                  aria-describedby="newRecipePicture"
                  placeholder="Picture URL..."
                  required
                  v-model="formData.picture"
                />
              </div>
            </div>
            <div class="mb-3">
              <label
                for="newRecipeSubTitle"
                class="form-label visually-hidden"
              ></label>
              <input
                type="text"
                class="form-control"
                name="newRecipeSubTitle"
                id="newRecipeSubTitle"
                aria-describedby="newRecipeSubTitle"
                placeholder="SubTitle..."
                required
                v-model="formData.subTitle"
              />
              <small id="newRecipeSubTitleSmall" class="form-text text-muted"
                >Description of Recipe</small
              >
            </div>
            <div class="d-flex justify-content-end p-2">
              <button type="button" class="btn" data-bs-dismiss="modal">
                Close
              </button>
              <button type="submit" class="btn btn-info">Submit</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { ref } from '@vue/reactivity'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { recipesService } from '../services/RecipesService'
import { Modal } from 'bootstrap'
export default {
  setup() {
    let formData = ref({})
    return {
      formData,
      async createRecipe() {
        try {
          await recipesService.createRecipe(formData.value)
          formData = {}
          Modal.getOrCreateInstance(document.getElementById("newRecipeModal")).toggle()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
input:not(:placeholder-shown):valid,
textarea:not(:placeholder-shown):valid,
select:not(:placeholder-shown):valid {
  border: 1px solid #ced4da;
}
input:not(:placeholder-shown):invalid,
textarea:not(:placeholder-shown):invalid,
select:not(:placeholder-shown):invalid {
  border: 1px solid #ced4da;
}
.w-45 {
  width: 45%;
}
.inline {
  display: inline-block !important;
}
</style>