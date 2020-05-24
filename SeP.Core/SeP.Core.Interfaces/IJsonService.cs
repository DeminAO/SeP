using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Core.Interfaces
{
	public interface IJsonService
	{
		public T ParseString<T>(string json);
		public string ConvertToString<T>(T data);

		/// <summary>
		/// Считывает конфиг и возвращает его десериализованный в объект указанного типа
		/// </summary>
		// Длч корректной работы с данным методом необходимо копировать при сборке конфиги в папку настроек у нужного приложенич
		// Пример длч сервера: xcopy "$(ProjectDir)Settings\*.json" "$(SolutionDir)SeP.Service\SeP.Service.Svc\bin\$(ConfigurationName)\netcoreapp3.1\Settings\" /Y
		public T ReadConfig<T>() where T : new();
	}
}
