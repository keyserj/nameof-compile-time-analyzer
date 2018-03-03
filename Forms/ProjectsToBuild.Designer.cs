namespace TestBigProject
{
    partial class ProjectsToBuild
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtProjectPath = new TestBigProject.CueTextBox();
            this.cmdDesignSelected = new System.Windows.Forms.Button();
            this.cmdAddNew = new System.Windows.Forms.Button();
            this.updNumberOfTimesToBuild = new System.Windows.Forms.NumericUpDown();
            this.cmdBuildProjects = new System.Windows.Forms.Button();
            this.lblNumberOfTimesToBuild = new System.Windows.Forms.Label();
            this.lblProjectsToBuild = new System.Windows.Forms.Label();
            this.cmdRemoveSelected = new System.Windows.Forms.Button();
            this.lstProjectsToBuild = new System.Windows.Forms.ListBox();
            this.cmdAddExisting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updNumberOfTimesToBuild)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Cue = "Project Path";
            this.txtProjectPath.Location = new System.Drawing.Point(130, 163);
            this.txtProjectPath.Multiline = true;
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(140, 85);
            this.txtProjectPath.TabIndex = 25;
            // 
            // cmdDesignSelected
            // 
            this.cmdDesignSelected.Location = new System.Drawing.Point(16, 160);
            this.cmdDesignSelected.Name = "cmdDesignSelected";
            this.cmdDesignSelected.Size = new System.Drawing.Size(108, 23);
            this.cmdDesignSelected.TabIndex = 24;
            this.cmdDesignSelected.Text = "Design Selected";
            this.cmdDesignSelected.UseVisualStyleBackColor = true;
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Location = new System.Drawing.Point(16, 73);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(108, 23);
            this.cmdAddNew.TabIndex = 23;
            this.cmdAddNew.Text = "Add New";
            this.cmdAddNew.UseVisualStyleBackColor = true;
            // 
            // updNumberOfTimesToBuild
            // 
            this.updNumberOfTimesToBuild.Location = new System.Drawing.Point(141, 273);
            this.updNumberOfTimesToBuild.Name = "updNumberOfTimesToBuild";
            this.updNumberOfTimesToBuild.Size = new System.Drawing.Size(101, 20);
            this.updNumberOfTimesToBuild.TabIndex = 17;
            // 
            // cmdBuildProjects
            // 
            this.cmdBuildProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuildProjects.Location = new System.Drawing.Point(51, 303);
            this.cmdBuildProjects.Name = "cmdBuildProjects";
            this.cmdBuildProjects.Size = new System.Drawing.Size(191, 54);
            this.cmdBuildProjects.TabIndex = 22;
            this.cmdBuildProjects.Text = "Build Projects";
            this.cmdBuildProjects.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfTimesToBuild
            // 
            this.lblNumberOfTimesToBuild.AutoSize = true;
            this.lblNumberOfTimesToBuild.Location = new System.Drawing.Point(52, 275);
            this.lblNumberOfTimesToBuild.Name = "lblNumberOfTimesToBuild";
            this.lblNumberOfTimesToBuild.Size = new System.Drawing.Size(83, 13);
            this.lblNumberOfTimesToBuild.TabIndex = 16;
            this.lblNumberOfTimesToBuild.Text = "# Times to Build";
            // 
            // lblProjectsToBuild
            // 
            this.lblProjectsToBuild.AutoSize = true;
            this.lblProjectsToBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectsToBuild.Location = new System.Drawing.Point(40, 21);
            this.lblProjectsToBuild.Name = "lblProjectsToBuild";
            this.lblProjectsToBuild.Size = new System.Drawing.Size(210, 31);
            this.lblProjectsToBuild.TabIndex = 21;
            this.lblProjectsToBuild.Text = "Projects to Build";
            // 
            // cmdRemoveSelected
            // 
            this.cmdRemoveSelected.Location = new System.Drawing.Point(16, 131);
            this.cmdRemoveSelected.Name = "cmdRemoveSelected";
            this.cmdRemoveSelected.Size = new System.Drawing.Size(108, 23);
            this.cmdRemoveSelected.TabIndex = 20;
            this.cmdRemoveSelected.Text = "Remove Selected";
            this.cmdRemoveSelected.UseVisualStyleBackColor = true;
            // 
            // lstProjectsToBuild
            // 
            this.lstProjectsToBuild.FormattingEnabled = true;
            this.lstProjectsToBuild.Location = new System.Drawing.Point(130, 72);
            this.lstProjectsToBuild.Name = "lstProjectsToBuild";
            this.lstProjectsToBuild.Size = new System.Drawing.Size(140, 82);
            this.lstProjectsToBuild.TabIndex = 19;
            // 
            // cmdAddExisting
            // 
            this.cmdAddExisting.Location = new System.Drawing.Point(16, 102);
            this.cmdAddExisting.Name = "cmdAddExisting";
            this.cmdAddExisting.Size = new System.Drawing.Size(108, 23);
            this.cmdAddExisting.TabIndex = 18;
            this.cmdAddExisting.Text = "Add Existing";
            this.cmdAddExisting.UseVisualStyleBackColor = true;
            // 
            // ProjectsToBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 381);
            this.Controls.Add(this.txtProjectPath);
            this.Controls.Add(this.cmdDesignSelected);
            this.Controls.Add(this.cmdAddNew);
            this.Controls.Add(this.updNumberOfTimesToBuild);
            this.Controls.Add(this.cmdBuildProjects);
            this.Controls.Add(this.lblNumberOfTimesToBuild);
            this.Controls.Add(this.lblProjectsToBuild);
            this.Controls.Add(this.cmdRemoveSelected);
            this.Controls.Add(this.lstProjectsToBuild);
            this.Controls.Add(this.cmdAddExisting);
            this.Name = "ProjectsToBuild";
            this.Text = "Projects to Build";
            ((System.ComponentModel.ISupportInitialize)(this.updNumberOfTimesToBuild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CueTextBox txtProjectPath;
        private System.Windows.Forms.Button cmdDesignSelected;
        private System.Windows.Forms.Button cmdAddNew;
        private System.Windows.Forms.NumericUpDown updNumberOfTimesToBuild;
        private System.Windows.Forms.Button cmdBuildProjects;
        private System.Windows.Forms.Label lblNumberOfTimesToBuild;
        private System.Windows.Forms.Label lblProjectsToBuild;
        private System.Windows.Forms.Button cmdRemoveSelected;
        private System.Windows.Forms.ListBox lstProjectsToBuild;
        private System.Windows.Forms.Button cmdAddExisting;
    }
}