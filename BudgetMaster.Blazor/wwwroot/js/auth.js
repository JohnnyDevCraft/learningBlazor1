// app.js

window.addEventListener('load', function () {

    function getUrl(path) {
        return 'http://' + window.location.host + path;
    }

    var webAuth = new auth0.WebAuth({
        domain: 'blazor-budget2.auth0.com',
        clientID: 'M2xbg1AgrcwNil6f5OShwAKGV65vnmJY',
        responseType: 'token id_token',
        scope: 'openid',
        redirectUri: getUrl('/callback')
    });

    window.authFunctions = {
        beginAuth: function () {
            webAuth.authorize();
        },
        handleAuth: function () {
            webAuth.parseHash(function (err, authResult) {
                if (authResult && authResult.accessToken && authResult.idToken) {
                    window.location.hash = '';
                    this.authFunctions.setSession(authResult);
                } else if (err) {
                    console.log(err);
                    alert(
                        'Error: ' + err.error + '. Check the console for further details.'
                    );
                }
            });
        },
        setSession: function (authResult) {
            var expiresAt = JSON.stringify(
                authResult.expiresIn * 1000 + new Date().getTime()
            );
            localStorage.setItem('access_token', authResult.accessToken);
            localStorage.setItem('id_token', authResult.idToken);
            localStorage.setItem('expires_at', expiresAt);
        },
        getSessionItem: function (item) {
            return localStorage.getItem(item);
        },
        setSessionItem: function (item, value) {
            localStorage.setItem(item, value);
        }
    }
});