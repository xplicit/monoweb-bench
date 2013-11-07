using System;
using System.Collections.Generic;
using System.Linq;

using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace ServiceStackBenchmark
{
	[Api("Test #1 (JSON serialization) using Service Stack")]
	[Route("/json", "GET")]
	public class JsonRequest
	{

	}

	public class JsonResponse
	{
		public string message { get; set;} 
	}

	public class JsonService : Service
	{
		public static readonly JsonResponse response = new JsonResponse{ message = "Hello, World!" };

		public object Get(JsonRequest request)
		{
			//var response = new { message = "Hello, World!" };
			return response;
		}
	}

	[Api("Test #6 (Plaintext) using Service Stack")]
	[Route("/plaintext", "GET")]
	public class PlainTextRequest
	{

	}

	public class PlainTextService : Service
	{
		public object Get(PlainTextRequest request)
		{
			var response = new HttpResult("Hello, World!", "text/plain");
			return response;
		}
	}
}
