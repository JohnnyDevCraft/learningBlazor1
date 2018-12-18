// Initializing our Auth0Lock
var options = {
    oidcConformant: true
};

var lock = new Auth0Lock(
    'M2xbg1AgrcwNil6f5OShwAKGV65vnmJY',
    'blazor-budget2.auth0.com',
    options
);

// Listening for the authenticated event
lock.on("authenticated", function(authResult) {
    // Use the token in authResult to getUserInfo() and save it to localStorage
    functions.authenticated(authResult);
});

window.functions = {
    showLock: function () {
        lock.show();
        console.log("Attempted to show lock.");
    },    
    authenticated: function(authResult){
        lock.getUserInfo(authResult.accessToken, function(error, profile) {
            if (error) {
                alert(error);
                return;
            }
            localStorage.setItem('accessToken', authResult.accessToken);
            localStorage.setItem('profile', JSON.stringify(profile));
            
            DotNet.invokeMethodAsync("BudgetMaster.Blazor", "RegisterUser", authResult.accessToken, JSON.stringify(profile));
        });
    }
};