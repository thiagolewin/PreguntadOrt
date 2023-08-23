// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let tiempo = undefined;
const maxTiempo = 15;
function modificarBarra() {
    const barra = document.querySelector(".barraProgreso")
    if (barra) {
        const barrachild = barra.children[0]
        const widthBarra = barra.clientWidth;
        barrachild.style.width = widthBarra * parseInt(barra.children[2].textContent)/parseInt(barra.children[1].textContent) + "px"
    }
}
function actualizarTimer() {
    const timer = document.querySelector(".tiempo")
    const barraTiempo = document.querySelector(".barraTiempo")
    if (timer) {
        if (tiempo == undefined) {
            tiempo = timer.textContent
        }
        const fechaJs = TraerJs(tiempo)
        const fechaActual = new Date()
        const diferenciaEnMilisegundos = fechaActual -fechaJs
        let segundos = diferenciaEnMilisegundos / 1000
        if (segundos >= maxTiempo) {
            window.location = "/Home/SinTiempo";
        } else {
            barraTiempo.children[0].style.width = barraTiempo.clientWidth - barraTiempo.clientWidth/maxTiempo * segundos + "px"
            barraTiempo.children[0].children[0].textContent = Math.floor(maxTiempo - segundos) 
        }

    }
}
function TraerJs(tiempo) {
        const tiempoJs = tiempo.split(" ");
      
        const horaPartes = tiempoJs[1].split(":");
        const fechaPartes = tiempoJs[0].split("/")
        const fechaJs = `${fechaPartes[1]}/${fechaPartes[0]}/${fechaPartes[2]} ${horaPartes[0]}:${horaPartes[1]}:${horaPartes[2]}`
        return new Date(fechaJs);

}
modificarBarra()
actualizarTimer()
setInterval(()=> {
    actualizarTimer()
},10)