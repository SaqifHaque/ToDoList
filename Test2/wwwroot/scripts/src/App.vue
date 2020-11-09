<template>
  <div>
    <AllTask @All-Task="loadAllTask()"></AllTask>
    <DoneTask @Done-Task="completedTask()"></DoneTask>
    <IncompleteTask @Incomplete-Task="incompleteTask()"></IncompleteTask>
    <TaskCreateView @new-task="onNewTaskAdded"></TaskCreateView>
    <ul>
      <div v-if="!sortedTodos.length">
      <li v-for="todo in todos">
        <TaskView :todo="todo" @taskDeleted="onTaskDeleted()"></TaskView>
      </li>
      </div>
      <div v-else>
        <li v-for="todo in sortedTodos">
        <TaskView :todo="todo" @taskDeleted="onTaskDeleted()"></TaskView>
      </li>
        </div>
    </ul>
  </div>
</template>
<script>
import TaskCreateView from "./TaskCreateView.vue";
import TaskView from "./TaskView.vue";
import DoneTask from "./DoneTask.vue";
import AllTask from "./AllTask.vue";
import IncompleteTask from "./NotCompletedTask.vue";

export default {
  components: { TaskCreateView, TaskView ,DoneTask, AllTask, IncompleteTask },
  data() {
    return {
      todos: [],
      sortedTodos: [],
    };
  },
  mounted() {
    this.loadList();
  },
  methods: {
    sortTask(par){
      this.sortedTodos = this.todos;
      return this.sortedTodos.filter(todo =>{
          return todo.status == par;
    })
    },
    incompleteTask(){
      this.sortedTodos = this.sortTask(false);
    },
    loadAllTask(){
      this.sortedTodos = [];
      this.loadList();
    },
    completedTask(){
        this.sortedTodos = this.sortTask(true);
    },
    onNewTaskAdded() {
      this.loadList();
    },
    onTaskDeleted() {
      this.loadList();
    },
    loadList() {
      console.log('load list');
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
  },
};
</script>