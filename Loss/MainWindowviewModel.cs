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
