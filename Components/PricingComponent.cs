using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Components
{
    public class PricingComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PricingViewModel pricing)
        {
            return await Task.FromResult((IViewComponentResult)View("PricingView", pricing));
        }
    }
}
