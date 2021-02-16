namespace SeP.Client.Cross.Infrastructure.Models.ResultCore
{
	public class Result
	{
		public bool Success { get; protected set; }

		public static Result GetSucceed() => true;
		public static Result GetFailure() => false;
	
		public static implicit operator bool(Result result) => result.Success;
		public static implicit operator Result(bool result) => new Result { Success = result };
	}

	public class Result<T> : Result
	{
		public T Context { get; private set; }

		public static Result<T> GetSucceed(T result) => new Result<T>
		{
			Context = result,
			Success = true
		};

		public static new Result<T> GetFailure() => new Result<T>
		{
			Success = false
		};
	}
}
