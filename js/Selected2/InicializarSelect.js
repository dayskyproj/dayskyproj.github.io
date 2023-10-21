if (!window.select2Blazor) {
    window.select2Blazor = {};
}

var guardarId = "";

window.select2Blazor = (dotnetHelper, callbackMethodName, pickerElementName, desactivar, valor, modal = "") => {

    // initialize the specified picker element
    $(pickerElementName).select2.defaults.set('language', 'es'),
        $(pickerElementName).select2();
        $(pickerElementName).prop("disabled", desactivar),
        $(pickerElementName).val(valor).trigger('change'),




    // setup event to push the selected dropdown value back to c# code
    $(pickerElementName).on('select2:select', function (e, clickedIndex, isSelected, previousValue) {
        //var valorS = $(pickerElementName).val();
        //$(pickerElementName).val(valorS).trigger('change');
        dotnetHelper.invokeMethodAsync(callbackMethodName, $(pickerElementName).val());
    })

    if (modal == "") {
        $(pickerElementName).select2({
            width: '100%'
        });
    }
    else
    {
        $(pickerElementName).select2({
            width: '100%',
            dropdownParent: $('#' + modal + " .modal-body")
        });
    }

   
 
}


window.select2ActualizarOptions = (pickerElementName, desactivar, valor, modal = "") => {

    // Destroy the specified picker element
    $(pickerElementName).select2('destroy'),
    $(pickerElementName).select2.defaults.set('language', 'es'),
    $(pickerElementName).select2();
    $(pickerElementName).prop("disabled", desactivar),
    $(pickerElementName).val(valor).trigger('change');


    if (modal == "") {
        $(pickerElementName).select2({
            width: '100%'
        });
    }
    else {
        $(pickerElementName).select2({
            width: '100%',
            dropdownParent: $('#' + modal + " .modal-body")
        });
    }

}

window.select2ActualizarDefect = (pickerElementName, valor) => {

    // Destroy the specified picker element
    $(pickerElementName).val(valor).trigger('change')
}

window.select2Ocultar = (pickerElementName, ocultar, valor) => {

    $(pickerElementName).val(valor).trigger('change')

    if (ocultar == false) {
        $(pickerElementName).next(".select2").show();
    }
    else {
        $(pickerElementName).next(".select2").hide();
    }
}






