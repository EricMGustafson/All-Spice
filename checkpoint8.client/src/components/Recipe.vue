<template>
  <div class="col-md-4 mt-5 d-flex justify-content-center">
    <div
      :style="{ backgroundImage: `url(${recipe.picture})` }"
      class="recipe-card rounded shadow position-relative selectable"
      data-bs-toggle="modal"
      :data-bs-target="'#rid-' + recipe.id"
      @click.stop="setActiveRecipe(recipe)"
    >
      <div class="h-100 d-flex flex-column justify-content-between">
        <div class="d-flex justify-content-between">
          <div class="p-2">
            <h5 class="rounded-pill bg-info px-3 pb-1">
              {{ recipe.category }}
            </h5>
          </div>
          <div class="bg-info rounded px-2 pt-1" @click.stop="addFavorite">
            <h2>
              <i v-if="favorite" class="mdi mdi-star text-danger"></i>
              <i v-else class="mdi mdi-star-outline text-light"></i>
            </h2>
          </div>
        </div>
        <div class="rounded bg-info m-2">
          <h2 class="ms-2 mb-0">{{ recipe.title }}</h2>
          <h3 class="ms-2 mb-0">{{ recipe.subTitle }}</h3>
        </div>
      </div>
    </div>
  </div>
  <DetailsModal :id="'rid-' + recipe.id">
    <template #picture>
      <div
        class="modal-pic square-right rounded"
        :style="{ backgroundImage: `url(${recipe.picture})` }"
      ></div>
    </template>
    <template #title>{{ recipe.title }}</template>
    <template #category>{{ recipe.category }}</template>
    <template #subTitle>{{ recipe.subTitle }}</template>
    <template #creator>Submitted by: {{ recipe.creator.name }}</template>
    <template #steps><Steps /></template>
    <template #ingredients><Ingredients /></template>
  </DetailsModal>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
export default {
  props: {
    recipe: {
      type: Object,
      required: true,
    }
  },
  setup() {
    return {
      setActiveRecipe(recipe) {
        AppState.activeRecipe = recipe
        logger.log(AppState.activeRecipe.id)
      },
      addFavorite() {

      }
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-card {
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  height: 50vh;
  width: 90%;
}
.pt-25 {
  padding-top: 20px;
}
.modal-pic {
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  height: 100%;
  width: 100%;
}
p {
  margin-bottom: 0;
}
</style>