using SeP.Client.Infrastructure.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.SignUp.ViewModels
{
	public class SignUpViewModel : BaseViewModel
	{
		private string test = "SignUp view";
		public string Test
		{
			get => test;
			set => SetProperty(ref test, value);
		}
	}
}
