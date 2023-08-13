function CustomConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            allowOutsideClick: false
        }).then((result) => {
            if (result.isConfirmed) {
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}

function AbrirLoading(titulo) {
    let timerInterval
    Swal.fire({
        title: titulo,
        timerProgressBar: true,
        allowOutsideClick: false,
        didOpen: () => {
            Swal.showLoading()
        }
    }).then((result) => {
        /* Read more about handling dismissals below */
        if (result.dismiss === Swal.DismissReason.timer) {
            console.log('I was closed by the timer')
        }
    })
}

function AbrirLoading(titulo, tiempo) {
    let timerInterval
    Swal.fire({
        title: titulo,
        timer: tiempo * 1000,
        timerProgressBar: true,
        allowOutsideClick: false,
        didOpen: () => {
            Swal.showLoading()
        },
        willClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        /* Read more about handling dismissals below */
        if (result.dismiss === Swal.DismissReason.timer) {
            console.log('I was closed by the timer')
        }
    })

}

function Cerrar() {
    Swal.close();
}

function PersonalizarHTMLMensaje(titulo, infoHtml, tipo) {

    Swal.fire({
        title: titulo,
        icon: tipo,
        allowOutsideClick: false,
        html: '<div style="text-align:left">' + infoHtml + '</div>'
    })
}

function PersonalizarHTML(titulo, infoHtml) {

    Swal.fire({
        title: titulo,
        allowOutsideClick: false,
        html: '<div style="text-align:left">' + infoHtml + '</div>',
        width: '75%'
    })
}