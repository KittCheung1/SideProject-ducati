const url = "https://localhost:7211/api/motorcycles";
const bikePrice = document.getElementById("bike-price");
const bikeName = document.getElementById("bike-name");
let list = document.getElementById("myList");

async function getBikesAsync() {
    const response = await fetch(url)
    const data = await response.json();
    data.forEach((item) =>{
        let div = document.createElement("div");
        div.className="col-md-6 justify-content-around ";
        
        div.innerHTML= `<a href = "/FE-ducati/html/${item.name}.html"> <img class="img-fluid" src="https://localhost:7211/${item.imagePath}"></img></a><p>${item.name}</p><p>Price: $${item.price}</p>`
        list.appendChild(div);
        document.getElementById("myList").appendChild(div)
    })
    console.log(data)

    return data;
}

getBikesAsync()


