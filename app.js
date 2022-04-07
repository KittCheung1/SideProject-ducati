const bikePrice = document.getElementById("bike-price");
const bikeName = document.getElementById("bike-name");
let list = document.getElementById("myList");

let arr = ["monster", "streetfighter", "sportpro"]

arr.forEach((item) =>{
    let div = document.createElement("div");
    div.innerText = item;
    list.appendChild(div);
})

async function getBikesAsync() {
    const response = await fetch("https://localhost:7211/api/");
    return await response.json();
}

