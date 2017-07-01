﻿$(document).ready(function () {
    $('input.HoraInicio').timepicker({
        timeFormat: 'h:i A',
        interval: 60,
        minTime: '10',
        maxTime: '6:00pm',
        defaultTime: '11',
        startTime: '10:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });
});

