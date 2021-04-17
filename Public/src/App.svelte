<script>
	import { onMount } from "svelte";
	import Todo from "./Todo.svelte";
	import Loader from "./Loader.svelte";
	import Input from "./Input.svelte";
	let isLoading = false;
	let todos = [
		{
			_id: "adsfsdfsdfsdf",
			task: "Clean room",
			completed: true,
		},
		{
			_id: "adsfsdfsdfsdf",
			task: "Clean room 2",
			completed: false,
		},
		{
			_id: "adsfsdfsdfsdf",
			task: "Clean room 3",
			completed: false,
		},
	];

	function markAsComplete(task) {
		todos.forEach((todo) => {
			if (todo.task === task) {
				todo.completed = true;
			}
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
		todos.unshift({task : input, _id : 'sfsdfsdfsdfsdfsdf', completed : false});
		todos = todos;
	}

	onMount(() => {
		// getTodos();
	});
</script>

<div class="App">
	<h1 class="header">To-do List with Svelte</h1>
	<Input {detectEnterKey} {addTodoToList} />
	<ul class="todos">
		{#each todos as todo}
			<Todo {todo} {markAsComplete} />
		{/each}
	</ul>

	{#if isLoading}
		<Loader />
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
		background-color: #6c8784;
	}

	.todos {
		width: 100%;
		display: grid;
		place-items: center;
	}
</style>
