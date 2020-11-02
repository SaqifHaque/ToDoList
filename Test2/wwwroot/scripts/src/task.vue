<template>
  <div>
    <input
      v-on:click="updateToDo(todo)"
      type="checkbox"
      v-model="todo.status"
    />
    <!-- <span>{{ todo.taskName }}</span> -->
    <input type="text" name="task" v-model="todo.taskName" />
    <button v-on:click="removeToDo(todo)" type="button" name="button">
      Remove
    </button>
    <button v-on:click="editToDo(todo)" type="button" name="button">Edit</button>
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
    removeToDo(todo) {
      fetch("/api/ToDo/" + todo.id, {
        method: "DELETE",
      }).then(() => {
        const todoIndex = this.todos.indexOf(todo);
        this.todos.splice(todoIndex, 1);
      });
    },
    updateToDo(todo) {
        fetch("/api/ToDo/" + todo.id, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                id: todo.id,
                taskName: todo.taskName,
                status: !todo.status,
            })
        })
        .then(response => response.json())
      },
      editToDo(todo) {
          fetch("/api/ToDo/" + todo.id, {
              method: "PUT",
              headers: { "Content-Type": "application/json" },
              body: JSON.stringify({
                  id: todo.id,
                  taskName: todo.taskName,
                  status: todo.status,
              })
          })
              .then(response => response.json())
      },

  },
};
</script>