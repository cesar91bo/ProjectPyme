
var app = app || {}

app.util = function () {



    //var select2Persona = function (personaId) {
    //    $('#persona-select2').empty();

    //    var dataPersonas = cargarListadoPersonas();

    //    $('#persona-select2').select2({

    //        tags: "true",
    //        allowClear: true,
    //        placeholder: 'Seleccione una Persona',
    //        data: dataPersonas.responseJSON,
    //        width: '100%'
    //    });

    //    if (personaId == 0) {
    //        $('#persona-select2').val(null).trigger('change');

    //    } else {
    //        $('#persona-select2').val(personaId).trigger('change');

    //    }

    //    function cargarListadoPersonas() {

    //        var listadoPersonas =
    //            $.ajax({
    //                type: "GET",
    //                datatype: "json",
    //                url: 'api/Personas/Listado',
    //                async: false,
    //                done: function (responseJSON) {
    //                    return responseJSON;
    //                }
    //            });
    //        ;
    //        return listadoPersonas;
    //    };
    //};

    return {
        /*select2Persona: select2Persona*/
    }

}();


function changeCollapse(e) {

    var claseFiltro = $('#filtro').attr("class");

    if (claseFiltro == "filtro collapse show") {
        $('#arrowFiltro').removeAttr('class', '');
        $('#arrowFiltro').attr('class', 'fas fa-angle-double-down');
    } else {
        $('#arrowFiltro').removeAttr('class', '');
        $('#arrowFiltro').attr('class', 'fas fa-angle-double-up');
    }

}
