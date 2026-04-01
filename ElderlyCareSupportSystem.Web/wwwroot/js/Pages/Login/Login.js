'use strict';

function getLoginData()
{
    const userName = $('#UserName').val();
    const password = $('#Password').val();
    
    return {
        UserName: userName,
        Password: password
    }
}

function validateLoginData(loginData) {
    if(!loginData.UserName) {
        errorAlert("Please enter UserName");
        return false;
    }
    if(!loginData.Password) {
        errorAlert("Please enter Password");
        return false;
    }
    return true;
}

async function login(url, loginData) {
    const form = $('#LoginForm');
    const antiforgery = form.find('input[name="__RequestVerificationToken"]').val();
    const loginResult = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': antiforgery 
        },
        body: JSON.stringify(loginData),
    });
    
    const response = await loginResult.json();
    
    if(!response.success){
        stopLoader();
        errorAlert(response.message);
        return false;
    }
    
    window.location.href = response.url;
}