const url = "https://localhost:7211/api/motorcycles";
const bikePrice = document.getElementById("bike-price");
const bikeName = document.getElementById("bike-name");
let list = document.getElementById("myList");

// let arr = [{name:"monster", price: 22222, image:"/images/MY21-Monster-Plus-Red-Model-Blocks-630x390-01.jpg"}, {name:"streetfighter", price:33333, image:"images/MY-22-SF-V2-Model-Blocks-Streetfighter-630x390.png"}, {name:"sportpro", price:44444, image:"images/MY21-SuperSport-950S-White-Model-Blocks-630x390-01.jpg"}]



// arr.forEach((item) =>{
//     let div = document.createElement("div");
//     div.className="col-md-6 justify-content-around ";
//     div.innerHTML= `<img class="img-fluid" src="${item.image}"></img><p>${item.name}</p><p>${item.price}</p>`
//     list.appendChild(div);
//     document.getElementById("myList").appendChild(div)
// })

async function getBikesAsync() {
    const response = await fetch(url)
    const data = await response.json();
    data.forEach((item) =>{
        let div = document.createElement("div");
        div.className="col-md-6 justify-content-around ";
        
        div.innerHTML= `<img class="img-fluid" src="https://localhost:7211/${item.imagePath}"></img><p>${item.name}</p><p>Price: $${item.price}</p>`
        list.appendChild(div);
        document.getElementById("myList").appendChild(div)
    })
    console.log(data)

    return data;
}

getBikesAsync()