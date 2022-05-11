const username = document.getElementById("username").value
const password = document.getElementById("password").value

document.addEventListener("DOMContentLoaded", ()=>{
    const loginForm = document.querySelector("#login");
    const createAccountForm = document.querySelector("#createAccount");
    
    document.querySelector("#linkCreateAccount").addEventListener("click", () => {
        loginForm.classList.add("form--hidden");
        createAccountForm.classList.remove("form--hidden");
    });
    document.querySelector("#linkLogin").addEventListener("click", () => {
        loginForm.classList.remove("form--hidden");
        createAccountForm.classList.add("form--hidden");
    });

});