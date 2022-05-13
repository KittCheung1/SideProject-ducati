const url = "https://localhost:7211/api/users";
const username = document.getElementById("username").value
const password = document.getElementById("password").value

// making one of the forms hidden when clicking on a link
document.addEventListener("DOMContentLoaded", ()=>{
    const loginForm = document.querySelector("#login");
    const createAccountForm = document.querySelector("#createAccount");
    
    document.querySelector("#linkCreateAccount").addEventListener("click", e => {
        e.preventDefault();
        loginForm.classList.add("form--hidden");
        createAccountForm.classList.remove("form--hidden");
    });
    document.querySelector("#linkLogin").addEventListener("click", e => {
        e.preventDefault();
        loginForm.classList.remove("form--hidden");
        createAccountForm.classList.add("form--hidden");
    });

    // at loginForm submission grab the event object 
    loginForm.addEventListener("submit", e =>{
        e.preventDefault();
        const login = "https://localhost:7211/api/users";

        fetch(login, {
              method: "POST",
              headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
              },
              body: JSON.stringify({
                username: form.username.value,
                password: form.password.value,
              }),
            })
              .then((response) => response.json())
              .then((data) => console.log(data))
              .catch((err) => {
                console.log(err);
            });
            
            // when failure at fetching while doing a login send this message
            setFormMessage(loginForm, "error", "Wrong username or password")
    });
});

// formElement = loginForm or createAccountForm
// type = success or error type of message
// message = the actual message
function setFormMessage(formElement, type, message) {
    const messageElement = formElement.querySelector(".form__message");

    messageElement.textContent = message;
    messageElement.classList.remove("form_message-success", "form_message-error");
    messageElement.classList.add(`form_message-${type}`);
}

setFormMessage(loginForm, "success", "You Logged in!");
