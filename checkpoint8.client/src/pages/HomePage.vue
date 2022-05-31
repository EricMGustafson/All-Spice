<template>
  <div class="row justify-content-center">
    <div class="col-md-12 intro rounded shadow position-relative">
      <div class="intro-login pt-2 d-flex justify-content-between">
        <div>
          <Login />
        </div>
        <div>
          <form submit="" class="d-flex justify-content-end">
            <div class="input-group mb-3">
              <input
                type="text"
                class="form-control"
                placeholder="Search..."
                aria-label="Search..."
                aria-describedby="button-addon2"
              />
              <button
                class="btn btn-outline-secondary bg-light"
                type="submit"
                id="button-addon2"
              >
                <i class="mdi mdi-magnify"></i>
              </button>
            </div>
          </form>
        </div>
      </div>
      <div
        class="
          intro-text
          text-light
          d-flex
          flex-column
          justify-content-center
          align-items-center
        "
      >
        <h1 class="f-28">All-Spice</h1>
        <p class="f-16">Cherish Your Family</p>
        <p class="f-16">And Their Cooking</p>
      </div>
      <div class="position-absolute filter-bar bg-light shadow rounded">
        <div class="d-flex justify-content-around h-100 align-items-center">
          <h4>All</h4>
          <h4>My Recipes</h4>
          <h4>Favorites</h4>
        </div>
      </div>
    </div>
  </div>
  <div class="row mt-4 flex-wrap scrollable-y">
    <Recipe v-for="r in recipes" :key="r.id" :recipe="r" />
  </div>
  <div
    class="position-absolute add-btn bg-info text-center selectable"
    data-bs-toggle="modal"
    data-bs-target="#newRecipeModal"
  >
    <i class="mdi mdi-plus mdi-48px"></i>
  </div>
  <RecipeModal />
</template>

<script>
import { computed, onMounted, watchEffect } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { recipesService } from '../services/RecipesService'
import { AppState } from '../AppState'
import { stepsService } from '../services/StepsService'
import { ingredientsService } from '../services/IngredientsService'
import { favoritesService } from '../services/FavoritesService'
export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await recipesService.getAllRecipes()
        await favoritesService.getAccountFavorites()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    }),
      watchEffect(async () => {
        if (AppState.activeRecipe != null) {

          try {
            await stepsService.getStepsForRecipe(AppState.activeRecipe.id)
            await ingredientsService.getIngredientsForRecipe(AppState.activeRecipe.id)
          } catch (error) {
            logger.error(error)
            Pop.toast(error.message, 'error')
          }
        }
      })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.intro {
  background-image: url("https://static.onecms.io/wp-content/uploads/sites/9/2020/06/29/creative-pandemic-cooking-essay-FT-BLOG0620.jpg");
  object-fit: center;
  height: 35vh;
  width: 97vw;
  margin-top: 2.5vh;
}
.intro-login {
  height: 5vh;
}
.intro-text {
  height: 26vh;
}
h1 {
  text-shadow: 4px 4px #0e0e0e;
}
p {
  margin-bottom: 0rem !important;
  text-shadow: 2.5px 2.5px #0e0e0e;
}
.filter-bar {
  width: 33%;
  height: 7vh;
  right: 33%;
  z-index: 10;
}
.mt-6 {
  margin-top: 4em;
}
::-webkit-scrollbar {
  width: 1px;
}
.modal {
  top: 30vh;
}
.add-btn {
  bottom: 1%;
  border-radius: 50%;
  width: 4rem;
  right: 1%;
}
</style>
