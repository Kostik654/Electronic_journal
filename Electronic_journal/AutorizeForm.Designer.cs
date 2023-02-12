namespace Electronic_journal
{
    partial class AutorizeForm
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.isStudent_box = new System.Windows.Forms.CheckBox();
            this.login_box = new System.Windows.Forms.TextBox();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.enter_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "АВТОРИЗАЦИЯ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // isStudent_box
            // 
            this.isStudent_box.AutoSize = true;
            this.isStudent_box.Checked = true;
            this.isStudent_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isStudent_box.Location = new System.Drawing.Point(13, 168);
            this.isStudent_box.Name = "isStudent_box";
            this.isStudent_box.Size = new System.Drawing.Size(84, 20);
            this.isStudent_box.TabIndex = 3;
            this.isStudent_box.Text = "Студент";
            this.isStudent_box.UseVisualStyleBackColor = true;
            // 
            // login_box
            // 
            this.login_box.Location = new System.Drawing.Point(13, 94);
            this.login_box.Name = "login_box";
            this.login_box.Size = new System.Drawing.Size(286, 22);
            this.login_box.TabIndex = 4;
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(13, 140);
            this.pass_box.Name = "pass_box";
            this.pass_box.Size = new System.Drawing.Size(286, 22);
            this.pass_box.TabIndex = 5;
            // 
            // enter_button
            // 
            this.enter_button.Location = new System.Drawing.Point(13, 194);
            this.enter_button.Name = "enter_button";
            this.enter_button.Size = new System.Drawing.Size(286, 49);
            this.enter_button.TabIndex = 6;
            this.enter_button.Text = "Войти";
            this.enter_button.UseVisualStyleBackColor = true;
            this.enter_button.Click += new System.EventHandler(this.enter_button_Click);
            // 
            // AutorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enter_button);
            this.Controls.Add(this.pass_box);
            this.Controls.Add(this.login_box);
            this.Controls.Add(this.isStudent_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AutorizeForm";
            this.Size = new System.Drawing.Size(312, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isStudent_box;
        private System.Windows.Forms.TextBox login_box;
        private System.Windows.Forms.TextBox pass_box;
        public System.Windows.Forms.Button enter_button;
    }
}
