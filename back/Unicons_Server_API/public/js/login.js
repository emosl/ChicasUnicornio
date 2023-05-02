document.addEventListener('DOMContentLoaded', () => {
const loginForm = document.querySelector('#login-form');

loginForm.addEventListener('submit', async (event) => {
  event.preventDefault();

  const email = document.querySelector('#email').value;
  const password = document.querySelector('#password').value;

  try {
    const response = await fetch('/api/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ email, password })
    });

    if (response.ok) {
      const responseData = await response.json();
        console.log(responseData.message);
        alert(`Welcome, your id is:${responseData.username_ID}!`);
        window.location.href = "../WingsOfGlory/index.html";
    }else if(response.status === 400){
      const responseData = await response.json();
                alert(responseData.message);

    }else {
      throw new Error(`Request failed with status ${response.status}`);
    }
  } catch (error) {
    console.error('Inavlid mail or password:', error);
            alert("login failed. Please try again.");
  }
});
});