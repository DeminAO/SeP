using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SeP.Service.DataContext;

namespace SeP.Service.Svc
{
	public class GreeterService : Greeter.GreeterBase
	{
		private readonly ILogger<GreeterService> log;
		public GreeterService(ILogger<GreeterService> logger)
		{
			log = logger;
		}

		public async override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			log.LogDebug("SayHello invoked on server.");

			using var ctx = new Context();
			var user = await ctx.Users.FirstOrDefaultAsync(x => x.Id != Guid.Empty);

			return
				new HelloReply
				{
					Message = $"Hello, {request.Name} {user?.Id}"
				};
		}
	}
}
