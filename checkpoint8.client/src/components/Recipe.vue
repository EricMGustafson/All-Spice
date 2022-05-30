<template>
  <div class="col-md-4 mt-4 d-flex justify-content-center">
    <div
      :style="{ backgroundImage: `url(${recipe.picture})` }"
      class="recipe-card rounded shadow position-relative"
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
</template>


<script>
export default {
  props: {
    recipe: {
      type: Object,
      required: true,
    }
  },
  setup() {
    return {
      addFavorite() {

      },
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
</style>