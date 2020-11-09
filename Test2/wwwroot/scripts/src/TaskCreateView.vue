<template>
  <form v-on:submit.prevent="onAddClicked">
    <label>Add Task</label>
    <input type="text" v-model="task" />
    <button @click="onAddClicked()" type="button">Add</button>
  </form>
</template>
<script>
export default {
  data() {
    return {
      task: "",
    };
  },
  methods: {
    onAddClicked() {
      fetch("/api/ToDo", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ taskName: this.task }),
      }).then((response) => {
        console.log('task created');
        this.$emit("new-task", this.task);
        this.task = "";
      });
    },

  },
};
</script>