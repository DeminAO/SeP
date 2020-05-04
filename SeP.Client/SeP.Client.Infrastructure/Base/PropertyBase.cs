using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.Infrastructure.Base
{
	public class PropertyBase<T> : BindableBase
	{
		private T field;
		public T Property
		{
			get => field;
			set
			{
				SetProperty(ref field, value);
				RaisePropertyChanged(nameof(HasError));
			}
		}

		public Func<T, bool> HasErrorFunc;

		public bool HasError => HasErrorFunc(Property);

	}
}
