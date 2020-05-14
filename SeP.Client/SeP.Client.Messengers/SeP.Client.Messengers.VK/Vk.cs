using SeP.Client.Infrastructure.Enums;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace SeP.Client.Messengers.VkMessenger
{
	public class Vk : IVkMessenger
	{
		public MessengerTypes MessengerType { get; } = MessengerTypes.VK;


		public Vk()
		{
		}

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
