<template>
  <div>
    <button class="btn-primary" @click="onClicked()" type="button">All Task</button>
    </div>
</template>
<script>
export default {
   methods: {
    onClicked() {
        this.$emit("All-Task");
      },  
  },
};
</script>