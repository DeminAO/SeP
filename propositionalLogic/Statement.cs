using System;
using System.Collections.Generic;
using System.Linq;

namespace PropositionalLogic
{

	/// <summary>
	/// Класс Высказывание
	/// Содержит список предикатов из которых был составлен
	/// Result - предикат, по которому составляется новый факт
	/// </summary>
	public class Statement
	{
		#region Props

		public List<Predicate> Predicates { get; set; }

		public Predicate Result { get; set; }

		#endregion Props

		#region Ctor

		/// <summary>
		/// Конструктор
		/// </summary>
		public Statement()
		{
			Predicates = new List<Predicate>();
		}

		#endregion Ctor

		/// <summary>
		/// Приводит высказывание с строковому типу
		/// </summary>
		/// <returns>Возращает строковое представление высказывания</returns>
		public override string ToString()
		{
			string result = string.Join(" AND ", Predicates.Select(p => p.ToString()));
			if (Result != null) result += " -> " + Result.ToString();
			
			return result;
		}

		/// <summary>
		/// Создает экземпляр высказывания из строкового представления
		/// </summary>
		/// <param name="line">Строка, содержащая информацию о высказывании</param>
		/// <returns>Высказывание, полученное при преобразовании</returns>
		public static Statement FromString(string line)
		{
			if (line == "") return null;
			Statement res = new Statement();
			string[] args = line.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			string[] predic = args[0].Split(" AND ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
   
			res.Predicates.AddRange(predic.Select(str => Predicate.FromString(str.Trim())));

			res.Result = Predicate.FromString(args[1].Trim());

			return res;

		}
	}
}
