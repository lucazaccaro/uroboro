﻿window.exampleJsFunctions = {
    showPrompt: function (text) {
        return prompt(text, 'Type your name here');
    },
    displayWelcome: function (welcomeMessage) {
        document.getElementById('welcome').innerText = welcomeMessage;
    },
    returnArrayAsyncJs: function () {
        DotNet.invokeMethodAsync('Uroboro.PL.Blazor', 'ReturnArrayAsync')
            .then(data => {
                data.push(4);
                console.log(data);
            });
    },
    sayHello: function (dotnetHelper) {
        return dotnetHelper.invokeMethodAsync('SayHello')
            .then(r => console.log(r));
    },
    alertVoid: function () {
        alert('Hi, from Blazor');
    },
    focusElement: function (element) {
        element.focus();
    }
};

function updateMessageCallerJS(name) {
    DotNet.invokeMethodAsync('Uroboro.PL.Blazor', 'UpdateMessageCaller', name);
}
console.log('loaded');