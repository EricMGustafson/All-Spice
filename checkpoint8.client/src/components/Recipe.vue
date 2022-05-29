<template>
  <div class="col-md-4 mt-5 d-flex justify-content-center">
    <div :style="{ backgroundImage: `url(${recipe.picture})`}" class="recipe-card rounded shadow">
      <div class="h-100 d-flex flex-column justify-content-between">
        <div class="d-flex justify-content-between m-3">
          <div class=" rounded-pill bg-info pt-25">
            <h3 class="px-3 mb-0">{{recipe.category}}</h3>
          </div>
          <div class="bg-info rounded-pill px-2">
            <i v-if="favorite" class="mdi mdi-star mdi-48px text-danger"></i>
            <i v-else class="mdi mdi-star-outline mdi-48px text-danger"></i>
          </div>
        </div>
        <div class="rounded-pill bg-info m-3">
            <h2 class="ms-4">{{recipe.title}}</h2>
            <h3 class="ms-4">{{recipe.subTitle}}</h3>  
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
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>
.recipe-card {
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  height: 40vh;
  width: 90%;
  }
.pt-25{
  padding-top: 20px;
}
</style>