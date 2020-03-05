namespace esoft
{
    partial class executer_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.task_list_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // task_list_button
            // 
            this.task_list_button.Location = new System.Drawing.Point(370, 200);
            this.task_list_button.Name = "task_list_button";
            this.task_list_button.Size = new System.Drawing.Size(372, 64);
            this.task_list_button.TabIndex = 0;
            this.task_list_button.Text = "Список задач";
            this.task_list_button.UseVisualStyleBackColor = true;
            this.task_list_button.Click += new System.EventHandler(this.task_list_button_Click);
            // 
            // executer_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 517);
            this.Controls.Add(this.task_list_button);
            this.Name = "executer_main";
            this.Text = "executer_main";
            this.Load += new System.EventHandler(this.executer_main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button task_list_button;
    }
}