document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', async (event) => {
        event.preventDefault();
        
        const name = document.getElementById('name').value;
        const last_name = document.getElementById('lastname').value;
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;
        
        const requestBody = {
            name,
            last_name,
            email,
            password,
        };
        
        try {
            const response = await fetch('/api/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(requestBody),
            });
            
            if (response.ok) {
                const responseData = await response.json();
                console.log(responseData.message);
                alert("Registration successful!");
                window.location.href = "../WingsOfGlory/index.html";
            } else if (response.status === 400) {
                const responseData = await response.json();
                alert(responseData.message);
            } else {
                throw new Error(`Request failed with status ${response.status}`);
            }
        } catch (error) {
            console.error('Error during registration:', error);
            alert("Registration failed. Please try again.");
        }
    });
});