<script>
    import { fade } from 'svelte/transition';
    export let todo;
    export let index;
    export let markAsComplete;
    export let deleteTodoFromList;
    
</script>

<div class="todo-item"  transition:fade|local="{{delay : 100 * index}}">
    <span class={todo.completed ? 'strike' : ''}>{todo.task}</span>
    <div class="todo-btns">
        {#if !todo.completed}
            <i on:click={() => markAsComplete(todo.id)} class="gg-check-r"></i>
        {/if}
        <i on:click={() => deleteTodoFromList(todo.id)} class="gg-close-r"></i>

    </div>
</div>

<style>
    .todo-item {
        width : 40%;
        background-color: #7BB0A6;
        margin: 20px 0;
        height: 4em;
        display: flex;
        align-items: center;
        justify-content: space-between;
        color: white;
        padding: 0 20px;
        border-radius: 10px;
    }

    .strike {
        text-decoration: line-through;
        color: red;
    }

    .todo-btns {
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .todo-btns > i {
        margin : 0 5px;
        cursor: pointer;
        transition: all 0.3s linear;
    }

    .todo-btns > i:first-child {
        color: green;
    }

    .todo-btns > i:hover {
        transform : scale(1.15);
    }

    .todo-btns > i:last-child {
        color: red;
    }

</style>