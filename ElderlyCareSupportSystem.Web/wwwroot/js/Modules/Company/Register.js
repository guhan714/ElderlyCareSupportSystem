'use strict';

$(document).ready(function () {
    const settings = {sortField: {field: "text"}};
    new TomSelect('#CountryId', settings);
})


function getRegistrationData() {
    const name = $('#Name').val();
    const address1 = $('#AddressLine1').val();
    const address2 = $('#AddressLine2').val();
    const address3 = $('#AddressLine3').val();
    const city = $('#City').val();
    const state = $('#State').val();
    const zip = $('#ZipCode').val();
    const country = $('#CountryId').val();
    const phoneNumber = $('#PhoneNumber').val();
    const email = $('#Email').val();
    const website = $('#Website').val();
    const userName = $('#UserName').val();
    const password = $('#Password').val();
    const registrationNumber = $('#RegistrationNumber').val();

    return {
        Name: name,
        AddressLine1: address1,
        AddressLine2: address2,
        AddressLine3: address3,
        City: city,
        State: state,
        ZipCode: zip,
        CountryId: country,
        PhoneNumber: phoneNumber,
        Email: email,
        Website: website,
        UserName: userName,
        Password: password,
        RegistrationNumber: registrationNumber,
    };
}

function validateRegistration(company) {

    const emailPattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;

    if (!company.Name)
        return {valid: false, message: "Name is required"};
    if (!company.AddressLine1)
        return {valid: false, message: "Address1 is required"};
    if (!company.AddressLine2)
        return {valid: false, message: "AddressLine2 is required"};
    if (!company.City)
        return {valid: false, message: "City is required"};
    if (!company.State)
        return {valid: false, message: "State is required"};
    if (!company.ZipCode)
        return {valid: false, message: "ZipCode is required"};
    if (!company.CountryId)
        return {valid: false, message: "Country is required"};
    if (!company.PhoneNumber)
        return {valid: false, message: "PhoneNumber is required"};
    if (!company.Email)
        return {valid: false, message: "Email is required"};
    if (!emailPattern.test(company.Email))
        return {valid: false, message: "Invalid Email address"};
    if (!company.Website)
        return {valid: false, message: "Website is required"};
    if (!company.UserName)
        return {valid: false, message: "UserName is required"};
    if (!company.Password)
        return {valid: false, message: "Password is required"};
    if (!company.RegistrationNumber)
        return {valid: false, message: "RegistrationNumber is required"};

    return {valid: true, message: ""};
}

async function register(url, companyData) {
    const registrationForm = $('#CompanyRegistration');
    const antiForgeryToken = registrationForm.find('input[name="__RequestVerificationToken"]').val();

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "RequestVerificationToken": antiForgeryToken
            },
            body: JSON.stringify(companyData),
        });

        const data = await response.json();

        stopLoader();

        if (!data.success) {
            errorAlert(data.message);
            return;
        }
        
        successAlert(data.message);
        window.location.href = data.redirectionUrl;

    } catch (error) {
        errorAlert(error.message);
    }
}