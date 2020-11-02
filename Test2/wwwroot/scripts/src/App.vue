<template>
  <div>
    <Create></Create>
    <ul>
      <li v-for="todo in todos">
        <Task :todo="todo"></Task>
      </li>
    </ul>
    <h1>hi</h1>
  </div>
</template>
<script>
import Task from "./task.vue";
import Create from "./addTask.vue";

export default {
  components: { Task, Create },
  data() {
    return {
      todos: [],
    };
  },
  mounted() {
    fetch("/api/ToDo", {
      method: "GET",
    })
      .then((response) => response.json())
      .then((data) => {
        this.todos = data;
      })
      .catch(() =>
        console.log("Can’t access " + url + " response. Blocked by browser?")
      );
  },
};
</script>