using System.Collections.Generic;
using System.Linq;

namespace PropositionalLogic
{
	public static class Holders
	{

		/// <summary> Преобразует предикат в список {Arg1, Arg2} </summary>
		/// <returns> Список аргументов предиката </returns>
		public static List<string> ToListArgs(this Predicate predicate)
		{
			List<string> res = new List<string>
			{
				predicate.Arg1,
				predicate.Arg2
			};

			return res;
		}

		/// <summary>
		/// Создает таблицу предикатов из списка предикатов, 
		/// преобразованных в списки своих аргументов
		/// </summary>
		/// <param name="l"> Список предикатов </param>
		/// <returns> Таблица </returns>
		public static List<List<string>> ToListArgs(this List<Predicate> list)
		{
			IEnumerable<List<string>> res = list.Select(p => p.ToListArgs());

			return res.ToList();
		}

		/// <summary>
		/// Ищет предикат в списке по имени
		/// </summary>
		/// <param name="name">Имя предиката</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtName(this List<Predicate> predicates, Predicate predicate)
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
		public static bool ContainsAtName(this List<Predicate> predicates, string name)
		{
			var res = predicates.FirstOrDefault(p => p.Name == name);
			return res != null;
		}

		/// <summary>
		/// Ищет предикат в списке по полному совпадению свойств
		/// </summary>
		/// <param name="predicate">Искомый предикат</param>
		/// <param name="predicates">Список предикатов</param>
		/// <returns>Возращает true, если предикат есть, иначе - false</returns>
		public static bool ContainsAtAllProp(this List<Predicate> predicates, Predicate predicate)
		{
			var resPred = predicates
				.FirstOrDefault(p => 
					p.Name == predicate.Name 
					&& 
					(p.Arg1 == predicate.Arg1) 
					&& 
					(p.Arg2 == predicate.Arg2)
				);

			return resPred != null;
		}

		/// <summary> Дублирует предикат </summary>
		/// <returns> Возвращает копию данного предиката</returns>
		public static Predicate Copy(this Predicate predicate) 
			=> new Predicate(predicate.Name, predicate.Arg1, predicate.Arg2);

		/// <summary> Создает копию списка предикатов. 
		/// Если name пуст - создается полная копия списка. 
		/// Иначе - создается список рпедикатов с именем name</summary>
		/// <param name="predicates"> Искомый Список предикатов </param>
		/// <param name="name"> Имя необходимых предикатов </param>
		/// <returns> Список копий предикатов </returns>
		public static List<Predicate> Copy(this List<Predicate> predicates, string name = "")
		{
			IEnumerable<Predicate> res;

			if (name == "")
				res = predicates.Select(p => p.Copy());
			else
				res = predicates.Where(p => p.Name == name).Select(p => p.Copy());

			return res.ToList();
		}


		/// <summary>
		/// Проверяет наличие аргументов предиката predicate в списке предикатов высказывания statement 
		/// </summary>
		/// <param name="predicate">Искомый предикат</param>
		/// <param name="statement">Высказывание, в котором происходит поиск</param>
		/// <returns>true, если аргументы предиката есть в списке предикатов высказывания. Иначе - false</returns>
		public static bool ContainsAllPropPredicate(this Statement statement, Predicate predicate)
		{
			bool issetArg1 = false;
			bool issetArg2 = false;

			string pArg1 = predicate.Arg1;
			string pArg2 = predicate.Arg2;

			foreach (Predicate p in statement.Predicates)
			{
				if ((p.Arg1 == pArg1) || (p.Arg2 == pArg1)) issetArg1 = true;
				if ((p.Arg2 == pArg2) || (p.Arg1 == pArg2)) issetArg2 = true;

				if (issetArg1 && issetArg2) return true;
			}

			return false;
		}

		/// <summary>
		/// Проверяет наличие высказывания в списке.
		/// Условие истинности - полное совпадение предикатов с одним из высказываний из списка
		/// </summary>
		/// <param name="statement">Искомое высказывание</param>
		/// <param name="statements">Список высказываний</param>
		/// <returns>true, если высказывание есть в списке, иначе - false</returns>
		public static bool HasStatement(this List<Statement> statements, Statement statement)
		{
			if (statements.Count == 0) return false;
			bool allEquals = false;
			foreach (Statement s in statements)
			{
				bool oneEqual = true;
				if ((statement.Predicates.Count == 1) && (s.Predicates.Count == 1))
				{
					foreach (Predicate p in statement.Predicates)
						if (!s.Predicates.ContainsAtName(p)) oneEqual = false;
				}
				else
				{
					foreach (Predicate p in statement.Predicates)
						if (!s.Predicates.ContainsAtAllProp(p)) oneEqual = false;
				}

				allEquals = allEquals || oneEqual;
			}

			return allEquals;
		}

		public static bool Contains(this List<List<string>> table, List<string> raw)
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
		public static void Add(this Statement statement, Predicate p)
		{
			if (!statement.Predicates.ContainsAtAllProp(p)) statement.Predicates.Add(p);
		}

		/// <summary>
		/// Записывает результирующий предикат в высказывание
		/// </summary>
		/// <param name="pr">Искомый предикат</param>
		public static void SetResult(this Statement statement, Predicate pr)
			=> statement.Result = new Predicate(pr.Name, pr.Arg1, pr.Arg2);

		/// <summary> Очищает список предикатов </summary>
		public static void Clear(this Statement statement) => statement.Predicates.Clear();

	}
}
