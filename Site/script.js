new Vue({
    el: "#app",
    data: {
        todoTitle: "",
        todoDesc: "",
        todoStatus: false,
        todos: [
            { title: "Título 1", desc: "Descrição 1", status: false },
            { title: "Título 2", desc: "Descrição 2", status: false },
            { title: "Título 3", desc: "Descrição 3", status: true }
        ],
        apiUrl: 'http://localhost:5000/api' // Substitua pelo endereço base da sua API
    },
    methods: {
        toggleTodo(todo) {
            let msg = "Mudar o status da tarefa para ";
            if (todo.status){
                msg += "Pendente?";
            }
            else {
                msg += "Concluído?";
            }
            if (window.confirm(msg)) {
                todo.status = !todo.status;
                this.sortTodos();
            }
        },
        addTodo() {
            if (!this.todoTitle.trim() || this.checkIfTodoExists()) return;
            this.todos.push({
                title: this.todoTitle,
                desc: this.todoDesc,
                status: this.todoStatus
            });
            this.todoTitle = "";
            this.todoDesc = "";
            this.todoStatus = false;
            this.sortTodos();
        },
        delTodo(todo) {
            if (window.confirm('Excluir tarefa?')) {
                this.todos = this.todos.filter(el => el.title !== todo.title);
            }
        },
        editTodo(todo) {
            let newTitle = prompt('Novo título:', todo.title);
            if (newTitle) {
                todo.title = newTitle;
            }
        },
        sortTodos() {
            this.todos.sort((a, b) => a.status - b.status);
        },
        checkIfTodoExists() {
            return this.todos.some((todo) => todo.title === this.todoTitle.trim());
        }
    },
    computed: {
        filteredTodos() {
            return this.todos.filter(
                todo => todo.title.toLowerCase().match(this.todoTitle.toLowerCase())
            );
        }
    }
});