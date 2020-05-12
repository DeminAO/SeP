using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace SeP.Client.Correspondences.ViewModels
{
	public class CorrespondencesViewModel : BaseViewModel
	{
		private readonly IMessengerCollectionService _mcs;

		private string test = "Correspondences view";
		public string Test
		{
			get => test;
			set => SetProperty(ref test, value);
		}

		public CorrespondencesViewModel(IMessengerCollectionService messengerCollectionService)
		{
			_mcs = messengerCollectionService;
		}
	}
}
