using System.Windows.Forms;

namespace OOP27
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.копіюватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архіваціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розпакуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.вставитиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.відмінитиДіїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиНовийФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1002, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::OOP27.Properties.Resources.icons8_назад_60;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::OOP27.Properties.Resources.icons8_вперед_60;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ForeColor = System.Drawing.SystemColors.Menu;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(154, 425);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.ForeColor = System.Drawing.SystemColors.Menu;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(154, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(655, 425);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(815, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(815, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(815, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(815, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(154, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(614, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DimGray;
            this.textBox2.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox2.Location = new System.Drawing.Point(815, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(954, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "->";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Location = new System.Drawing.Point(774, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "->";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копіюватиToolStripMenuItem,
            this.видалитиToolStripMenuItem,
            this.перейменуватиToolStripMenuItem,
            this.архіваціяToolStripMenuItem,
            this.розпакуванняToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 114);
            // 
            // копіюватиToolStripMenuItem
            // 
            this.копіюватиToolStripMenuItem.Name = "копіюватиToolStripMenuItem";
            this.копіюватиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.копіюватиToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.копіюватиToolStripMenuItem.Text = "Копіювати";
            this.копіюватиToolStripMenuItem.Click += new System.EventHandler(this.копіюватиToolStripMenuItem_Click);
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.видалитиToolStripMenuItem.Text = "Видалити";
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);
            // 
            // перейменуватиToolStripMenuItem
            // 
            this.перейменуватиToolStripMenuItem.Name = "перейменуватиToolStripMenuItem";
            this.перейменуватиToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.перейменуватиToolStripMenuItem.Text = "Перейменувати";
            this.перейменуватиToolStripMenuItem.Click += new System.EventHandler(this.перейменуватиToolStripMenuItem_Click);
            // 
            // архіваціяToolStripMenuItem
            // 
            this.архіваціяToolStripMenuItem.Name = "архіваціяToolStripMenuItem";
            this.архіваціяToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.архіваціяToolStripMenuItem.Text = "Архівація";
            this.архіваціяToolStripMenuItem.Click += new System.EventHandler(this.архіваціяToolStripMenuItem_Click);
            // 
            // розпакуванняToolStripMenuItem
            // 
            this.розпакуванняToolStripMenuItem.Name = "розпакуванняToolStripMenuItem";
            this.розпакуванняToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.розпакуванняToolStripMenuItem.Text = "Розпакування";
            this.розпакуванняToolStripMenuItem.Click += new System.EventHandler(this.розпакуванняToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вставитиToolStripMenuItem1,
            this.відмінитиДіїToolStripMenuItem,
            this.створитиНовийФайлToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(196, 92);
            // 
            // вставитиToolStripMenuItem1
            // 
            this.вставитиToolStripMenuItem1.Name = "вставитиToolStripMenuItem1";
            this.вставитиToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.вставитиToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.вставитиToolStripMenuItem1.Text = "Вставити";
            this.вставитиToolStripMenuItem1.Click += new System.EventHandler(this.вставитиToolStripMenuItem1_Click);
            // 
            // відмінитиДіїToolStripMenuItem
            // 
            this.відмінитиДіїToolStripMenuItem.Name = "відмінитиДіїToolStripMenuItem";
            this.відмінитиДіїToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.відмінитиДіїToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.відмінитиДіїToolStripMenuItem.Text = "Відмінити дії";
            this.відмінитиДіїToolStripMenuItem.Click += new System.EventHandler(this.відмінитиДіїToolStripMenuItem_Click);
            // 
            // створитиНовийФайлToolStripMenuItem
            // 
            this.створитиНовийФайлToolStripMenuItem.Name = "створитиНовийФайлToolStripMenuItem";
            this.створитиНовийФайлToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.створитиНовийФайлToolStripMenuItem.Text = "Створити новий файл";
            this.створитиНовийФайлToolStripMenuItem.Click += new System.EventHandler(this.створитиНовийФайлToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1002, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Провідник";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem копіюватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem архіваціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розпакуванняToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem вставитиToolStripMenuItem1;
        private ToolStripMenuItem відмінитиДіїToolStripMenuItem;
        private ToolStripMenuItem створитиНовийФайлToolStripMenuItem;
    }
}

