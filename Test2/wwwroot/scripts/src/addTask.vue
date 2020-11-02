<template>
    <form v-on:submit.prevent="addTodo">
      <label for="newTodo">Add Task</label>
        <input
        v-model="newTodo"
        type="text"
        name="newTodo"
        id="newTodo"
        value=""
        />
        <button v-on:click="addTodo()" type="submit" name="button">Add</button>
    </form> 
</template>
<script>
export default {
    data() {
    return {
      newTodo: "",
      todos: [],
    };
  },
   methods: {
       addTodo() {
        fetch("https://localhost:44398/api/ToDo", {
                method: "POST",
                body: JSON.stringify({ taskName: this.newTodo }),
            })
            .then(() => {})
        this.newTodo = '';
    },
}
};
</script>