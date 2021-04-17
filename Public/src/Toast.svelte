<script>
    import { fly } from 'svelte/transition';
    export let message;
</script>


<div class="toast" in:fly="{{ y: 200, duration: 500 }}" out:fly="{{ y: 200, duration: 500 }}">
    <div class="message">
        {message}
    </div>
</div>

<style>
    .toast {
        position: absolute;
        height: 60px;
        width : 100%;
        display: flex;
        align-items: flex-end;
        justify-content: center;
        bottom: 40px;
        z-index : 4;
        color: white;
        overflow: hidden;
    }

    .message {
        width: 300px;
        height: 50px;
        border-radius: 10px;
        background-color: #e67e22;
        display: grid;
        font-size: 20px;
        font-family: sans-serif;
        place-items : center;
    }
</style>