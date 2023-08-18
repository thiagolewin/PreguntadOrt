// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let tiempo = undefined;
function modificarBarra() {
    const barra = document.querySelector(".barraProgreso")
    if (barra) {
        const barrachild = barra.children[0]
        const widthBarra = barra.clientWidth;
        barrachild.style.width = widthBarra * parseInt(barra.children[2].textContent)/parseInt(barra.children[1].textContent) + "px"
    }
}
function actualizarTimer() {
    console.log("asd")
    const timer = document.querySelector(".tiempo")
    if (timer) {
        if (tiempo == undefined) {
            tiempo = timer.textContent
        }
        console.log(tiempo)
        const fechaJs = TraerJs(tiempo)
        const fechaActual = new Date()
        const diferenciaEnMilisegundos = fechaActual -fechaJs
        let segundos = Math.floor(diferenciaEnMilisegundos / 1000)
        let minutos = Math.floor(segundos / 60)
        segundos%= 60
        let horas = Math.floor(minutos/ 60)
        minutos %= 60
        var tiempoFormateado =
    (horas < 10 ? "0" : "") + horas + ":" +
    (minutos < 10 ? "0" : "") + minutos + ":" +
    (segundos < 10 ? "0" : "") + segundos;

    }
}
function TraerJs(tiempo) {
        const tiempoJs = tiempo.textContent.split(" ");
        console.log(tiempoJs[1])
      
        const horaPartes = tiempoJs[1].split(":");
        const fechaPartes = tiempoJs[0].split("/")
        const fechaJs = `${fechaPartes[1]}/${fechaPartes[0]}/${fechaPartes[2]} ${horaPartes[0]}:${horaPartes[1]}:${horaPartes[2]}`
        return new Date(fechaJs);

}
modificarBarra()
actualizarTimer()
setInterval(()=> {
    actualizarTimer()
},1000)