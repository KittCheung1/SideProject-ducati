const bikePrice = document.getElementById("bike-price");
const bikeName = document.getElementById("bike-name");
let list = document.getElementById("myList");

let arr = [{name:"monster", price: 22222, image:"/images/MY21-Monster-Plus-Red-Model-Blocks-630x390-01.jpg"}, {name:"streetfighter", price:33333, image:"images/MY21-Monster-Plus-Red-Model-Blocks-630x390-01.jpg"}, {name:"sportpro", price:44444, image:"images/MY21-Monster-Plus-Red-Model-Blocks-630x390-01.jpg"}]

arr.forEach((item) =>{
    let div = document.createElement("div");
    div.className="col-md-4 justify-content-around";
    let p1 = document.createElement("p");
    let p2 = document.createElement("p");
    let pImage = document.createElement("div")
    p1.innerText = item.name;
    p2.innerText = item.price;
    div.src = item.image;
    list.appendChild(div);
    div.appendChild(p1);
    div.appendChild(p2);
    div.appendChild(pImage);
    document.getElementById("myList").appendChild(div)
})

async function getBikesAsync() {
    const response = await fetch("https://localhost:7211/api/");
    return await response.json();
}

