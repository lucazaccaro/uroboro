﻿using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Uroboro.PL.Blazor.Helpers
{
    public class JsInteropHelper : IDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private DotNetObjectReference<HelloHelper> objRef;

        public JsInteropHelper(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask<string> CallHelloHelperSayHello(string name)
        {
            objRef = DotNetObjectReference.Create(new HelloHelper(name));

            return jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.sayHello",
                objRef);
        }

        public void Dispose()
        {
            objRef?.Dispose();
        }
    }
}
