'use strict';


$(document).ready(function () {
    $('#RoleTable').DataTable({
        layout: {
            topStart: null,
            topEnd: 'search',
            bottomStart: 'pageLength',
            bottomEnd: 'paging'
        }
    })
})

async function deleteRole(id,url) {
    const antiforgery = $('#RoleAction').find('input[name="__RequestVerificationToken"]').val();

    const roleDeleteResult = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': antiforgery
        },
        body: JSON.stringify(id),
    });

    const response = await roleDeleteResult.json();

    if (!response.success) {
        stopLoader();
        errorAlert(response.message);
        return false;
    }

    successAlert(response.message);

    setTimeout(function () {
        window.location.href = response.redirectUrl;
    }, 1000);
}