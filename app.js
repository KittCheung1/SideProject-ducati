async function getBikesAsync() {
    const response = await fetch("https://localhost:7211/api/");
    return await response.json();
  }