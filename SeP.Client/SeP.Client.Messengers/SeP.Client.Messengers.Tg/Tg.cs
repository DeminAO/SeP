using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Enums;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace SeP.Client.Messengers.Tg
{
	public class Tg : ITgMessenger
	{
		public MessengerTypes MessengerType { get; } = MessengerTypes.Tg;
		public string AuthorityViewName { get; } = ViewNames.TgAuthority;

		public Tg() { }

		public bool Authorize(params object[] authParams)
		{
			if (authParams == null || authParams.Count() != 2)
				throw new ArgumentException("Неверное количество данных.");

			bool result = false;

			try
			{
				result = true;
			}
			catch (Exception e)
			{
				// log
			}

			return result;
		}
	}
}
