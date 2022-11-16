// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#select-teatru").on("change", function () {
        var val = $(this).val();

        $.ajax({
            url: `Home/PieseDeTeatru?teatruId=${val}`,
        }).done(function (data) {

            var selectBox = document.querySelector("#select-piesa");
            while (selectBox.options.length > 0) {
                selectBox.remove(0);
            }

            for (var option in data) {
                selectBox.add(new Option(data[option].name, data[option].value));
            }

            $("#select-piesa").change();
        });
    });

    $("#select-piesa").on("change", function () {
        var val = $(this).val();

        $.ajax({
            url: `Home/OrarePiese?piesaId=${val}`,
        }).done(function (data) {

            var selectBox = document.querySelector("#select-orar");
            while (selectBox.options.length > 0) {
                selectBox.remove(0);
            }

            for (var option in data) {
                selectBox.add(new Option(data[option].name, data[option].value));
            }
        });

        $("#select-orar").change();
    });


    $("#select-orar").on("change", function () {
        var val = $(this).val();

        $.ajax({
            url: `Home/Pret?orarId=${val}`,
        }).done(function (data) {
            $("#PretIntegral").val(data);

            if ($("#student").prop('checked')) {
                data = 0.75 * data;
            }

            if ($("#pensionar").prop('checked')) {
                data = 0.5 * data;
            }

            $("#Pret").val(data);
        });
    });


    $("#pensionar").on("change", function () {
        var val = $("#PretIntegral").val();
        if ($("#pensionar").prop('checked')) {
            $("#Pret").val(val * 0.5);
            $("#student").prop('checked',false);
        } else {
            $("#Pret").val(val);
        }
    });

    $("#student").on("change", function () {
        var val = $("#PretIntegral").val();

        if ($("#student").prop('checked')) {
            $("#pensionar").prop('checked',false);
            $("#Pret").val(val * 0.75);
        } else {
            $("#Pret").val(val);
        }
    });


    $("#curatare").on("click", function () {
        window.location.reload();
    });
})
