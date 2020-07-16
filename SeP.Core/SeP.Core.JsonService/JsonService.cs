using Newtonsoft.Json;
using SeP.Core.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace SeP.Core.JsonService
{
	public class JsonService: IJsonService
	{
		public T ParseString<T>(string json)
			=> JsonConvert.DeserializeObject<T>(json);

		public string ConvertToString<T>(T data)
			=> JsonConvert.SerializeObject(data);

		/// <summary>
		/// Считывает конфиг и возвращает его десериализованный в объект указанного типа
		/// </summary>
		// Длч корректной работы с данным методом необходимо копировать при сборке конфиги в папку настроек у нужного приложенич
		// Пример длч сервера: xcopy "$(ProjectDir)Settings\*.json" "$(SolutionDir)SeP.Service\SeP.Service.Svc\bin\$(ConfigurationName)\netcoreapp3.1\Settings\" /Y
		public T ReadConfig<T>() where T : new()
		{
			var assemblyLocation = Assembly.GetEntryAssembly().Location;

			var path = new FileInfo(assemblyLocation).Directory.FullName;
			
			var jsonFilePath = Path.Combine(path, "Settings", $"{typeof(T).Name}.json");
			
			var jsonText = File.ReadAllText(jsonFilePath);

			return ParseString<T>(jsonText);
		}
	}
}
