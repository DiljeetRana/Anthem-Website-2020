$(document).ready(function(){
  var animTime = 300,
      clickPolice = false;
  
  $(document).on('touchstart click', '.acc-btn', function(){
    if(!clickPolice){
       clickPolice = true;
      
      var currIndex = $(this).index('.acc-btn'),
          targetHeight = $('.acc-content-inner').eq(currIndex).outerHeight();
   
      $('.acc-btn h1').removeClass('selected');
      $(this).find('h1').addClass('selected');
      
      $('.acc-content').stop().animate({ height: 0 }, animTime);
      $('.acc-content').eq(currIndex).stop().animate({ height: targetHeight }, animTime);

      setTimeout(function(){ clickPolice = false; }, animTime);
    }
    
  });
  
  
  $(document).on('touchstart click', '.acc-btn2', function(){
    if(!clickPolice){
       clickPolice = true;
      
      var currIndex = $(this).index('.acc-btn2'),
          targetHeight = $('.acc-content-inner2').eq(currIndex).outerHeight();
   
      $('.acc-btn2 h1').removeClass('selected');
      $(this).find('h1').addClass('selected');
      
      $('.acc-content2').stop().animate({ height: 0 }, animTime);
      $('.acc-content2').eq(currIndex).stop().animate({ height: targetHeight }, animTime);

      setTimeout(function(){ clickPolice = false; }, animTime);
    }
    
  });
   
 
  
  
  //over
  
});


