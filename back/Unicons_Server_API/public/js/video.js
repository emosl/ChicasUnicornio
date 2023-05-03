let myVideo = document.getElementById("myVideo");
myVideo.addEventListener("ended", function() {

  window.location = "http://127.0.0.1:8000/index.html";
});