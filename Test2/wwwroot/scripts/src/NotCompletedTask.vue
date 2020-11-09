<template>
  <div>
    <button class="btn-danger" @click="onClicked()" type="button">Incomplete Task</button>
    </div>
</template>
<script>
export default {
   methods: {
    onClicked() {
        this.$emit("Incomplete-Task");
      },  
  },
};
</script>