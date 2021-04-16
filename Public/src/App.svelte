<script>
import { onMount } from "svelte";


	let todos = [];

	async function getTodos() {
		try {
			const response = await fetch('/api/todo');
			const result = await response.json();
			todos = result;
		} catch(err) {
			alert("Error fetching all the todos from the database")
		}
	}

	onMount(() => {
		getTodos();
	})
</script>

<ul>
	{#each todos as {id, task, completed}}
		<li>{task}</li>
		
	{/each}
</ul>

