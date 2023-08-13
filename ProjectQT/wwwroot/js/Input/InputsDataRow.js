export function verificarTecla(valor, id, tecla) {
    var inputNombre = document.getElementById(id);
    if (tecla == "+" || tecla == "e" || tecla == "E" || tecla == "-") {
        inputNombre.value = valor;
    }
    
}

export function validarMin(valor, id, min) {
    var inputNombre = document.getElementById(id);

    if (valor < min) {
        inputNombre.value = min;
    }
}

export function validarMax(valor, id, max) {

    var inputNombre = document.getElementById(id);

    if (valor > max) {
        inputNombre.value = max;
    }

}

export function BackspaceVacio(id, min) {

    var inputNombre = document.getElementById(id);

    inputNombre.value = min > 0 ? min : 0;
    
}