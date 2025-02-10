using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digitalisation_Funding.Models;
using Digitalisation_Funding.Extensions;

namespace Digitalisation_Funding.Services.HttpServices
{
    public class CartSession: Cart
    {
        //Properties
        [JsonIgnore]
        public ISession Session { get; set; }

        //Methods
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            CartSession CartSession = session?.GetJson<CartSession>("Cart")
                ?? new CartSession();

            CartSession.Session = session;
            return CartSession;
        }

        public override void AddItem(string firstName, string lastName)
        {
            base.AddItem(firstName, lastName);
            Session.SetJson("Cart", this);
        }

        public override void RemoveImage(string firstName, string lastName)
        {
            base.RemoveImage(firstName, lastName);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }

    }
}