// Existing code from landing.js
// 1

setTimeout(function () {
  anime.timeline()
    .add({
      targets: "#grid-container-item1 h1 .word",
      scale: [14, 1],
      opacity: [0, 1],
      easing: "easeOutCirc",
      duration: 800,
      delay: (el, i) => 500 * i 
    })
    .add({
      targets: "#grid-container-item2 h3 .word",
      scale: [14, 1],
      opacity: [0, 1],
      easing: "easeOutCirc",
      duration: 800,
      delay: (el, i) => 500 * i
    });
}, );

// Function to redirect to the index page after a specified duration
function redirectToIndex() {
  setTimeout(function () {
    $('body').fadeOut(1000, function () {
      window.location.href = "index.html";
    });
  }, 5000); // Change the value to adjust the duration (in milliseconds) before redirection
}


// Document ready function
$(document).ready(function () {
  // ... (other existing code, if any)

  redirectToIndex();
});

// Existing code from index.js (if any)
// ...
//Boton login
document.getElementById("bot").onclick = function(){
  document.getElementById("idOfYourForm").submit();
};

$(function(){
  $("#button").bind("click",function(){
      $("#idOfYourForm").submit();  // consider idOfYourForm `id` of your form which you are going to submit
  });
});

