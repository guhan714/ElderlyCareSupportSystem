'use strict';

function getRoleDetails() {
    const id = $('#Id').val();
    const code = $('#Code').val().trim();
    const name = $('#Name').val().trim();
    const description = $('#Description').val().trim();
    const isActive = $('#IsActive').is(":checked");

    return {
        Id: id,
        Code: code,
        Name: name,
        Description: description,
        IsActive: isActive,
    };
}

function validateRole(role, existingRole) {
    
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
    } else if (role.Name === existingRole.name && role.Description === existingRole.description && role.IsActive === existingRole.isActive) {
        message = "No changes made. Please validate your data before updating.";
        return {success: false, message: message};
    }  else
        return {success: true, message: message};
}

async function updateRole(url, role) {

    try {
        const form = $('#RoleUpdateForm');
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
    } catch (error) {
        stopLoader();
        errorAlert(error.message);
    }
}
