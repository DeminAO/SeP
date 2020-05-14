using Prism.Mvvm;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.Messengers.VK.Authority.Models
{
	public class VkAuthorityModel : BindableBase, IAuthorityModel
	{
		private bool isUsed;
		public bool IsUsed
		{
			get => isUsed;
			set => SetProperty(ref isUsed, value);
		}
	}
}
