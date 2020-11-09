<template>
  <div>
    <button class="btn-info" @click="onClicked()" type="button">Completed Task</button>
    </div>
</template>
<script>
export default {
   methods: {
    onClicked() {
        this.$emit("Done-Task");
      },  
  },
};
</script>