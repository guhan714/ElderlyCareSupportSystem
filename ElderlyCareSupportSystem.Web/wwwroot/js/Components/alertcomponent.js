'use strict';

function successAlert(message) {
    Swal.fire({
        icon: "success",
        title: message,
        showConfirmButton: false,
        toast: true,
        clear:true,
        position: "top-end",
    });
}

function errorAlert(message) {
    Swal.fire({
        icon: "error",
        title: message,
        showConfirmButton: false,
        toast: true,
        showCloseButton:true,
        timer: 5000,
        timerProgressBar: true,
        color: '#FFFFFF',
        background: '#dd5555',
        position: "top-end",
    })
}