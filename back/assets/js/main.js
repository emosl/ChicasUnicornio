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
      delay: (el, i) => 800 * i 
    })
    .add({
      targets: "#grid-container-item2 h3 .word",
      scale: [14, 1],
      opacity: [0, 1],
      easing: "easeOutCirc",
      duration: 800,
      delay: (el, i) => 800 * i
    });
}, 2000);

// Function to redirect to the index page after a specified duration
function redirectToIndex() {
  setTimeout(function () {
    $('body').fadeOut(1000, function () {
      window.location.href = "index.html";
    });
  }, 9000); // Change the value to adjust the duration (in milliseconds) before redirection
}


// Document ready function
$(document).ready(function () {
  // ... (other existing code, if any)

  redirectToIndex();
});

// Existing code from index.js (if any)
// ...
