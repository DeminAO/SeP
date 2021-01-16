using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeP.Core.Proto;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SeP.Service.DataContext;
using System.Runtime.CompilerServices;
using SeP.Service.DataContext.Entities;

namespace SeP.Service.Svc
{
	/// <summary>
	/// Тестовый интерфейс длч проверки, что работает. 
	/// Перенести в отдельный проект с прототипом. 
	/// Наследовать клиентом и сервером
	/// </summary>
	public interface IBase
	{
		Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);
		Task<ReplingDataBase> SignIn(SignInRequest request, ServerCallContext context);
		Task<SignUpReplingData> SignUp(SignUpRequest request, ServerCallContext context);
	}

	public class GreeterService : Greeter.GreeterBase, IBase
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

		public async override Task<ReplingDataBase> SignIn(SignInRequest request, ServerCallContext context)
		{
			using var ctx = new Context();
			var user = await ctx.Users.FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == request.Password);

			return new ReplingDataBase()
			{
				IsSuccessed = user != null,
				Error = user != null ? string.Empty : "Некорректные данные."
			};
		}

		public override async Task<SignUpReplingData> SignUp(SignUpRequest request, ServerCallContext context)
		{
			var isSuccess = true;
			Guid id = Guid.Empty;

			try
			{
				using var ctx = new Context();
				var user = new User
				{
					Id = Guid.NewGuid(),
					Login = request.Login,
					Password = request.Password,
					Initials = request.Initials
				};
				
				var result = await ctx.AddAsync(user);
				await ctx.SaveChangesAsync();

				id = result.Entity.Id;
			}
			catch (Exception e)
			{
				isSuccess = false;
			}

			return new SignUpReplingData
			{
				IsSuccessed = isSuccess,
				Error = isSuccess ? string.Empty : "Некорректные данные",
				NewId = id.ToString()
			};
		}

		//public override Task<GoodByeReply> SayGoodBye(HelloRequest request, ServerCallContext context)
		//{
		//	return Task.Run(() =>
		//	{
		//		var result = new GoodByeReply();

		//		result.Results.AddRange(new List<string>(){ "", "" });

		//		return result;
		//	});

		//}
	}
}
