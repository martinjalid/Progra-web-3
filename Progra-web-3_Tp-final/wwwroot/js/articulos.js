﻿$(document).ready(function () {

    // DataTable
    var table = $('#tabla_articulos').DataTable({
        "searching": false,
        "info": false,
        "order": [[1, "asc"]],
        initComplete: function () {
            // Apply the search
            this.api().columns().every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change clear', function () {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                });
            });
        }
    });

});

function filtro_articulo() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_descripcion");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_articulos");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
};


function filtro_codigo() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_codigo");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_articulos");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
};


$(document).ready(() => {
    $("#guardar").click(() => {
        const data = collectData();

        guardar(data, () => {
            window.location.href = "/Articulos";
        });
    });

    $("#guardar_y_limpiar").click(() => {
        const data = collectData();
        guardar(data, limpiarForm);
    });

    const limpiarForm = () => {
        $(".articulos-form :input").each(function () {
            $(this).val("");
        });
    }

    const collectData = () => {
        const data = {};

        $(".articulos-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };

    async function guardar(data, callback) {
        var descripcion = $("#Descripcion").val();
        Swal.fire(
            `Articulo ${descripcion} creado con éxito`,
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                url: "/Articulos/NuevoArticulo",
                data,
                success: response => {
                    console.log(response);
                    callback();
                },
                error: error => {
                    console.log(error);
                }
            })
        })
    };

    $("#cancelar").click(() => {
        window.location.href = "/Articulos";
    });

    $("#editar").click(() => {
        const data = collectData2();

        editar(data, () => {
            window.location.href = "/Articulos";
        });
    });

    const collectData2 = () => {
        const data = {};

        $(".articulos-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };



    async function editar(data, callback) {
        var descripcion = $("#Descripcion").val();
        Swal.fire(
            `Articulo ${descripcion} modificado con exito`,
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                type: "POST",
                url: "/Articulos/EditarArticulo",
                data,
                success: response => {
                    console.log(response);
                    callback();
                },
                error: error => {
                    console.log(error);
                }
            })
        })
    };


});


$(".eliminar_articulo").click(event => {
    console.log(this)
})

function eliminar() {

    valor = $('#boton_eliminar').val();
    Swal.fire({
        title: 'Esta seguro que desea eliminar el articulo: ' + valor,
        text: "Esta acción no se podrá revertir",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminar'
    }).then((result) => {
        $.ajax({
            url: "/Articulos/Eliminar/1",
            success: response => {
                Swal.fire(
                    'Eliminado!',
                    'El articulo ha sido borrado',
                    'success'
                ).then((result) => {

                    window.location = "/Articulos"
                })
            }
            ,
            error: error => {
                console.log(error);
            }
        });
    })
};
