using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton { get; set; }
        [Inject] TransientService transient { get; set; }
        [Inject] IJSRuntime js{ get; set; }


        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            currentCountStatic++;
            singleton.Value = currentCount;
            transient.Value = currentCount;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        private async Task IncrementCountJavaScript()
        {
            await js.InvokeVoidAsync("dotnetInstanceInvokation",
                DotNetObjectReference.Create(this));
        }

        private List<Movie> movies;
        protected override void OnInitialized()
        {
            movies = new List<Movie>()
            {
                new Movie(){Title = "Lion King", ReleaseDate = new DateTime(2019, 7, 16) },
                new Movie(){Title = "A Clockwork Orange", ReleaseDate = new DateTime(2010, 7, 16) },
            };
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
