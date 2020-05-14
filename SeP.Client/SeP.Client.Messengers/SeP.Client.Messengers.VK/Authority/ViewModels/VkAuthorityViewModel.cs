using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Interfaces;

namespace SeP.Client.Messengers.VK.Authority.ViewModels
{
	public class VkAuthorityViewModel : BaseViewModel, IAuthorityModel
	{
		private bool isUsed;
		public bool IsUsed
		{
			get => isUsed;
			set => SetProperty(ref isUsed, value);
		}
	}
}
