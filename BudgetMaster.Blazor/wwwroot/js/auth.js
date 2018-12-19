// app.js

window.addEventListener('load', function () {

    function getUrl(path) {
        return 'http://' + window.location.host + path;
    }

    var webAuth = new auth0.WebAuth({
        domain: 'blazor-budget2.auth0.com',
        clientID: 'M2xbg1AgrcwNil6f5OShwAKGV65vnmJY',
        responseType: 'token id_token',
        scope: 'openid profile',
        redirectUri: getUrl('/callback')
    });
    
    var userProfile;

    window.authFunctions = {
        beginAuth: function () {
            webAuth.authorize();
        },
        handleAuth: function () {
            console.log('Handling Auth');
            webAuth.parseHash(function (err, authResult) {
                console.log('Handling Auth Result');
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
            console.log('Setting Session');
            var expiresAt = JSON.stringify(
                authResult.expiresIn * 1000 + new Date().getTime()
            );
            localStorage.setItem('access_token', authResult.accessToken);
            localStorage.setItem('id_token', authResult.idToken);
            localStorage.setItem('expires_at', expiresAt);
            console.log('Session is set!');
        },
        getSessionItem: function (item) {
            return localStorage.getItem(item);
        },
        setSessionItem: function (item, value) {
            localStorage.setItem(item, value);
        },
        loadProfile: function() {
            if(!userProfile){
                console.log('Getting Profile');
                var accessToken = localStorage.getItem('access_token');
                console.log('Token Retrieved: ' + accessToken);
                
                if (!accessToken) {
                    console.log('Access Token must exist to fetch profile');
                }
                
                console.log('Getting user info from: ' + webAuth);
                
                webAuth.client.userInfo(accessToken, function(err, profile) {
                    if (profile) {
                        console.log('Setting Profile: ' + JSON.stringify(profile));
                        userProfile = profile;
                    } else {
                        console.log('Error getting profile: ' + err);
                    }
                });
                
                console.log('Profile Set Complete.')
            }
        },
        getUserName: function() {
            return userProfile.nickname;
        },
        getUserEmail: function() {
            return userProfile.email;
        }
        
    }
});
