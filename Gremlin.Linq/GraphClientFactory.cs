using System;
using Microsoft.Extensions.Configuration;

namespace Gremlin.Linq
{
    public class GraphClientFactory
    {
        private readonly IConfiguration _configuration;

        public GraphClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IGraphClient CreateGremlinGraphClient(GraphClientSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            return new GremlinGraphClient(settings.Url, settings.Database, settings.Collection, settings.Password);
        }

        public IGraphClient CreateGremlinGraphClient()
        {
            var settings = new GraphClientSettings(_configuration);
            return CreateGremlinGraphClient(settings);
        }
    }
}