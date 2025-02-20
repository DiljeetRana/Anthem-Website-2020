// JavaScript Document
/* all function in this Js file
   	bxslider
	header
 */

$(document).ready(function () {
	//parallax
	$('#parallax-2').parallax("50%",0);
	$('#parallax-3').parallax("50%",0);
	
	$('.variable-width').slick({
	  centerMode: true,
	  dots: false,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  speed: 300,
	  variableWidth: true,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 1024,
		  settings: {
			centerMode: true,
			variableWidth: true,
			slidesToShow:1
		  }
		},
		{
		  breakpoint: 850,
		  settings: {
			centerMode: true,
			variableWidth: false,
			slidesToShow:1
		  }
		},
		{
		  breakpoint: 767,
		  settings: {
			arrows: false,
			slidesToShow:1,
			variableWidth: false,
			centerMode: true
		  }
		},
		{
		  breakpoint: 550,
		  settings: {
			arrows: false,
			slidesToShow:1,
			centerMode: false,
			variableWidth: false
		  }
		}
	  ]
	});
	
	
	
	$('.testimonialslider').slick({
	  dots: false,
	  infinite: true,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  pauseOnHover: true,
	  responsive: [
		{
		  breakpoint: 850,
		  settings: {
			arrows: false,
		  }
		},
		{
		  breakpoint: 550,
		  settings: {
			arrows: false,
			
		  }
		}
	  ]
	});
	
	$('.clientslider').slick({
	  dots: false,
	  infinite: true,
	  slidesToShow: 5,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  arrows: false,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 1025,
		  settings: {
			arrows: false,
			slidesToShow:4
		  }
		},
		{
		  breakpoint: 850,
		  settings: {
			arrows: false,
			slidesToShow: 3
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	$('.singleslider').slick({
	  dots: true,
	  infinite: true,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  arrows: true,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 768,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	// slider page function
	
	$('.fixslider').slick({
	  dots: true,
	  infinite: true,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  arrows: true,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 768,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	// small images slider function
	$('.halfwidthleft').slick({
	  dots: true,
	  infinite: true,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  arrows: true,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 768,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	// content slider
	$('.contentslider').slick({
	  dots: true,
	  infinite: true,
	  slidesToShow: 1,
	  arrows: false,
	  autoplay: true,
	  autoplaySpeed: 8000,
	  pauseOnHover: true
	});
	
	$('.testimonialright').slick({
	  dots: true,
	  infinite: true,
	  slidesToShow: 1,
	  arrows: false,
	  autoplay: true,
	  autoplaySpeed: 8000,
	  pauseOnHover: true
	});
	
	// small images slider function
	$('.halfwidthright').slick({
	  dots: true,
	  infinite: true,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  arrows: false,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 768,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	//portfolioslider
	// small images slider function
	$('.portfolioslider').slick({
	  dots: false,
	  infinite: true,
	  slidesToShow: 1,
	  autoplay: true,
	  autoplaySpeed: 3000,
	  arrows: true,
	  pauseOnHover: false,
	  responsive: [
		{
		  breakpoint: 768,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			arrows: false,
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	
	//responsive menu
	$(function() {
    var html = $('html, body'),
        navContainer = $('.nav-container'),
        navToggle = $('.nav-toggle'),
        navDropdownToggle = $('.has-dropdown');

    // Nav toggle
    navToggle.on('click', function(e) {
        var $this = $(this);
        e.preventDefault();
        $this.toggleClass('is-active');
        navContainer.toggleClass('is-visible');
        html.toggleClass('nav-open');
    });
  
    // Nav dropdown toggle
    navDropdownToggle.on('click', function() {
        var $this = $(this);
        $this.toggleClass('is-active').children('ul').toggleClass('is-visible');
    });
  
    // Prevent click events from firing on children of navDropdownToggle
    navDropdownToggle.on('click', '*', function(e) {
        e.stopPropagation();
    });
	});
	
	// animation
	new WOW().init();
	
	// Porgress bar animation
	   $(".move").each(function() {
				$(this)
					.data("origWidth", $(this).width())
					.width(0)
					.animate({
						width: $(this).data("origWidth")
					}, 1500);
			});
	
	// number counter
	$('.counter').counterUp({
			delay: 10,
			time: 1000
		});
	//

	// portfolio function
	$(window).load(function(){
		if($('div').hasClass('portfoliodiv'))
		{
    var $container = $('.portfoliodiv');
    $container.isotope({
        filter: '.TopEight',
        animationOptions: {
            duration: 750,
            easing: 'linear',
            queue: false
        }
    });
		}
	$('.portfolioFilter ul li a').click(function(){
        $('.portfolioFilter .active').removeClass('active');
        $(this).addClass('active');
 
        var selector = $(this).attr('data-filter');
        $container.isotope({
            filter: selector,
            animationOptions: {
                duration: 750,
                queue: false
            }
         });
         return false;
    	});
	});
	
	// portfolio 4 page function
	$(window).load(function(){
		if($('div').hasClass('portfoliodiv4'))
		{
	var $container = $('.portfoliodiv4');
    $container.isotope({
        filter: '.TopEight',
		layoutMode: 'masonry',
        animationOptions: {
            duration: 750,
            easing: 'linear',
            queue: false
        }
    });
		}
	 
    $('.filter ul li a').click(function(){
        $('.filter .active').removeClass('active');
        $(this).addClass('active');
 
        var selector = $(this).attr('data-filter');
        $container.isotope({
            filter: selector,
            animationOptions: {
                duration: 750,
                queue: false
            }
         });
         return false;
    }); 
	});

	// footer form validation function
	
	// Twitter embbed code script
		window.twttr = (function(d, s, id) {
	  var js, fjs = d.getElementsByTagName(s)[0],
		t = window.twttr || {};
	  if (d.getElementById(id)) return t;
	  js = d.createElement(s);
	  js.id = id;
	  js.src = "https://platform.twitter.com/widgets.js";
	  fjs.parentNode.insertBefore(js, fjs);
	 
	  t._e = [];
	  t.ready = function(f) {
		t._e.push(f);
	  };
	 
	  return t;
	}(document, "script", "twitter-wjs"));
		
//main function over
});

