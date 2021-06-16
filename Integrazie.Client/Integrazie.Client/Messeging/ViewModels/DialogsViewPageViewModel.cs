using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossMessenger.Client.Messeging.ViewModels
{
	public class Contact
	{
		public List<string> Images { get; set; }
		public string Name { get; set; }
		public string LastMessage { get; set; }
	}

	public class DialogsViewPageViewModel : BindableBase
	{
		public List<Contact> Contacts { get; private set; }

		public DialogsViewPageViewModel()
		{
			Contacts = new List<Contact>
			{
				new Contact { Images =new List<string> { "tglogo.png", "vklogo.png" }, LastMessage = "Давай", Name = "Влад Иванов" },
				new Contact { Images =new List<string> { "vklogo.png" }, LastMessage = "Да так же", Name = "Юля Ростовская" },
				new Contact { Images =new List<string> { "vklogo.png" }, LastMessage = "понимаю", Name = "Даниил богданов" },
				new Contact { Images =new List<string> { "tglogo.png" }, LastMessage = "Ну ок)", Name = "Евгений Гурченко" },
				new Contact { Images =new List<string> { "vklogo.png" }, LastMessage = "Ну ок)", Name = "Олег Демин" },
			};
		}
	}
}
