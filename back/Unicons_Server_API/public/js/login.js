
function login() {
  var username = document.getElementById("username").value;
  var password = document.getElementById("password").value;
  // You can add authentication logic here to check the username and password
  // and redirect the user to the game if the credentials are correct.
  window.location.href="../html/game.html";
}

function redirectToGame() {
  window.location.href = "../html/index.html";
}
