using System;
using System.Linq;
using System.Collections.Generic;

using ServiceStack;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.Redis;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.WebHost.Endpoints.Formats;


namespace ServiceStackBenchmark
{

	public class AppHost : AppHostBase
	{

		public AppHost() : base("ServiceStackBenchmark", typeof(AppHost).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			// Remove some unused features that by default are included
			//Plugins.RemoveAll(p => p is CsvFormat);
			//Plugins.RemoveAll(p => p is MetadataFeature);

			// Add plugins
			//Plugins.Add(new SwaggerFeature());

			// Get disable features specified in Config file (i.e. Soap, Metadata, etc.)
			//var disabled = AppHostConfigHelper.GetDisabledFeatures();

			// Construct Service Endpoint Host Configuration store
			/*var config = new EndpointHostConfig
			{
				DefaultRedirectPath = "/swagger-ui/index.html", // default to the Swagger page
				DefaultContentType = ContentType.Json,
				WriteErrorsToResponse = false,
				EnableFeatures = Feature.All.Remove(disabled),
				AppendUtf8CharsetOnContentTypes = new HashSet<string> { ContentType.Html },
			};

			// Apply configuration
			SetConfig(config);
			*/
			base.SetConfig(new EndpointHostConfig
			{
				GlobalResponseHeaders =
				{
					{ "Access-Control-Allow-Origin", "*" },
					{ "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" }
				},
			});



			// Initialize Databases & associated Routes
			//container.InitDatabaseRoutes(Routes);

			// Register Cache Clients
			container.Register<ICacheClient>(new MemoryCacheClient());

			// Register Redis Client Manager
			//container.Register<IRedisClientsManager>(c =>
			//	new PooledRedisClientManager("localhost:6379"));
		}

	}
}