namespace PropositionalLogic
{
	/// <summary>
	/// Класс предикат. Имеет имя, два псевдо-аргумента и методы обработки
	/// Является и классом для фактов
	/// </summary>
	public class Predicate
	{
		#region Props

		public string Arg2 { get; set; }
		public string Arg1 { get; set; }
		public string Name { get; set; }

		#endregion Props

		#region Ctor

		/// <summary> 
		/// Конструктор предиката
		/// Вместо ргументов можно подставлять конкретные значения для получения факта
		/// </summary>
		/// <param name="name">Имя предиката</param>
		/// <param name="arg1"> Имя левого аргумемнта </param>
		/// <param name="arg2"> Имя правого аргумемнта </param>
		public Predicate(string name, string arg1 = "x", string arg2 = "y")
		{
			Name = name;

			// Используются только в высказываниях!!!
			Arg1 = arg1;
			Arg2 = arg2;

		}

		#endregion Ctor

		/// <summary>
		/// Приводит предикат к строковому типу
		/// </summary>
		/// <returns>Строковое представление предиката</returns>
		public override string ToString()
			=> string.Join(" ", Arg1, Name, Arg2);

		/// <summary> Создает предикат из строкового представления </summary>
		/// <param name="line"> Строковое представление предиката </param>
		/// <returns> Полученный предикат </returns>
		public static Predicate FromString(string line)
		{
			if (line == "") return null;

			string[] args = line.Split(' ');
			Predicate res = null;

			if (args.Length == 1)
				res = new Predicate(args[0]);
			if (args.Length == 3)
				res = new Predicate(args[1], args[0], args[2]);

			return res;
		}

	}
}
