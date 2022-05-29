<template>
<div class="row justify-content-center">
  <div class="col-md-12 intro rounded shadow-lg position-relative">
    <div class="pt-2 d-flex justify-content-between">
      <div>
        <Login />
      </div>
      <div>
        <form submit="" class="d-flex justify-content-end">
          <div class="input-group mb-3 ">
            <input type="text" class="form-control" placeholder="Search..." aria-label="Search..." aria-describedby="button-addon2">
            <button class="btn btn-outline-secondary bg-light" type="submit" id="button-addon2"><i class="mdi mdi-magnify"></i></button>
          </div>
        </form>
      </div>
    </div>
    <div class="intro-text text-light d-flex flex-column justify-content-center align-items-center">
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
<div class="row mt-6 flex-wrap scrollable-y">
  <Recipe v-for="r in recipes" :key="r.id" :recipe="r"/>
</div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { recipesService } from '../services/RecipesService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await recipesService.getAllRecipes()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
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
  background-image: url('https://static.onecms.io/wp-content/uploads/sites/9/2020/06/29/creative-pandemic-cooking-essay-FT-BLOG0620.jpg');
  object-fit: center;
  height: 35vh;
  width: 97vw;
  margin-top: 2.5vh;
}
.intro-text{
  height: 25vh;
}
h1{
  text-shadow: 4px 4px #0e0e0e;
}
p{
  margin-bottom: 0rem !important;
  text-shadow: 2.5px 2.5px #0e0e0e;
}
.filter-bar {
  width: 33%;
  height: 8vh;
  right: 33%;
}
.mt-6 {
  margin-top: 4em;
}
::-webkit-scrollbar{
  width: 1px;
}
</style>
