'use strict';

function getRoleDetails() {
    const code = $('#Code').val().trim();
    const name = $('#Name').val().trim();
    const description = $('#Description').val().trim();
    const isActive = $('#IsActive').is(":checked");

    return {
        Code: code,
        Name: name,
        Description: description,
        IsActive: isActive,
    };
}

function validateRole(role) {

    let message = "";
    if (!role.Code) {
        message = "Code is required";
        return {success: false, message: message};
    } else if (!role.Name) {
        message = "Name is required";
        return {success: false, message: message};
    } else if (!role.Description) {
        message = "Description is required";    
        return {success: false, message: message};
    } else if (!role.IsActive) {
        message = "IsActive is required";
        return {success: false, message: message};
    } else
        return {success: true, message: message};
}

async function createRole(url, role) {

    try{
        const form = $('#RoleCreationForm');
        const antiforgeryToken = form.find('input[name="__RequestVerificationToken"]').val();

        const roleCreateResult = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': antiforgeryToken
            },
            body: JSON.stringify(role),
        });

        const response = await roleCreateResult.json();

        if (!response.success) {
            stopLoader();
            errorAlert(response.message);
            return false;
        }
        
        successAlert(response.message);

        setTimeout(function () {
            window.location.href = response.redirecturl;
        }, 1000);
    }
    catch(error) {
        stopLoader();
        errorAlert(error.message);
    }
}


function reset() {
    $('#Code').val("");
    $('#Name').val("");
    $('#Description').val("");
    $('#IsActive').prop("checked", true);
}