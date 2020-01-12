/*
 * Сделано в SharpDevelop.
 * Дата: 04.11.2018
 * Время: 01:21
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace PropositionalLogic
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtPredicateName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAddPredicate = new System.Windows.Forms.Button();
			this.flpPredicates = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbPredicates = new System.Windows.Forms.ComboBox();
			this.btnAddPredicateToStatement = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTekStatement = new System.Windows.Forms.TextBox();
			this.btnAddStatement = new System.Windows.Forms.Button();
			this.flpStatements = new System.Windows.Forms.FlowLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPredicateArg1 = new System.Windows.Forms.TextBox();
			this.txtPredicateArg2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbResStatementName = new System.Windows.Forms.ComboBox();
			this.txtResStatementArg1 = new System.Windows.Forms.TextBox();
			this.txtResStatementArg2 = new System.Windows.Forms.TextBox();
			this.txtFactArg2 = new System.Windows.Forms.TextBox();
			this.txtFactArg1 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnAddFact = new System.Windows.Forms.Button();
			this.cmbFactName = new System.Windows.Forms.ComboBox();
			this.flpFactsOld = new System.Windows.Forms.FlowLayoutPanel();
			this.flpFactsNew = new System.Windows.Forms.FlowLayoutPanel();
			this.btnNewFacts = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.clear = new System.Windows.Forms.ToolStripMenuItem();
			this.OFD = new System.Windows.Forms.OpenFileDialog();
			this.rchConsole = new System.Windows.Forms.RichTextBox();
			this.SFD = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPredicateName
			// 
			this.txtPredicateName.Location = new System.Drawing.Point(84, 26);
			this.txtPredicateName.Name = "txtPredicateName";
			this.txtPredicateName.Size = new System.Drawing.Size(72, 20);
			this.txtPredicateName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(2, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Нов. пред.:";
			// 
			// btnAddPredicate
			// 
			this.btnAddPredicate.Location = new System.Drawing.Point(162, 28);
			this.btnAddPredicate.Name = "btnAddPredicate";
			this.btnAddPredicate.Size = new System.Drawing.Size(22, 20);
			this.btnAddPredicate.TabIndex = 3;
			this.btnAddPredicate.Text = "✓";
			this.btnAddPredicate.UseVisualStyleBackColor = true;
			this.btnAddPredicate.Click += new System.EventHandler(this.BtnAddPredicateClick);
			// 
			// flpPredicates
			// 
			this.flpPredicates.AutoScroll = true;
			this.flpPredicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPredicates.Location = new System.Drawing.Point(2, 71);
			this.flpPredicates.Name = "flpPredicates";
			this.flpPredicates.Size = new System.Drawing.Size(182, 378);
			this.flpPredicates.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(2, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(182, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "Предикаты:";
			// 
			// cmbPredicates
			// 
			this.cmbPredicates.FormattingEnabled = true;
			this.cmbPredicates.Location = new System.Drawing.Point(316, 24);
			this.cmbPredicates.Name = "cmbPredicates";
			this.cmbPredicates.Size = new System.Drawing.Size(83, 21);
			this.cmbPredicates.TabIndex = 6;
			// 
			// btnAddPredicateToStatement
			// 
			this.btnAddPredicateToStatement.Location = new System.Drawing.Point(437, 24);
			this.btnAddPredicateToStatement.Name = "btnAddPredicateToStatement";
			this.btnAddPredicateToStatement.Size = new System.Drawing.Size(22, 21);
			this.btnAddPredicateToStatement.TabIndex = 7;
			this.btnAddPredicateToStatement.Text = "✓";
			this.btnAddPredicateToStatement.UseVisualStyleBackColor = true;
			this.btnAddPredicateToStatement.Click += new System.EventHandler(this.BtnAddPredicateToStatementClick);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(190, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Предикат:";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(190, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 19);
			this.label5.TabIndex = 9;
			this.label5.Text = "Тек. выск-е:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTekStatement
			// 
			this.txtTekStatement.Location = new System.Drawing.Point(284, 50);
			this.txtTekStatement.Name = "txtTekStatement";
			this.txtTekStatement.ReadOnly = true;
			this.txtTekStatement.Size = new System.Drawing.Size(147, 20);
			this.txtTekStatement.TabIndex = 10;
			// 
			// btnAddStatement
			// 
			this.btnAddStatement.Location = new System.Drawing.Point(437, 77);
			this.btnAddStatement.Name = "btnAddStatement";
			this.btnAddStatement.Size = new System.Drawing.Size(22, 20);
			this.btnAddStatement.TabIndex = 11;
			this.btnAddStatement.Text = "✓";
			this.btnAddStatement.UseVisualStyleBackColor = true;
			this.btnAddStatement.Click += new System.EventHandler(this.BtnAddStatementClick);
			// 
			// flpStatements
			// 
			this.flpStatements.AutoScroll = true;
			this.flpStatements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpStatements.Location = new System.Drawing.Point(190, 122);
			this.flpStatements.Margin = new System.Windows.Forms.Padding(0);
			this.flpStatements.Name = "flpStatements";
			this.flpStatements.Size = new System.Drawing.Size(482, 326);
			this.flpStatements.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(190, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 23);
			this.label6.TabIndex = 13;
			this.label6.Text = "Высказывания:";
			// 
			// txtPredicateArg1
			// 
			this.txtPredicateArg1.Location = new System.Drawing.Point(284, 25);
			this.txtPredicateArg1.Name = "txtPredicateArg1";
			this.txtPredicateArg1.Size = new System.Drawing.Size(26, 20);
			this.txtPredicateArg1.TabIndex = 14;
			this.txtPredicateArg1.Text = "x";
			// 
			// txtPredicateArg2
			// 
			this.txtPredicateArg2.Location = new System.Drawing.Point(405, 24);
			this.txtPredicateArg2.Name = "txtPredicateArg2";
			this.txtPredicateArg2.Size = new System.Drawing.Size(26, 20);
			this.txtPredicateArg2.TabIndex = 15;
			this.txtPredicateArg2.Text = "y";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(190, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 19);
			this.label2.TabIndex = 16;
			this.label2.Text = "Результат:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbResStatementName
			// 
			this.cmbResStatementName.FormattingEnabled = true;
			this.cmbResStatementName.Location = new System.Drawing.Point(316, 75);
			this.cmbResStatementName.Name = "cmbResStatementName";
			this.cmbResStatementName.Size = new System.Drawing.Size(83, 21);
			this.cmbResStatementName.TabIndex = 17;
			// 
			// txtResStatementArg1
			// 
			this.txtResStatementArg1.Location = new System.Drawing.Point(284, 76);
			this.txtResStatementArg1.Name = "txtResStatementArg1";
			this.txtResStatementArg1.Size = new System.Drawing.Size(26, 20);
			this.txtResStatementArg1.TabIndex = 18;
			this.txtResStatementArg1.Text = "x";
			// 
			// txtResStatementArg2
			// 
			this.txtResStatementArg2.Location = new System.Drawing.Point(405, 77);
			this.txtResStatementArg2.Name = "txtResStatementArg2";
			this.txtResStatementArg2.Size = new System.Drawing.Size(26, 20);
			this.txtResStatementArg2.TabIndex = 19;
			this.txtResStatementArg2.Text = "y";
			// 
			// txtFactArg2
			// 
			this.txtFactArg2.Location = new System.Drawing.Point(952, 24);
			this.txtFactArg2.Name = "txtFactArg2";
			this.txtFactArg2.Size = new System.Drawing.Size(90, 20);
			this.txtFactArg2.TabIndex = 24;
			// 
			// txtFactArg1
			// 
			this.txtFactArg1.Location = new System.Drawing.Point(727, 24);
			this.txtFactArg1.Name = "txtFactArg1";
			this.txtFactArg1.Size = new System.Drawing.Size(84, 20);
			this.txtFactArg1.TabIndex = 23;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(676, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 19);
			this.label7.TabIndex = 22;
			this.label7.Text = "Факт:";
			// 
			// btnAddFact
			// 
			this.btnAddFact.Location = new System.Drawing.Point(1048, 23);
			this.btnAddFact.Name = "btnAddFact";
			this.btnAddFact.Size = new System.Drawing.Size(24, 23);
			this.btnAddFact.TabIndex = 21;
			this.btnAddFact.Text = "✓";
			this.btnAddFact.UseVisualStyleBackColor = true;
			this.btnAddFact.Click += new System.EventHandler(this.BtnAddFactClick);
			// 
			// cmbFactName
			// 
			this.cmbFactName.FormattingEnabled = true;
			this.cmbFactName.Location = new System.Drawing.Point(817, 23);
			this.cmbFactName.Name = "cmbFactName";
			this.cmbFactName.Size = new System.Drawing.Size(129, 21);
			this.cmbFactName.TabIndex = 20;
			// 
			// flpFactsOld
			// 
			this.flpFactsOld.AutoScroll = true;
			this.flpFactsOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpFactsOld.Location = new System.Drawing.Point(678, 50);
			this.flpFactsOld.Name = "flpFactsOld";
			this.flpFactsOld.Size = new System.Drawing.Size(394, 191);
			this.flpFactsOld.TabIndex = 25;
			// 
			// flpFactsNew
			// 
			this.flpFactsNew.AutoScroll = true;
			this.flpFactsNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpFactsNew.Location = new System.Drawing.Point(678, 247);
			this.flpFactsNew.Name = "flpFactsNew";
			this.flpFactsNew.Size = new System.Drawing.Size(394, 201);
			this.flpFactsNew.TabIndex = 26;
			// 
			// btnNewFacts
			// 
			this.btnNewFacts.Location = new System.Drawing.Point(478, 27);
			this.btnNewFacts.Name = "btnNewFacts";
			this.btnNewFacts.Size = new System.Drawing.Size(194, 70);
			this.btnNewFacts.TabIndex = 27;
			this.btnNewFacts.Text = "клик";
			this.btnNewFacts.UseVisualStyleBackColor = true;
			this.btnNewFacts.Click += new System.EventHandler(this.BtnNewFactsClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(437, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(22, 23);
			this.button1.TabIndex = 28;
			this.button1.Text = "X";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.файлToolStripMenuItem,
									this.clear});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1340, 24);
			this.menuStrip1.TabIndex = 30;
			this.menuStrip1.Text = "Файл";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.FileOpen,
									this.FileSave});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// FileOpen
			// 
			this.FileOpen.Name = "FileOpen";
			this.FileOpen.Size = new System.Drawing.Size(132, 22);
			this.FileOpen.Text = "Открыть";
			this.FileOpen.Click += new System.EventHandler(this.FileOpenClick);
			// 
			// FileSave
			// 
			this.FileSave.Name = "FileSave";
			this.FileSave.Size = new System.Drawing.Size(132, 22);
			this.FileSave.Text = "Сохранить";
			this.FileSave.Click += new System.EventHandler(this.FileSaveClick);
			// 
			// clear
			// 
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(71, 20);
			this.clear.Text = "Очистить";
			this.clear.Click += new System.EventHandler(this.ClearClick);
			// 
			// OFD
			// 
			this.OFD.InitialDirectory = "./";
			// 
			// rchConsole
			// 
			this.rchConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rchConsole.Location = new System.Drawing.Point(1078, 27);
			this.rchConsole.Name = "rchConsole";
			this.rchConsole.ReadOnly = true;
			this.rchConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
			this.rchConsole.Size = new System.Drawing.Size(262, 421);
			this.rchConsole.TabIndex = 31;
			this.rchConsole.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1340, 452);
			this.Controls.Add(this.rchConsole);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnNewFacts);
			this.Controls.Add(this.flpFactsNew);
			this.Controls.Add(this.flpFactsOld);
			this.Controls.Add(this.txtFactArg2);
			this.Controls.Add(this.txtFactArg1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnAddFact);
			this.Controls.Add(this.cmbFactName);
			this.Controls.Add(this.txtResStatementArg2);
			this.Controls.Add(this.txtResStatementArg1);
			this.Controls.Add(this.cmbResStatementName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPredicateArg2);
			this.Controls.Add(this.txtPredicateArg1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.flpStatements);
			this.Controls.Add(this.btnAddStatement);
			this.Controls.Add(this.txtTekStatement);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnAddPredicateToStatement);
			this.Controls.Add(this.cmbPredicates);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.flpPredicates);
			this.Controls.Add(this.btnAddPredicate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPredicateName);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "propositionalLogic";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog SFD;
		private System.Windows.Forms.RichTextBox rchConsole;
		private System.Windows.Forms.ToolStripMenuItem clear;
		private System.Windows.Forms.OpenFileDialog OFD;
		private System.Windows.Forms.ToolStripMenuItem FileSave;
		private System.Windows.Forms.ToolStripMenuItem FileOpen;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnNewFacts;
		private System.Windows.Forms.FlowLayoutPanel flpFactsNew;
		private System.Windows.Forms.FlowLayoutPanel flpFactsOld;
		private System.Windows.Forms.ComboBox cmbFactName;
		private System.Windows.Forms.Button btnAddFact;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtFactArg1;
		private System.Windows.Forms.TextBox txtFactArg2;
		private System.Windows.Forms.TextBox txtResStatementArg2;
		private System.Windows.Forms.TextBox txtResStatementArg1;
		private System.Windows.Forms.ComboBox cmbResStatementName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPredicateArg2;
		private System.Windows.Forms.TextBox txtPredicateArg1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.FlowLayoutPanel flpStatements;
		private System.Windows.Forms.Button btnAddStatement;
		private System.Windows.Forms.TextBox txtTekStatement;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnAddPredicateToStatement;
		private System.Windows.Forms.ComboBox cmbPredicates;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel flpPredicates;
		private System.Windows.Forms.Button btnAddPredicate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPredicateName;
	}
}
