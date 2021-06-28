namespace CrossMessenger.Client.Infrastructure.Models.ResultCore
{
	public class Result
	{
		public bool Success { get; protected set; }
		public string Error { get; protected set; }

		public static Result GetSucceed() => true;
		public static Result GetFailure(string error) => new Result { Error = error };
	
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

		public static new Result<T> GetFailure(string error) => new Result<T>
		{
			Success = false,
			Error = error
		};
	}
}
