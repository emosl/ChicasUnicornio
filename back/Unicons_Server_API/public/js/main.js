// Existing code from landing.js
// 1
setTimeout(function () {
  anime.timeline()
    .add({
      targets: "#grid-container-item1 h1 .word",
      scale: [14, 1],
      opacity: [0, 1],
      easing: "easeOutCirc",
      duration: 600,
      delay: (el, i) => 500 * i 
    })
    .add({
      targets: "#grid-container-item2 h3 .word",
      scale: [14, 1],
      opacity: [0, 1],
      easing: "easeOutCirc",
      duration: 600,
      delay: (el, i) => 500 * i
    });
}, );


// Function to redirect to the index page after a specified duration
function redirectToIndex() {
  setTimeout(function () {
    $('body').fadeOut(1000, function () {
      window.location.href = "index.html";
    });
  }, 6000); // Change the value to adjust the duration (in milliseconds) before redirection
}
$(function() {
  var body = $('#starshine'),
      template = $('.template.shine'),
      stars =  500,
      sparkle = 20;
  
    
  var size = 'small';
  var createStar = function() {
    template.clone().removeAttr('id').css({
      top: (Math.random() * 100) + '%',
      left: (Math.random() * 100) + '%',
      webkitAnimationDelay: (Math.random() * sparkle) + 's',
      mozAnimationDelay: (Math.random() * sparkle) + 's'
    }).addClass(size).appendTo(body);
  };
 
  for(var i = 0; i < stars; i++) {
    if(i % 2 === 0) {
      size = 'small';
    } else if(i % 3 === 0) {
      size = 'medium';
    } else {
      size = 'large';
    }
    
    createStar();
  }
});

$(function () {
  redirectToIndex();
});


