﻿using Microsoft.JSInterop;

namespace Uroboro.PL.Blazor.Helpers
{
    public class HelloHelper
    {
        public HelloHelper(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        [JSInvokable]
        public string SayHello() => $"Hello, {Name}!";
    }
}
