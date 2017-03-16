/// <reference path="onlineshoppingcart.js" />

$(document).ready(function () {
    $('#checkOutSubmit').click(function (e) {
        //debugger;
        if ($('#emptyCart').val() === 'Empty') {
            $('#emptyCartValidationMessage').show('fade');
            e.stopImmediatePropagation()
            e.preventDefault();
        }
    });
});
