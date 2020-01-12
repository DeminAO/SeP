using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PropositionalLogic
{

	public partial class MainForm : Form
	{
		public List<Predicate> Predicates { get; set; }
		public List<Statement> Statements { get; set; }
		public List<Predicate> FactsAll { get; set; }
		public List<Predicate> FactsNew { get; set; }
		public Statement Statement { get; set; }

		public MainForm()
		{
			InitializeComponent();

			Predicates = new List<Predicate>();
			Statements = new List<Statement>();
			FactsAll = new List<Predicate>();
			FactsNew = new List<Predicate>();
			Statement = new Statement();

		}

		/// <summary> Клик для добавления нового предиката </summary>
		private void BtnAddPredicateClick(object sender, EventArgs e)
		{
			string predicateName = txtPredicateName.Text;
			if (predicateName == "") return;

			txtPredicateName.Text = "";
			
			if (Predicates.ContainsAtName(predicateName))
			{
				MessageBox.Show("Предикат уже существует");
			}
			else
			{
				Predicates.Add(new Predicate(predicateName));
				UpdateCtrlsPredicates();
			}
		}

		/// <summary> Обновление элементов на форме, показывающих список предикатов </summary>
		public void UpdateCtrlsPredicates()
		{
			flpPredicates.Controls.Clear();
			cmbPredicates.Items.Clear();
			cmbResStatementName.Items.Clear();
			cmbFactName.Items.Clear();

			foreach (Predicate p in Predicates)
			{
				Label l = new Label
				{
					Font = new Font(FontFamily.GenericSansSerif, (float)10, FontStyle.Italic),
					Width = flpPredicates.Width - 10,
					Height = 20,
					Text = p.ToString()
				};

				flpPredicates.Controls.Add(l);
				cmbPredicates.Items.Add(p.Name);
				cmbResStatementName.Items.Add(p.Name);
				cmbFactName.Items.Add(p.Name);
			}
		}

		/// <summary> Обновление элементов на форме, показывающих список фактов поля</summary>
		public void UpdateFacts(FlowLayoutPanel flp, List<Predicate> facts)
		{
			flp.Controls.Clear();

			foreach (Predicate fact in facts)
			{
				Label l = new Label
				{
					Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic),
					Width = flp.Width - 10,
					Height = 20,
					Text = fact.ToString()
				};

				flp.Controls.Add(l);
			}
		}

		/// <summary> Обновление элементов на форме, показывающих список высказываний </summary>
		public void UpdateFlpStatementes()
		{
			flpStatements.Controls.Clear();

			foreach (Statement s in Statements)
			{
				TextBox l = new TextBox
				{
					ReadOnly = true,
					Font = new Font(FontFamily.GenericSansSerif, (float)10, FontStyle.Italic),
					Width = flpStatements.Width - 10,
					Height = 20,
					Text = s.ToString()
				};

				flpStatements.Controls.Add(l);
			}
		}

		/// <summary> Клик для добавления предиката в высказывание </summary>
		void BtnAddPredicateToStatementClick(object sender, EventArgs e)
		{
			string predicateName = cmbPredicates.Text;
			string arg1 = txtPredicateArg1.Text;
			string arg2 = txtPredicateArg2.Text;

			if (predicateName == "")
			{
				WriteInfoToConsole("Имя предиката не должно быть путым");
			}
			else if (Predicates.ContainsAtName(predicateName))
			{
				WriteInfoToConsole("Предикат не существует");
			}
			else if ((arg1 == "") || (arg2 == ""))
			{
				WriteInfoToConsole("Аргументы не могут быть пустыми");
			}
			else
			{
				var newPredicate = new Predicate(predicateName, arg1, arg2);

				Statement.Add(newPredicate);
				txtTekStatement.Text = Statement.ToString();
				cmbPredicates.Text = "";

			}

			txtPredicateArg1.Text = "x";
			txtPredicateArg2.Text = "y";
		}

		/// <summary> Клик для добавления нового высказывания </summary>
		void BtnAddStatementClick(object sender, EventArgs e)
		{
			string predicateName = cmbResStatementName.Text;
			string arg1 = txtResStatementArg1.Text;
			string arg2 = txtResStatementArg2.Text;
			Predicate res = new Predicate(predicateName, arg1, arg2);

			if (Statement.Predicates.Count == 0)
			{
				WriteInfoToConsole("Высказывание не может быть пустым");
			}
			else if (Statements.HasStatement(Statement))
			{
				WriteInfoToConsole("Высказывание уже существует");

				// Statement = new Statement();
				// txtTekStatement.Text = "";
			}
			else if (predicateName == "")
			{
				WriteInfoToConsole("Предикат результата не может быть пустым");
				return;
			}
			else if (!Predicates.ContainsAtName(res))
			{
				WriteInfoToConsole("Результирующий предикат не существует");
				return;
			}
			else if ((arg1 == "") || (arg2 == ""))
			{
				WriteInfoToConsole("Аргументы не могут быть пустыми");
				return;
			}
			else if (!Statement.ContainsAllPropPredicate(res))
			{
				WriteInfoToConsole("Агрументы результата не используются в высказывании");
				return;
			}
			else
			{
				Statement.SetResult(res);
				Statements.Add(Statement);
				WriteInfoToConsole("Высказывание " + res + " добавлено");
				Statement = new Statement();
				txtTekStatement.Text = "";
			}

			cmbResStatementName.Text = "";
			txtResStatementArg1.Text = "x";
			txtResStatementArg2.Text = "y";

			UpdateFlpStatementes();
		}

		/// <summary> Добавляет новый факт </summary>
		void BtnAddFactClick(object sender, EventArgs e)
		{
			string arg1 = txtFactArg1.Text;
			string arg2 = txtFactArg2.Text;
			string name = cmbFactName.Text;

			if ((arg1 == "") || (arg2 == "") || (name == ""))
			{
				WriteInfoToConsole("Заполнены не все поля");
				return;
			}

			if (!Predicates.ContainsAtName(name))
			{
				WriteInfoToConsole("Имя предиката неизвестно");
				return;
			}

			Predicate p = new Predicate(name, arg1, arg2);
			if (FactsAll.ContainsAtAllProp(p))
			{
				WriteInfoToConsole("Факт " + p + " уже существует");
				return;
			}

			FactsAll.Add(p);
			WriteInfoToConsole("Факт " + p + " добавлен");
			UpdateFacts(flpFactsOld, FactsAll);

		}

		/// <summary> Производит поиск и добавление новых фактов </summary>
		void BtnNewFactsClick(object sender, EventArgs e)
		{
			((Control)sender).Enabled = false;
			rchConsole.Clear();

			bool wasChanged = true;

			while (wasChanged)
			{
				wasChanged = false;
				WriteInfoToConsole("\n\n-----------------------------------------------------------\n");

				foreach (Statement st in Statements)
				{
					WriteInfoToConsole(st.ToString());

					// аргументы высказывания. Так же - заголовок таблицы
					List<string> argsSt = new List<string>();
					foreach (Predicate pr in st.Predicates)
					{
						string arg1 = pr.Arg1;
						string arg2 = pr.Arg2;

						if (!argsSt.Contains(arg1)) argsSt.Add(arg1);
						if (!argsSt.Contains(arg2)) argsSt.Add(arg2);
					}



					List<List<string>> tbl = new List<List<string>>();
					foreach (Predicate p in st.Predicates)
					{

						List<Predicate> lstFacts = FactsAll.Copy(p.Name);
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
								foreach (Predicate row2 in lstFacts)
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
										WriteInfoToConsole("\t\traw creates from: " + row2.ToString());
									}
								}
							}
							tbl = tbl0;
						}

					}

					foreach (List<string> row in tbl)
					{
						string tmpr = "\t" + string.Join("  ", row);
						
						int indResArg1 = argsSt.IndexOf(st.Result.Arg1);
						int indResArg2 = argsSt.IndexOf(st.Result.Arg2);
						Predicate factNew = new Predicate(st.Result.Name, row[indResArg1], row[indResArg2]);

						WriteInfoToConsole(tmpr + " -> " + factNew.ToString());

						if (!FactsAll.ContainsAtAllProp(factNew))
						{
							FactsAll.Add(factNew);
							FactsNew.Add(factNew);
							wasChanged = true;

							WriteInfoToConsole("\t Добавлен");
						}
					}
				}
			}

			UpdateFacts(flpFactsNew, FactsNew);
			((Control)sender).Enabled = true;
		}

		/// <summary> очищает текущее заполняемое высказывание </summary>
		void Button1Click(object sender, EventArgs e)
		{
			Statement.Clear();
			txtTekStatement.Text = "";
		}

		/// <summary> Очищает все поля и списки </summary>
		void ClearAll()
		{

			txtFactArg1.Text = "";
			txtFactArg2.Text = "";
			txtPredicateArg1.Text = "x";
			txtPredicateArg2.Text = "y";
			txtPredicateName.Text = "";
			txtResStatementArg1.Text = "x";
			txtResStatementArg2.Text = "y";
			txtTekStatement.Text = "";

			flpFactsNew.Controls.Clear();
			flpFactsOld.Controls.Clear();
			flpPredicates.Controls.Clear();
			flpStatements.Controls.Clear();

			cmbFactName.Items.Clear();
			cmbPredicates.Items.Clear();
			cmbResStatementName.Items.Clear();

			Predicates.Clear();
			FactsAll.Clear();
			FactsNew.Clear();
			Statements.Clear();
			Statement.Clear();
		}

		/// <summary> Вызывает метод очистки </summary>
		void ClearClick(object sender, EventArgs e) => ClearAll();

		/// <summary>
		/// Открывает файл и считывает из него данные
		/// о предикатах, фактах и высказываниях
		/// </summary>
		void FileOpenClick(object sender, EventArgs e)
		{
			List<string> keyWords = new List<string>
			{
				"predicates:",
				"statements:",
				"facts:"
			};

			ClearAll();
			if (OFD.ShowDialog() != DialogResult.OK) return;
			StreamReader sr = new StreamReader(OFD.OpenFile());
			var keyWord = "predicates:";
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				line = line.Replace('\t', ' ');
				line = line.Trim();

				if (keyWords.Contains(line))
				{
					keyWord = line;
					continue;
				}

				switch (keyWord)
				{
					case "predicates:":
						Predicates.Add(Predicate.FromString(line));
						break;
					case "statements:":
						Statements.Add(Statement.FromString(line));
						break;
					case "facts:":
						FactsAll.Add(Predicate.FromString(line));
						break;
				}

			}
			sr.Close();
			WriteInfoToConsole("Файл загружен");

			UpdateCtrlsPredicates();
			UpdateFacts(flpFactsOld, FactsAll);
			UpdateFlpStatementes();
		}

		/// <summary> Сохраняет все данные в файл </summary>
		void FileSaveClick(object sender, EventArgs e)
		{
			if (SFD.ShowDialog() != DialogResult.OK) return;
			StreamWriter sw = new StreamWriter(SFD.OpenFile());

			sw.WriteLine("predicates:");
			foreach (Predicate p in Predicates)
				sw.WriteLine(p.ToString());

			sw.WriteLine("facts:");
			foreach (Predicate f in FactsAll)
				sw.WriteLine(f.ToString());

			sw.WriteLine("statements:");
			foreach (Statement s in Statements)
				sw.WriteLine(s.ToString());
			sw.Close();

			WriteInfoToConsole("Файл сохранен");
		}


		/// <summary> Выводит сообщение на консоль </summary>
		/// <param name="msg"> Сообщение </param>
		void WriteInfoToConsole(string msg) => rchConsole.Text += msg + "\n";
	}
}
