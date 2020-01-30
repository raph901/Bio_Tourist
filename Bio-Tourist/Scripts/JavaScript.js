function checkPassword() {
    if (document.getElementById('PASSWORD_USER').value == document.getElementById('CONFIRMING_PASSWORD').value) {
        document.getElementById('message').style.color = 'green';
        document.getElementById('message').innerHTML = 'matching';
    } else {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = 'not matching';
    }
}