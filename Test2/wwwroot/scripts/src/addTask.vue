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
        <button v-on:click="addTodo()" type="button" name="button">Add</button>
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
        fetch("/api/ToDo", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ taskName: this.newTodo })
            })
            .then(response => response.json())
        this.newTodo = '';
    },
}
};
</script>