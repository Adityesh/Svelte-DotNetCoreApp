<script>
	import { onMount } from "svelte";
	import { getTodos, markTodoAsComplete, addTodo, deleteTodo } from "./utils";
	import Todo from "./Todo.svelte";
	import Loader from "./Loader.svelte";
	import Input from "./Input.svelte";
	import Toast from "./Toast.svelte";
	let isLoading = false;
	let isError = false;
	let message = "";

	$: {
		if (isError) {
			setTimeout(() => {
				isError = false;
			}, 1500);
		}

		console.log(todos);
	}
	let todos = [];

	function markAsComplete(id) {
		isLoading = true;
		markTodoAsComplete(id)
			.then(({ error, message }) => {
				if (error) {
					isLoading = false;
					isError = true;
					message = error;
					return;
				}

				isLoading = false;
				fetchTodos();
				
			})
			.catch((err) => {
				isLoading = false;
				isError = true;
				message = err;
				return;
			});

		todos = todos;
	}

	function detectEnterKey(e, input) {
		if (!e) e = window.event;
		var keyCode = e.code || e.key;
		if (keyCode == "Enter") {
			// Enter pressed
			addTodoToList(input);
		}
	}

	function addTodoToList(input) {
		if (input.length === 0) {
			message = "Task cannot be empty";
			isError = true;
			return;
		}
		let dup = false;
		todos.forEach((todo) => {
			if (todo.task === input) {
				message = "Task already present";
				isError = true;
				dup = true;
			}
		});

		if (dup) return;

		addTodo(input).then(({error, message}) => {
			
			if(error) {
				isError = true;
				message = message;
				isLoading = false;
				return;
			}

			fetchTodos();
		});

	}

	function fetchTodos() {
		getTodos()
					.then((result) => {
						isLoading = false;
						todos = result;
					})
					.catch((err) => {
						isLoading = false;
						message = err;
						isError = true;
					});
	}

	function deleteTodoFromList(id) {
		isLoading = true;
		deleteTodo(id)
			.then(({error, message}) => {
				isLoading = false;
				if(error) {
					isError = true;
					message = message;
					return;
				}

				fetchTodos();
			})
			.catch(err => {
				isError = true;
				message = err;
				isLoading = false;
			})
	}

	onMount(() => {
		isLoading = true;
		fetchTodos();
	});
</script>

<div class="App">
	<h1 class="header">To-do List with Svelte</h1>
	<Input {detectEnterKey} {addTodoToList} />
	<ul class="todos">
		{#if todos}
			{#each todos as todo, index}
				<Todo {todo} {markAsComplete} {index} {deleteTodoFromList}/>
			{/each}
		{/if}
	</ul>

	{#if isLoading}
		<Loader />
	{/if}

	{#if isError}
		<Toast {message} />
	{/if}
</div>

<style>
	.header {
		width: 100%;
		height: 80px;
		display: flex;
		align-items: center;
		justify-content: center;
		margin: 0;
		font-weight: 400;
		padding: 5px 10px;
		text-align: center;
		font-family: sans-serif;
		background-color: white;
	}

	.App {
		position: relative;
		height: 100vh;
		width: 100%;
		overflow: hidden;
		background-color: #6c8784;
	}

	.todos {
		width: 100%;
		display: grid;
		place-items: center;
	}
</style>
