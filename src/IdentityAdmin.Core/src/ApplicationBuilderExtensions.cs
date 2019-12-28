﻿// Copyright (c) 2018 Sarin Na Wangkanai, All Rights Reserved.
// The GNU GPLv3. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Builder;
using System;
using Wangkanai.IdentityAdmin;
using Wangkanai.IdentityAdmin.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIdentityAdmin(
            this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            VerifyIsRegistered(app);

            app.UseMiddleware<IdentityAdminMiddleware>();

            return app;
        }

        private static void VerifyIsRegistered(IApplicationBuilder app)
        {
            if (app.ApplicationServices.GetService(typeof(IdentityAdminMarkerService)) == null)
                throw new InvalidOperationException("AddIdentityAdmin() is not added to ConfigureServices(...)");
        }
    }
}