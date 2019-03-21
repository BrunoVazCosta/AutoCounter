﻿using Owin;
using System;
using Microsoft.Owin;
using CounterApi.Providers;
using Microsoft.Owin.Security.OAuth;

namespace CounterApi
{ 
    public partial class Startup
    {
    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    static Startup()
    {
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/token"),
            Provider = new OAuthProvider(),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            AllowInsecureHttp = true
        };
    }
    public void ConfigureAuth(IAppBuilder app)
    {
        app.UseOAuthBearerTokens(OAuthOptions);
    }
}
}