$(document).ready(() => {
    $('#example').DataTable();

    $("#guardar").click(() => {
        const data = collectData();

        guardar(data, () => {
            window.location.href = "/Clientes";
        });
    });


    $("#guardar_y_limpiar").click(() => {
        const data = collectData();
        guardar(data, limpiarForm);
    });

    const collectData = () => {
        const data = {};

        $(".clientes-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    }

    const limpiarForm = () => {
        $(".clientes-form :input").each(function () {
            $(this).val("");
        });
    }

    const existeNumero = async numero => {
        return $.get("/Clientes/ExisteNumero?numero=" + numero, response => (response));
    }

    const validarForm = () => {
        const nombre = $("#nombre").val();
        const numero = $("#numero").val();


        if (!nombre) {
            return false;
        }

        if (numero) {
            if (!$.isNumeric(numero)) {
                return false;
            }

            const numeroRepetido = existeNumero($("#numero").val());


            if (numeroRepetido) {
                return false;
            }
        }

        return true;
    }

    async function guardar(data, callback) {
        var esValido = validarForm();

        if (esValido) {
            $.ajax({
                url: "/Clientes/Alta",
                data,
                success: response => {
                    console.log(response);
                    callback();
                },
                error: error => {
                    console.log(error);
                }
            });
        }
 
    }
});
