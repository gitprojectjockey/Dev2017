$(document).ready(function () {
    $('#submitAccount').click(function (e) {
        var accountNumber = $("#AccountNumber").val();
        $.ajax({
            url: '/Home/Index/id',
            type: "POST",
            dataType: "json",
            data: { id: accountNumber },
            cache: false,
            success: function (result) {
            }
        });
    });

    $body = $("body");
    $(document).on({
        ajaxStart: function () { $body.addClass("loading"); },
        ajaxStop: function () { $body.removeClass("loading"); }
    });
});
