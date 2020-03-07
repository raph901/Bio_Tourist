function checkPassword() {
    if (document.getElementById('PASSWORD_USER').value == document.getElementById('CONFIRMING_PASSWORD').value) {
        document.getElementById('message').style.color = 'green';
        document.getElementById('message').innerHTML = 'matching';
    } else {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = 'not matching';
    }
}
function img1click() {"https://www.google.com/search?q=image&safe=active&rlz=1C1CHBF_frFR880FR880&sxsrf=ACYBGNQwaXvy0z4CVInz-_i_I24_d_BKTA:1580806995215&tbm=isch&source=iu&ictx=1&fir=rQTDgjlYUmwEsM%253A%252CJ53VtjBzZJ6nxM%252C_&vet=1&usg=AI4_-kT9ZyfNymSyRSlLnFDn-YyLEheJ2Q&sa=X&ved=2ahUKEwix5qH7xLfnAhVLzhoKHUD1DBIQ9QEwAnoECAoQBw#imgrc=rQTDgjlYUmwEsM:"; }
