export const login = async({email, password}) => {
    try {
        const response = await fetch(import.meta.env.VITE_URL_LOGIN, {
            method: "POST",
            headers: {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify({email, password})
        })

        if(!response.ok)
            throw new Error();

        const data = await response.json();
        return data;
    } catch(error) {
        throw error;
    }
}

export const signUp = async({body}) => {
    try {
        const response = await fetch(import.meta.env.VITE_URL_CREATE_ACCOUNT, {
            method: "POST",
            headers: {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify(body)
        })

        if(!response.ok)
            throw new Error(response);

        return;
    } catch(err){
        throw err;
    }
}