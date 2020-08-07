function printToConsole(message) {
    console.log(message);
}

function dotnetStaticInvocation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from javascript " + result);
        })
}

function dotnetInstanceInvokation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}