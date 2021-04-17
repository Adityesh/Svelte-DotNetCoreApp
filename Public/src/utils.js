async function getTodos() {
    try {
        const response = await fetch('/api/Todo');
        const result = await response.json();
        console.log(result);
        return Promise.resolve(result);
    } catch(err) {
        return Promise.reject(err);
    }
};


async function markTodoAsComplete(_id) {
    try {
        const response = await fetch('/api/Todo/complete?id=' + _id, {
            method : 'POST'
        });
        const result = await response.json();
        return Promise.resolve(result);
    } catch(err) {
        return Promise.reject(err);
    }
}

async function addTodo(task) {
    try {
        const response = await fetch('/api/Todo/add?task=' + task, {
            method : 'POST'
        });
        const result = await response.json();
        return Promise.resolve(result);
    } catch(err) {
        return Promise.reject(err);
    }
}


async function deleteTodo(id) {
    try {
        const response = await fetch('/api/Todo?id=' + id, {
            method : 'DELETE'
        });
        const result = await response.json();
        console.log(result);
        return Promise.resolve(result);
    } catch(err) {
        return Promise.reject(err);
    }
}
export {
    getTodos,
    markTodoAsComplete,
    addTodo,
    deleteTodo
};