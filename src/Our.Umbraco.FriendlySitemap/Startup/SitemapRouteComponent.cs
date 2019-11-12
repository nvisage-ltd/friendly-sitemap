﻿using System.Web.Routing;
using Our.Umbraco.FriendlySitemap.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    internal class SitemapRouteComponet : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public SitemapRouteComponet(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public void Initialize()
        {
            RouteTable.Routes.MapUmbracoRoute(
                Constants.SitemapRouteName,
                Constants.SitemapRouteUrl,
                new
                {
                    controller = "Sitemap",
                    action = "RenderSitemap"
                },
                new RootNodeByDomainRouteHandler(_umbracoContextFactory)
            );
        }

        public void Terminate()
        {

        }
    }
}