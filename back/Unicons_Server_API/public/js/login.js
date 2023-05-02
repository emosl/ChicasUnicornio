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
        window.location.href = "../html/index.html"; // REDIRECT TO VIDEOGAME
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





document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', async (event) => {
      event.preventDefault();
  
      const username = document.getElementById('email').value;
      const password = document.getElementById('password').value;
  
      const requestBody = { username, password };
  
      try {
        const response = await fetch('/api/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(requestBody),
        });
  
        const data = await response.json();
  
        if (response.ok) {
            const responseData = await response.json();
                console.log(responseData.message);
                alert("Registration successful!");
                window.location.href = "../html/index.html"; // REDIRECT TO VIDEOGAME
            } else if (response.status === 400) {
                const responseData = await response.json();
                alert(responseData.message);
            } else {
                throw new Error(`Request failed with status ${response.status}`);
            }
        } catch (error) {
            console.error('Inavlid USERNAME_ID or password:', error);
            alert("login failed. Please try again.");
        }
    });
  });
});
