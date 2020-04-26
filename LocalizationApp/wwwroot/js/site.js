window.exampleJsFunctions = {
    appTop: function (settings) {
        console.log(settings);
        //console.log(JSON.stringify(settings));
        //console.log(JSON.parse(settings));

        //let a = JSON.stringify(settings);
        //let b = JSON.parse(a);

        //let s = settings.slice(1, -1);

        //console.log(a);
        //console.log(b);

        //fetch('/Culture/SetCulture?culture=&redirectionUri=')
        //    .then((response) => {
        //        console.log(response);
        //    })
        //    .catch((error) => {
        //        console.error('There has been a problem with your fetch operation:', error);
        //    });


        var defTop = document.getElementById("def-top");
        defTop.outerHTML = wet.builder.appTop(settings);
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