namespace MergePDF
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DropPanel = new System.Windows.Forms.Panel();
            this.DropImage = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FileList = new System.Windows.Forms.ListView();
            this.listHeaderNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listHeaderFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnMerge = new System.Windows.Forms.Button();
            this.DropPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DropImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DropPanel
            // 
            this.DropPanel.AllowDrop = true;
            this.DropPanel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.DropPanel, "DropPanel");
            this.DropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DropPanel.Controls.Add(this.DropImage);
            this.DropPanel.Name = "DropPanel";
            this.DropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.evDragPanelDrop);
            this.DropPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.evDragPanelEnter);
            this.DropPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.evDragPanelOver);
            this.DropPanel.DragLeave += new System.EventHandler(this.evDragPanelLeave);
            // 
            // DropImage
            // 
            resources.ApplyResources(this.DropImage, "DropImage");
            this.DropImage.Name = "DropImage";
            this.DropImage.TabStop = false;
            // 
            // FileList
            // 
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listHeaderNum,
            this.listHeaderFilename});
            this.FileList.HideSelection = false;
            resources.ApplyResources(this.FileList, "FileList");
            this.FileList.Name = "FileList";
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            // 
            // listHeaderNum
            // 
            resources.ApplyResources(this.listHeaderNum, "listHeaderNum");
            // 
            // listHeaderFilename
            // 
            resources.ApplyResources(this.listHeaderFilename, "listHeaderFilename");
            // 
            // btnUp
            // 
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.Name = "btnDown";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnDelete, "BtnDelete");
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnMerge
            // 
            this.BtnMerge.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.BtnMerge, "BtnMerge");
            this.BtnMerge.Name = "BtnMerge";
            this.BtnMerge.UseVisualStyleBackColor = true;
            this.BtnMerge.Click += new System.EventHandler(this.BtnMerge_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnMerge);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.DropPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.DropPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DropImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel DropPanel;
        private System.Windows.Forms.PictureBox DropImage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.ColumnHeader listHeaderNum;
        private System.Windows.Forms.ColumnHeader listHeaderFilename;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnMerge;
    }
}

