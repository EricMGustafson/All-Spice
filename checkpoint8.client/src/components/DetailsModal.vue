<template>
  <!-- Button trigger modal -->

  <!-- Modal -->
  <div
    class="modal fade"
    tabindex="-1"
    aria-labelledby="recipeDetails"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid gx-0">
            <div class="row">
              <div class="col-md-4 gx-0"><slot name="picture"></slot></div>
              <div class="col-md-8">
                <div class="row p-1">
                  <div class="col-12 d-flex justify-content-end">
                    <button
                      type="button"
                      class="btn-close"
                      data-bs-dismiss="modal"
                      aria-label="Close"
                    ></button>
                  </div>
                </div>
                <div class="row px-5">
                  <div class="col-12">
                    <div class="d-flex justify-content-between">
                      <div>
                        <h1 class="modal-title" id="exampleModalLabel">
                          <slot name="title"></slot>
                        </h1>
                      </div>
                      <div>
                        <h5 class="rounded-pill bg-info px-3 pb-1">
                          <slot name="category"></slot>
                        </h5>
                      </div>
                    </div>
                    <h4><slot name="subTitle"></slot></h4>
                  </div>
                </div>
                <div class="row px-5 py-3">
                  <div class="col-md-6 d-flex justify-content-center my-4">
                    <slot name="steps"></slot>
                  </div>
                  <div class="col-md-6 d-flex justify-content-center my-4">
                    <slot name="ingredients"></slot>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12 d-flex justify-content-end">
                    <div>
                      <p class="me-1"><slot name="creator"></slot></p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>

export default {
  setup() {

    return {
    }
  }
}
</script>


<style lang="scss" scoped>
@media (min-width: 576px) {
  .modal-dialog {
    max-width: 60vw;
    margin: 1.75rem auto;
  }
}
.modal {
  top: 20vh;
}
.modal-body {
  padding: 0 !important;
}
</style>