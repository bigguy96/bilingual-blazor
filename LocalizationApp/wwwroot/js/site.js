window.exampleJsFunctions = {
    appTop: function (appName, lang, alternateLink, text) {
        var defTop = document.getElementById("def-top");
        defTop.outerHTML = wet.builder.appTop({
            "appName": [{ "text": appName, "href": "#" }],
            "lngLinks": [{ "lang": lang, "href": alternateLink, "text": text }],
            "menuLinks": [{
                "href": "#",
                "text": "Link 1"
            }, {
                "href": "#",
                "text": "Link 2"
            }, {
                "href": "#",
                "text": "Link 3"
            }, {
                "href": "#",
                "text": "Link 4"
            }]
        });
    }
    //displayWelcome: function (welcomeMessage) {
    //    document.getElementById('welcome').innerText = welcomeMessage;
    //},
    //returnArrayAsyncJs: function () {
    //    DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
    //        .then(data => {
    //            data.push(4);
    //            console.log(data);
    //        });
    //},
    //sayHello: function (dotnetHelper) {
    //    return dotnetHelper.invokeMethodAsync('SayHello')
    //        .then(r => console.log(r));
    //}
};