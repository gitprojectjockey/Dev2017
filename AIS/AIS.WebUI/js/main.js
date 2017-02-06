function responsiveMobileMenu() {

    $('.nav').each(function () {
        var $style = $(this).attr('nav-menu-style'); // get menu style
        if (typeof $style == 'undefined' || $style == false) {
            $(this).addClass('yoga'); // set yoga style if style is not defined
        } else {
            $(this).addClass($style);
        }

        var $width = 0;
        $(this).find('ul li').each(function () {
            $width += $(this).outerWidth();
        });
       
        if ($.support.leadingWhitespace) {
            //$(this).css('max-width', $width * 1.2 + 'px');
        }
        else {
            $(this).css('width', $width * 1.2 + 'px');
        }
    });
}

function getMobileMenu() {

    /* 	build toggled dropdown menu list */

    $('.nav').each(function () {
        var menutitle = $(this).attr("nav-menu-title");
        if (menutitle == "") {
            menutitle = "";
        } else if (menutitle == undefined) {
            menutitle = "";
        }

        var $menulist = $(this).children('.nav-menu').html();
        $menulist = $menulist.replace('mobileContactUs', 'contactUs');;

        var $menucontrols = "<div class='nav-toggled-controls'><div class='nav-toggled-title'>" + menutitle + "</div><div class='nav-button'><span>&nbsp;</span><span>&nbsp;</span><span>&nbsp;</span></div></div>";
        $(this).prepend("<div class='nav-toggled nav-closed'>" + $menucontrols + "<ul>" + $menulist + "</ul></div>");
    });
}

function adaptMenu() {

    /* 	toggle menu on resize */

    $('.nav').each(function () {
        //Hide open menu when window size changes
        $('.nav-toggled, .nav-toggled .nav-button').find(' > ul').stop().hide();
        $('.nav-toggled, .nav-toggled .nav-button').removeClass("nav-closed");
        $('.nav-toggled, .nav-toggled .nav-button').addClass("nav-closed");
        $(this).children('.nav-menu').hide(0);

        var $width = 822;
        if (navigator.userAgent.search("Chrome") >= 0) {
            $width = 805;
        }
        
        if ($(this).parent().width() <= $width) {
            $(this).children('.nav-menu').hide(0);
            $(this).children('.nav-toggled').show(0);
        } else {
            $(this).children('.nav-menu').show(0);
            $(this).children('.nav-toggled').hide(0);
        }
    });
}

$(function () {

    responsiveMobileMenu();
    getMobileMenu();
    adaptMenu();

    /* slide down mobile menu on click */
    $('.nav-toggled, .nav-toggled .nav-button').click(function () {
        if ($(this).is(".nav-closed")) {
            $(this).find('> ul').stop().show(200);
            $(this).removeClass("nav-closed");
        } else {
            $(this).find(' > ul').stop().hide(200);
            $(this).addClass("nav-closed");
        }
    });
});
/* 	hide mobile menu on resize */
$(window).resize(function () {
    adaptMenu();
});

$(document).ready(function () {

    //test for touch events support and if not supported, attach .no-touch class to the HTML tag.
    if (!("ontouchstart" in document.documentElement)) {
        document.documentElement.className += " no-touch";
    } else {
        document.documentElement.className += " touch";
    }

    var $submenus = $('.nav.yoga .nav-menu li > ul');
    $submenus.hide();
    if ($('html').hasClass('no-touch')) {
        $submenus.parent().hover(function () {
            $(this).find('> ul').slideToggle('fast');
        });
    } else {
        $submenus.parent().click(function (e) {
            $(this).find('> ul').slideToggle('fast');
            e.preventDefault();
            e.stopPropagation();
        });
    }

    $submenus.parent().addClass('has-children');

    var $submenusSm = $('.nav.yoga .nav-toggled li > ul');
    $submenusSm.hide();
    $submenusSm.parent().prepend('<div class="clicker"></div>');
    $submenusSm.parent().children('a').addClass('toggle-sm');
    var clicker = $('.clicker');
    clicker.on('click', function (e) {
        e.stopPropagation();
        $(this).parent().find('> ul').slideToggle();
        $(this).parent().children('a').toggleClass('open');
    });

    //registar click events for showing the contact dialog
    $('#mobileContactUs').click(function () {
        $('#contactModal').modal('show');
    });

    $('#contactUs').click(function () {
        $('#contactModal').modal('show');
    });
});