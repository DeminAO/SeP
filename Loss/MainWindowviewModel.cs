using CudaLybrary;
using Loss.Helpers;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Loss
{
	public class MainWindowViewModel : BindableBase
	{
		//private string codeText;
		//public string CodeText
		//{
		//	get => codeText;
		//	set => SetProperty(ref codeText, value);
		//}

		private Models.Predicate newPredicate;
		public Models.Predicate NewPredicate
		{
			get
			{
				if (newPredicate == null)
					newPredicate = new Models.Predicate();
				return newPredicate;
			}
			set => SetProperty(ref newPredicate, value);
		}

		private Models.Fact newFact;
		public Models.Fact NewFact
		{
			get
			{
				if (newFact == null)
					newFact = new Models.Fact();
				return newFact;
			}
			set => SetProperty(ref newFact, value);
		}

		private Models.Statement newStatement;
		public Models.Statement NewStatement
		{
			get
			{
				if (newStatement == null)
					newStatement = new Models.Statement();
				return newStatement;
			}
			set => SetProperty(ref newStatement, value);
		}

		private ObservableCollection<Models.Predicate> predicates;
		public ObservableCollection<Models.Predicate> Predicates
		{
			get => predicates;
			set => SetProperty(ref predicates, value);
		}

		private ObservableCollection<Models.Fact> facts;
		public ObservableCollection<Models.Fact> Facts
		{
			get => facts;
			set => SetProperty(ref facts, value);
		}
		
		private ObservableCollection<Models.Fact> addedFacts;
		public ObservableCollection<Models.Fact> AddedFacts
		{
			get => addedFacts;
			set => SetProperty(ref addedFacts, value);
		}

		private ObservableCollection<Models.Statement> statements;
		public ObservableCollection<Models.Statement> Statements
		{
			get => statements;
			set => SetProperty(ref statements, value);
		}

		public ICommand StartCommand { get; private set; }
		public ICommand AddPredicateCommand { get; private set; }
		public ICommand AddFactCommand { get; private set; }
		public ICommand AddFactAtStatementCommand { get; private set; }
		public ICommand AddNewStatementCommand { get; private set; }

		public MainWindowViewModel()
		{
			StartCommand = new DelegateCommand(OnStartCommand);
			AddPredicateCommand = new DelegateCommand(OnAddPredicateCommand);
			AddFactCommand = new DelegateCommand(OnAddFactCommand);
			AddFactAtStatementCommand = new DelegateCommand(OnAddFactAtStatementCommand);
			AddNewStatementCommand = new DelegateCommand(OnAddNewStatementCommand);

#if DEBUG
			Init();

#endif
		}

		private void Init()
		{
			Predicates = new ObservableCollection<Models.Predicate>(new List<Models.Predicate>
			{
				new Models.Predicate()
				{
					Name = "pred1",
					ArgumentsCount = 2
				},

				new Models.Predicate()
				{
					Name = "pred2",
					ArgumentsCount = 4
				},

			});

			Facts = new ObservableCollection<Models.Fact>(new List<Models.Fact>
			{
				new Models.Fact
				{
					Parent = Predicates.First(),
					Arguments = new ObservableCollection<string>(new List<string>{ "arg1", "arg2"})
				},

				new Models.Fact
				{
					Parent = Predicates.First(x => x.ArgumentsCount == 4),
					Arguments = new ObservableCollection<string>(new List<string>{ "arg1", "arg2", "arg3", "arg4"})
				},


			});

			Statements = new ObservableCollection<Models.Statement>(new List<Models.Statement>
			{

				new Models.Statement
				{
					Predicates = new ObservableCollection<Models.Fact>(new List<Models.Fact>
					{
						new Models.Fact
						{
							Parent = Predicates.First(),
							Arguments = new ObservableCollection<string>(new List<string>{ "a", "b"})
						},

						new Models.Fact
						{
							Parent = Predicates.First(),
							Arguments = new ObservableCollection<string>(new List<string>{ "b", "c"})
						},


					}),

					Result = new Models.Fact
					{
						Parent = Predicates.First(),
						Arguments = new ObservableCollection<string>(new List<string>{ "a", "c"})
					}
				},
				
				new Models.Statement
				{
					Predicates = new ObservableCollection<Models.Fact>(new List<Models.Fact>
					{
						new Models.Fact
						{
							Parent = Predicates.First( x => x.ArgumentsCount == 4),
							Arguments = new ObservableCollection<string>(new List<string>{ "a", "b", "c", "d"})
						},

						new Models.Fact
						{
							Parent = Predicates.First(),
							Arguments = new ObservableCollection<string>(new List<string>{ "b", "c"})
						},


					}),

					Result = new Models.Fact
					{
						Parent = Predicates.First(),
						Arguments = new ObservableCollection<string>(new List<string>{ "a", "d"})
					}
				}

			});
		}

		private void OnStartCommand()
		{
			bool wasChanged = true;

			while (wasChanged)
			{
				wasChanged = false;

				foreach (Models.Statement st in Statements)
				{
					// аргументы высказывания. Так же - заголовок таблицы
					List<string> argsSt = st.Predicates.SelectMany(x => x.Arguments).ToList();

					//foreach (Models.Fact pr in st.Predicates)
					//{
					//	string arg1 = pr.Arg1;
					//	string arg2 = pr.Arg2;

					//	if (!argsSt.Contains(arg1)) argsSt.Add(arg1);
					//	if (!argsSt.Contains(arg2)) argsSt.Add(arg2);
					//}



					List<List<string>> tbl = new List<List<string>>();
					foreach (Models.Fact p in st.Predicates)
					{

						List<Models.Fact> lstFacts = Facts.Copy(p.Parent.Name);
						List<List<string>> strFacts = lstFacts.ToListArgs();
						if (tbl.Count == 0)
						{
							tbl = strFacts;
							continue;
						}
						else
						{
							List<List<string>> tbl0 = new List<List<string>>();
							foreach (List<string> row1 in tbl)
							{
								foreach (Models.Fact row2 in lstFacts)
								{

									List<String> tmp = new List<string>();
									tmp.AddRange(row1);

									int indArg = argsSt.IndexOf(p.Arg1);
									if (indArg < row1.Count)
										if (row1[indArg] != row2.Arg1) continue;

									if (indArg >= row1.Count)
										tmp.Add(row2.Arg1);

									indArg = argsSt.IndexOf(p.Arg2);
									if (indArg < row1.Count)
										if (row1[indArg] != row2.Arg2) continue;

									if (indArg >= row1.Count)
										tmp.Add(row2.Arg2);

									if (!tbl0.Contains(tmp))
									{
										tbl0.Add(tmp);
									}
								}
							}
							tbl = tbl0;
						}

					}

					foreach (List<string> row in tbl)
					{
						int indResArg1 = argsSt.IndexOf(st.Result.Arg1);
						int indResArg2 = argsSt.IndexOf(st.Result.Arg2);
						Models.Fact factNew = new Models.Fact (st.Result.Name, row[indResArg1], row[indResArg2]);

						if (!Facts.ContainsAtAllProp(factNew))
						{
							Facts.Add(factNew);
							AddedFacts.Add(factNew);
							wasChanged = true;

						}
					}
				}
			}
		}

		private void OnAddPredicateCommand()
		{
			if (
				!NewPredicate.ArgumentsCount.HasValue
				||
				string.IsNullOrEmpty(NewPredicate.Name)
				||
				Predicates
					.Any(x =>
							x.ArgumentsCount == NewPredicate.ArgumentsCount
							&&
							x.Name.ToUpper() == NewPredicate.Name.ToUpper()
						)
				)
				return;

			NewPredicate.Name = newPredicate.Name.ToLower();

			Predicates.Add(NewPredicate);
			NewPredicate = new Models.Predicate();
		}
		
		private void OnAddFactCommand()
		{
			if (
				NewFact.Parent == null 
				|| 
				NewFact.Arguments.Count != NewFact.Parent.ArgumentsCount 
				|| 
				Facts
					.Any(x => 
						x.Parent == NewFact.Parent 
						&& 
						x.StringArguments == NewFact.StringArguments
					)
				) return;

			Facts.Add(NewFact);
			NewFact = new Models.Fact();
		}

		private void OnAddFactAtStatementCommand()
		{
			NewStatement.Predicates.Add(new Models.Fact());
		}

		private void OnAddNewStatementCommand()
		{
			if 
				(
					!NewStatement.Predicates.Any()
					||
					NewStatement.Predicates
						.Any(x => 
							x.Parent == null
							||
							x.Arguments.Count != x.Parent.ArgumentsCount
						)
					|| 
					NewStatement.Result.Parent == null
					||
					NewStatement.Result.Arguments.Count != NewStatement.Result.Parent.ArgumentsCount

				) return;

			Statements.Add(NewStatement);
			NewStatement = new Models.Statement();
		}
	}
}
