$(document).ready(function () {
    $('input.HoraInicio').datepicker({
        dateformat: "dd/md/yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-60:+0"

    });
});