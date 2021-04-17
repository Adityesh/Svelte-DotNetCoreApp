<script>
    let input = "";
    export let detectEnterKey;
    export let addTodoToList;
</script>

<div class="input-todo">
    <input
        type="text"
        bind:value={input}
        placeholder="Enter a task"
        on:keydown={(e) => {
            detectEnterKey(e, input);
        }}
    />
    <div
        on:click={() => {
            addTodoToList(input);
        }}
    >
        <i class="gg-corner-down-left" />
    </div>
</div>

<style>
    .input-todo {
        width: 100%;
        height: 80px;
        display: grid;
        place-items: center;
        margin-top: 20px;
        position: relative;
    }

    input {
        width: 40%;
        height: 3em;
        font-size: 18px;
        font-family: sans-serif;
        border: none;
        background: none;
        border-bottom: 1px solid white;
        transition: all 0.3s linear;
        padding: 0 5px;
        color: white;
        font-weight: 200;
    }

    .input-todo > div {
        position: absolute;
        top: 30%;
        left: 67%;
        display: flex;
        align-items: center;
        justify-content: flex-end;
        color: white;
        cursor: pointer;
    }

    input:focus {
        outline: none;
    }
</style>
