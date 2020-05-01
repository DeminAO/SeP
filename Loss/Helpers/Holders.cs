using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Loss.Models;

namespace Loss
{
	public static class Holders
	{

		public static bool FastCheck(this Statement st, IEnumerable<Models.Fact> allFacts)
		{
			var dic = allFacts.GroupBy(x => x.Parent.Name, (key, group) => group.GroupBy(g => g.Parent.ArgumentsCount));

			return false;
		}

		/// <summary> Преобразует предикат в список {Arg1, Arg2} </summary>
		/// <returns> Список аргументов предиката </returns>
		public static List<string> ToListArgs(this Fact fact) => fact.Arguments.ToList();

		/// <summary>
		/// Создает таблицу предикатов из списка предикатов, 
		/// преобразованных в списки своих аргументов
		/// </summary>
		/// <param name="l"> Список предикатов </param>
		/// <returns> Таблица </returns>
		public static List<List<string>> ToListArgs(this IEnumerable<Fact> list)
			=> list.Select(p => p.ToListArgs()).ToList();

		/// <summary>
		/// Ищет предикат в списке по имени
		/// </summary>
		/// <param name="name">Имя предиката</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtName(this ICollection<Predicate> predicates, Predicate predicate)
		{
			var res = predicates.FirstOrDefault(p => p.Name == predicate.Name);
			return res != null;
		}

		/// <summary>
		/// Ищет предикат в списке по имени
		/// </summary>
		/// <param name="name">Имя предиката</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtName(this ICollection<Predicate> predicates, string name)
		{
			var res = predicates.FirstOrDefault(p => p.Name == name);
			return res != null;
		}
		
		/// <summary>
		/// Ищет предикат в списке по имени
		/// </summary>
		/// <param name="name">Имя предиката</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtName(this ICollection<Fact> predicates, Fact predicate)
			=> predicates.Any(p => p.Parent.Name == predicate.Parent.Name);
		
		/// <summary>
		/// Ищет предикат в списке по имени
		/// </summary>
		/// <param name="name">Имя предиката</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtName(this ICollection<Fact> predicates, string name)
			=> predicates.Any(p => p.Parent.Name == name);
		
		/// <summary>
		/// Ищет предикат в списке по полному совпадению свойств
		/// </summary>
		/// <param name="predicate">Искомый предикат</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtAllProp(this ICollection<Fact> predicates, Fact predicate)
		{
			var resPred = predicates
				.FirstOrDefault(p =>
					p.Parent.Name == predicate.Parent.Name
					&&
					predicate.Arguments.All(x => p.Arguments.Contains(x)));

			return resPred != null;
		}

		/// <summary> Дублирует предикат </summary>
		/// <returns> Возвращает копию данного предиката</returns>
		public static Predicate Copy(this Predicate predicate)
			=> new Predicate { Name = predicate.Name, ArgumentsCount = predicate.ArgumentsCount };

		/// <summary> Создает копию списка предикатов. 
		/// Если name пуст - создается полная копия списка. 
		/// Иначе - создается список рпедикатов с именем name</summary>
		/// <param name="predicates"> Искомый Список предикатов </param>
		/// <param name="name"> Имя необходимых предикатов </param>
		/// <returns> Список копий предикатов </returns>
		public static List<Loss.Models.Predicate> Copy(this IEnumerable<Loss.Models.Predicate> predicates, string name = null)
		{
			IEnumerable<Predicate> res;

			if (string.IsNullOrEmpty(name))
				res = predicates.Select(p => p.Copy());
			else
				res = predicates.Where(p => p.Name == name).Select(p => p.Copy());

			return res.ToList();
		}

		/// <summary> Дублирует предикат </summary>
		/// <returns> Возвращает копию данного предиката</returns>
		public static Fact Copy(this Fact predicate)
			=> new Fact { Parent = predicate.Parent, Arguments = new ObservableCollection<string>(predicate.Arguments) };

		/// <summary> Создает копию списка предикатов. 
		/// Если name пуст - создается полная копия списка. 
		/// Иначе - создается список рпедикатов с именем name</summary>
		/// <param name="predicates"> Искомый Список предикатов </param>
		/// <param name="name"> Имя необходимых предикатов </param>
		/// <returns> Список копий предикатов </returns>
		public static List<Fact> Copy(this IEnumerable<Fact> predicates, string name = null)
		{
			IEnumerable<Fact> res;

			if (string.IsNullOrEmpty(name))
				res = predicates.Select(p => p.Copy());
			else
				res = predicates.Where(p => p.Parent.Name == name).Select(p => p.Copy());

			return res.ToList();
		}


		/// <summary>
		/// Проверяет наличие аргументов предиката predicate в списке предикатов высказывания statement 
		/// </summary>
		/// <param name="predicate">Искомый предикат</param>
		/// <param name="statement">Высказывание, в котором происходит поиск</param>
		/// <returns>true, если аргументы предиката есть в списке предикатов высказывания. Иначе - false</returns>
		public static bool ContainsAllPropPredicate(this Statement statement, Fact predicate)
		{
			return 
				statement
					.Predicates
					.Any(x => 
						predicate
							.Arguments
							.All(arg => 
								x.Arguments
									.Any(xarg => 
										arg == xarg 
										&& 
										x.Arguments.IndexOf(xarg) == predicate.Arguments.IndexOf(arg)
									)
							)
					);

		}

		/// <summary>
		/// Проверяет наличие высказывания в списке.
		/// Условие истинности - полное совпадение предикатов с одним из высказываний из списка
		/// </summary>
		/// <param name="statement">Искомое высказывание</param>
		/// <param name="statements">Список высказываний</param>
		/// <returns>true, если высказывание есть в списке, иначе - false</returns>
		public static bool HasStatement(this ICollection<Statement> statements, Statement statement)
		{
			if (!statements.Any()) return false;

			bool allEquals = false;
			foreach (Statement s in statements)
			{
				bool oneEqual = true;
				if ((statement.Predicates.Count == 1) && (s.Predicates.Count == 1))
				{
					foreach (Fact p in statement.Predicates)
						if (!s.Predicates.ContainsAtName(p)) oneEqual = false;
				}
				else
				{
					foreach (Fact p in statement.Predicates)
						if (!s.Predicates.ContainsAtAllProp(p)) oneEqual = false;
				}

				allEquals = allEquals || oneEqual;
			}

			return allEquals;
		}

		public static bool Contains(this ICollection<ICollection<string>> table, List<string> raw)
		{
			bool oneRaw = false;
			foreach (List<string> tRaw in table)
			{
				for (int i = 0; i < tRaw.Count; i++)
				{
					if (tRaw[i] != raw[i])
					{
						oneRaw = false;
						break;
					}
					else
					{
						oneRaw = true;
					}
				}
				if (oneRaw) return true;
			}
			return false;
		}

		/// <summary>
		/// Добавляет предикат в список, если его еще нет в нем
		/// </summary>
		/// <param name="p">Искомый предикат</param>
		public static void Add(this Statement statement, Fact p)
		{
			if (!statement.Predicates.ContainsAtAllProp(p)) statement.Predicates.Add(p);
		}

		/// <summary>
		/// Записывает результирующий предикат в высказывание
		/// </summary>
		/// <param name="pr">Искомый предикат</param>
		public static void SetResult(this Statement statement, Fact pr)
			=> statement.Result = new Fact { Parent = pr.Parent, Arguments = new ObservableCollection<string>(pr.Arguments) };

		/// <summary> Очищает список предикатов </summary>
		public static void Clear(this Statement statement) => statement.Predicates.Clear();

	}
}
