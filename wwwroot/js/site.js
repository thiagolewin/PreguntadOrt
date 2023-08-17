// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function modificarBarra() {
    const barra = document.querySelector(".barraProgreso")
    const barrachild = barra.children[0]
    const widthBarra = barra.clientWidth;
    barrachild.style.width = widthBarra * parseInt(barra.children[2].textContent)/parseInt(barra.children[1].textContent) + "px"
    console.log("a")
}
modificarBarra()