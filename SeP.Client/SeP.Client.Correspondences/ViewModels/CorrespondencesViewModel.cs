using SeP.Client.Infrastructure.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.Correspondences.ViewModels
{
	public class CorrespondencesViewModel : BaseViewModel
	{
		private string test = "Correspondences view";
		public string Test
		{
			get => test;
			set => SetProperty(ref test, value);
		}
	}
}
