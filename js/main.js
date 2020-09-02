/*
    Template Name: Panshi - Catering Service HTML Template
    Template URI: https://devitems.com/html/coffee-preview/
    Description: This is html5 template
    Author: HasTech
    Author URI: https://devitems.com/
    Version: 1.0
*/
/*================================================
 [ Table of contents  ]
================================================
	01. Sticky Menu
	02. Owl Carousel
	03. jQuery MeanMenu
	04. ScrollUp
	05. Wow js
	06. Magnific Popup
    07. One Page Nav
 
======================================
[ End table content ]
======================================*/

(function ($) {
	"use strict";
    
/*------------------------------------
    01. Sticky Menu
-------------------------------------- */
	window.onscroll = function () { myFunction() };

	var header = document.getElementByClassName("header-area");
	var sticky = header.offsetTop;
    
	function myFunction() {
	    if (window.pageYOffset > sticky) {
	        header.addClass("sticky");
	    } else {
	        header.removeClass("sticky");
	    }
	}

	//var windows = $(window);
	//var stick = $(".header-sticky");
	//windows.on('scroll', function () {
	//    var scroll = windows.scrollTop();
	//    if (scroll < 245) {
	//        stick.removeClass("sticky");
	//    } else {
	//        stick.addClass("sticky");
	//    }
	//});

    //var windows = $(window);
    //var stick = $("#header-split");
	//windows.on('scroll',function() {    
	//	var scroll = windows.scrollTop();
	//	if (scroll < 245) {
	//	    stick.removeClass("header-split-sticky");
	//	}else{
	//	    stick.addClass("header-split-sticky");
	//	}
	//});
/*------------------------------------
    01. Prati change Sticky Menu
-------------------------------------- */

//window.onscroll = function() {home()};

//var header = document.getElementById("header-split");
//var sticky = header.offsetTop;

//function home() {
//	    if (window.pageYOffset > sticky) {
//	        header.addClass("header-split-sticky");
//	    } else {
//	        header.removeClass("header-split-sticky");
//	    }
//	}


/*----------------------------------------
    02. Owl Carousel
---------------------------------------- */
/*----------------------------------------
    Slider Carousel
---------------------------------------- */
    $(".slider-wrapper").owlCarousel({
        loop:true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 2500,
        items:1,
        nav:true,
        navText: ["<i class='zmdi zmdi-chevron-left'></i>","<i class='zmdi zmdi-chevron-right'></i>"],
        dots:true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });
    
/*-------------------------------------
    Event Carousel
-------------------------------------- */
    $(".event-owl").owlCarousel({
        loop:true,
        items:1,
        dots: true,
		nav:false,
        responsive:{
            0:{
                items:1
            },
            480:{
                items:1
            },
            768:{
                items:2
            }, 
            992:{
                items:3
            }, 
            1200:{
                items:3
            }
		}
    }); 
    
/*-------------------------------------
    Menu Carousel
-------------------------------------- */
    $(".menu-owl").owlCarousel({
        loop:true,
        items:1,
        dots: true,
		nav:false,
        responsive:{
            0:{
                items:1
            },
            480:{
                items:1
            },
            768:{
                items:2
            }, 
            992:{
                items:3
            }, 
            1200:{
                items:3
            }
		}
    });    
    
/*-------------------------------------
    Testimonial Carousel
-------------------------------------- */
    $(".testimonial-owl").owlCarousel({
        loop:true,
        items:1,
        dots: true,
		nav:false,
        responsive:{
            0:{
                items:1
            },
            480:{
                items:1
            },
            768:{
                items:1
            }, 
            992:{
                items:1
            }, 
            1200:{
                items:1
            }
		}
    });

/*-------------------------------------------
    03. jQuery MeanMenu
--------------------------------------------- */
	$('.main-menu nav').meanmenu({
		meanScreenWidth: "767",
		meanMenuContainer: '.mobile-menu'
	});

/*------------------------------------------
    04. ScrollUp
------------------------------------------- */	
	$.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });  
    
/*-------------------------------------------
    05. Wow js
--------------------------------------------- */    
    new WOW().init();
            
/*--------------------------
    06. Magnific Popup
---------------------------- */	
    $('.video-popup').magnificPopup({
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        zoom: {
            enabled: true,
        }
    });
    
     $('.image-popup').magnificPopup({
        type: 'image',
        gallery:{
            enabled:true
        }
    });
        
/*--------------------------------
	07. One Page Nav
-----------------------------------*/
    var top_offset = $('.main-menu').height() - -17;
    $('.main-menu nav ul').onePageNav({
        currentClass: 'active',
        scrollOffset: top_offset
    });
	
})(jQuery);

$(function () {
    var $tabButtonItem = $('#category-tab-button li'),
        $tabSelect = $('#category-tab-select'),
        $tabContents = $('.category-tab-contents'),
        activeClass = 'is-active';

    $tabButtonItem.first().addClass(activeClass);
    $tabContents.not(':first').hide();

    $tabButtonItem.find('a').on('click', function (e) {
        var target = $(this).attr('href');

        $tabButtonItem.removeClass(activeClass);
        $(this).parent().addClass(activeClass);
        $tabSelect.val(target);
        $tabContents.hide();
        $(target).show();
        e.preventDefault();
    });

    $tabSelect.on('change', function () {
        var target = $(this).val(),
            targetSelectNum = $(this).prop('selectedIndex');
        $tabButtonItem.removeClass(activeClass);
        $tabButtonItem.eq(targetSelectNum).addClass(activeClass);
        $tabContents.hide();
        $(target).show();
    });
});

//$(function () {
//    var $tabButtonItem = $('#nav-tabs-button li'),
//        $tabSelect = $('#nav-tabs-select'),
//        $tabContents = $('.tab-pane fade'),
//        activeClass = 'is-active';

//    $tabButtonItem.first().addClass(activeClass);
//    $tabContents.not(':first').hide();

//    $tabButtonItem.find('a').on('click', function (e) {
//        var target = $(this).attr('href');

//        $tabButtonItem.removeClass(activeClass);
//        $(this).parent().addClass(activeClass);
//        $tabSelect.val(target);
//        $tabContents.hide();
//        $(target).show();
//        e.preventDefault();
//    });

//    $tabSelect.on('change', function () {
//        var target = $(this).val(),
//            targetSelectNum = $(this).prop('selectedIndex');

//        $tabButtonItem.removeClass(activeClass);
//        $tabButtonItem.eq(targetSelectNum).addClass(activeClass);
//        $tabContents.hide();
//        $(target).show();
//    });
//});