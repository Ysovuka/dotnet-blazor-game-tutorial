using Bunit;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

using SimpleRPG.Game.Client.Shared;
using SimpleRPG.Game.Tests.Mocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace SimpleRPG.Game.Tests
{
    public class NavMenuTests
    {
        [Fact]
        public void SimpleRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NavigationManager>(new MockNavigationManager());

            // act
            var cut = ctx.RenderComponent<NavMenu>();

            // assert
            var expected = @"<span class=""oi oi-home"" aria-hidden=""true"" b-j7w8km1egp></span> Home";
            Assert.Contains(expected, cut.Markup);
            expected = @"<div class=""collapse"" blazor:onclick=""2"" b-j7w8km1egp>";
            Assert.Contains(expected, cut.Markup);
        }

        [Fact]
        public void ToggleNavMenu()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NavigationManager>(new MockNavigationManager());

            // act
            var cut = ctx.RenderComponent<NavMenu>();
            cut.Find(".navbar-toggler").Click();

            // assert
            var expected = @"<div blazor:onclick=""2"" b-j7w8km1egp>";
            Assert.Contains(expected, cut.Markup);
        }
    }
}
