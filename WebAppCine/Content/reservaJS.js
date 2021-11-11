function validaCliente() {
    var url = "/Funcion/buscarCliente";
    var dni = $('#txtDni').val().trim();
    console.log(dni);
    $.post(
        url,
        { dni },
        (response) => {
            if (response !== null && response !== '') {
                $('#id-cliente').val(response.cliente_id);
                $('#txtCliente').val(response.nombre + ' ' + response.apellido_paterno + ' ' + response.apellido_materno);
            } else {
                $('#txtCliente').val('NO EXISTE');
            }

        });
}

function calcularImporte() {
    var cantidad = $('#id-cantidad').val().trim();
    var importe;
    console.log(cantidad);
    if (!isNaN(cantidad)) {
        importe = cantidad * 15;
        $('#id-monto').val(importe.toFixed(2));
    } else {
        $('#id-monto').val('no calculado');
    }
        
}

function SoloNumeros(evt) {
    let keynum;
    if (window.event)//asignamos el valor de la tecla a keynum
        keynum = evt.keyCode; //IE
    else
        keynum = evt.which; //FF

    //comprobamos si se encuentra en el rango numérico y que teclas no recibirá.
    if ((keynum > 47 && keynum < 58) || keynum === 8 || keynum === 13 || keynum === 6)
        return true;
    else
        return false;

}

