$(document).ready(() => {
    $('#example').DataTable();

    $("#guardar").click(() => {
        const data = collectData();

        guardar(data, () => {
            window.location.href = "/Clientes";
        });
    });

    $("#eliminar").click(() => {
        const data = collectData();

        Swal.fire({
            title: `Eliminar cliente?`,
            text: `Esta seguro que desea eliminar al cliente: ${data.nombre}`,
            icon: 'question',
            showCancelButton: true,
        }).then(result => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Clientes/Eliminar/${data.id}`,
                    success: response => {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: `El cliente: ${data.nombre} fue eliminado`,
                            showConfirmButton: false,
                            timer: 1500
                        }).then(response => (window.location.href = "/Clientes"))
                    },
                    error: error => {
                        console.log(error);
                    }
                });
            }
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

    $("#cancelar").click(() => {
        window.location.href = "/Clientes";
    });

    const existeNumero = async numero => {
        return $.get("/clientes/existenumero?numero=" + numero, response => (response.responseJSON));
    }

    async function validarForm() {
        const nombre = $("#nombre").val();
        const numero = $("#numero").val();


        if (!nombre) {
            Swal.fire(
                'Error [nombre]',
                `El campo nombre es obligatorio`,
                'error'
            );
            return false;
        }

        if (numero) {
            if (!$.isNumeric(numero)) {
                Swal.fire(
                    'Error [numero]',
                    'El numero debe contener unicamente numeros',
                    'error'
                );
                return false;
            }

            const numeroRepetido = await existeNumero($("#numero").val());


            if (numeroRepetido) {
                Swal.fire(
                    `Error [numero]`,
                    `El numero: ${numero} es repetido, ingrese otro por favor`,
                    'error'
                );
                return false;
            }
        }

        return true;
    }

    async function guardar(data, callback) {
        var esValido = await validarForm();

        if (esValido) {
            $.ajax({
                url: "/Clientes/Alta",
                data,
                success: response => {
                    Swal.fire(
                        `Exito`,
                        `El cliente: ${data.nombre} se creo correctamente`,
                        'success',
                    ).then(result => {
                        callback();
                    });
                },
                error: error => {
                    console.log(error);
                }
            });
        }
 
    }
});
