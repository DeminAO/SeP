using CrossMessenger.Client.Infrastructure.Enums;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CrossMessenger.Client.Messeging.ViewModels
{
	public class Contact
	{
		public List<MessengersTypes> Images { get; set; }
		public string Name { get; set; }
		public string LastMessage { get; set; }
	}

	public class DialogsViewPageViewModel : BindableBase
	{
		public ObservableCollection<Contact> Contacts { get; private set; }

		public DialogsViewPageViewModel()
		{
			Contacts = new ObservableCollection<Contact>(new Contact[]
			{
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Telegram, MessengersTypes.Vk }, LastMessage = "Давай", Name = "Влад Иванов" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Да так же", Name = "Юля Ростовская" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "понимаю", Name = "Даниил богданов" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Евгений Гурченко" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
				new Contact { Images =new List<MessengersTypes> { MessengersTypes.Vk }, LastMessage = "Ну ок)", Name = "Олег Демин" },
			});
		}
	}
}
