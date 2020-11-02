<template>
  <div>
    <input
      v-on:click="updateToDo(todo)"
      type="checkbox"
      v-model="todo.status"
    />
    <!-- <span>{{ todo.taskName }}</span> -->
    <input type="text" name="task" v-model="todo.taskName" />
    <button v-on:click="removeTodo(todo)" type="button" name="button">
      Remove
    </button>
    <button type="button" name="button">Edit</button>
  </div>
</template>
<script>
export default {
  props: ["todo"],
  data() {
    return {
      newTodo: "",
      todos: [],
    };
  },
  methods: {
    removeTodo(todo) {
      fetch("https://localhost:44398/api/ToDo/" + todo.id, {
        method: "DELETE",
      }).then(() => {
        const todoIndex = this.todos.indexOf(todo);
        this.todos.splice(todoIndex, 1);
      });
    },
    updateToDo(todo) {
      axios
        .put("/api/ToDO/" + todo.id, {
          status: !todo.status,
        })
        .then(() => {});
    },
  },
};
</script>