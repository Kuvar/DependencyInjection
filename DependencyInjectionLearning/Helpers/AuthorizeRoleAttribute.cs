using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DependencyInjectionLearning.Helpers
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (authTicket != null && !authTicket.Expired)
                    {
                        var identity = new GenericIdentity(httpContext.User.Identity.Name);
                        var roles = authTicket.UserData.Split(',');
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                    }
                }
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}