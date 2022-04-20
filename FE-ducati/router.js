const route = (event) =>{
    event = event || window.event;
    event.preventDefault();
    window.history.pushState({},"", event.target.href);
}

const routes = {
    404 : "/templates/404.html",
    "/" : "/templates/index.html",
    "new-bikes" : "/templates/new-bikes.html",
    "/desertX" : "/templates/desertx.html",

}

const handleLocation = async () =>{
    const path = window.location.pathname;
}