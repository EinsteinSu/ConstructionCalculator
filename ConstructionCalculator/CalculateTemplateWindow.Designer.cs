namespace ConstructionCalculator
{
    partial class CalculateTemplateWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculateTemplateWindow));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.simpleButtonLoadTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSaveAs = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCalc = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditConstruction = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditCellMapping = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditRiskLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditConstructionValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditBusinessFeature = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemBusinessFeature = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemConstructionValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemRiskLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemCellMapping = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemConstruction = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditConstruction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCellMapping.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditRiskLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditConstructionValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditBusinessFeature.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBusinessFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConstructionValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRiskLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCellMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConstruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.simpleButtonLoadTemplate);
            this.dataLayoutControl1.Controls.Add(this.simpleButtonSaveAs);
            this.dataLayoutControl1.Controls.Add(this.simpleButtonCancel);
            this.dataLayoutControl1.Controls.Add(this.simpleButtonCalc);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEditConstruction);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEditCellMapping);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEditRiskLevel);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEditConstructionValue);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEditBusinessFeature);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(369, 344);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // simpleButtonLoadTemplate
            // 
            this.simpleButtonLoadTemplate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonLoadTemplate.ImageOptions.Image")));
            this.simpleButtonLoadTemplate.Location = new System.Drawing.Point(12, 132);
            this.simpleButtonLoadTemplate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButtonLoadTemplate.Name = "simpleButtonLoadTemplate";
            this.simpleButtonLoadTemplate.Size = new System.Drawing.Size(345, 38);
            this.simpleButtonLoadTemplate.StyleController = this.dataLayoutControl1;
            this.simpleButtonLoadTemplate.TabIndex = 15;
            this.simpleButtonLoadTemplate.Text = "Load Template";
            this.simpleButtonLoadTemplate.Click += new System.EventHandler(this.simpleButtonLoadTemplate_Click);
            // 
            // simpleButtonSaveAs
            // 
            this.simpleButtonSaveAs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSaveAs.ImageOptions.Image")));
            this.simpleButtonSaveAs.Location = new System.Drawing.Point(12, 216);
            this.simpleButtonSaveAs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButtonSaveAs.Name = "simpleButtonSaveAs";
            this.simpleButtonSaveAs.Size = new System.Drawing.Size(345, 38);
            this.simpleButtonSaveAs.StyleController = this.dataLayoutControl1;
            this.simpleButtonSaveAs.TabIndex = 14;
            this.simpleButtonSaveAs.Text = "Save Template As";
            this.simpleButtonSaveAs.Click += new System.EventHandler(this.simpleButtonSaveAs_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(12, 258);
            this.simpleButtonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(345, 38);
            this.simpleButtonCancel.StyleController = this.dataLayoutControl1;
            this.simpleButtonCancel.TabIndex = 13;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonCalc
            // 
            this.simpleButtonCalc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCalc.ImageOptions.Image")));
            this.simpleButtonCalc.Location = new System.Drawing.Point(12, 174);
            this.simpleButtonCalc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButtonCalc.Name = "simpleButtonCalc";
            this.simpleButtonCalc.Size = new System.Drawing.Size(345, 38);
            this.simpleButtonCalc.StyleController = this.dataLayoutControl1;
            this.simpleButtonCalc.TabIndex = 12;
            this.simpleButtonCalc.Text = "Calculate";
            this.simpleButtonCalc.Click += new System.EventHandler(this.simpleButtonCalc_Click);
            // 
            // comboBoxEditConstruction
            // 
            this.comboBoxEditConstruction.Location = new System.Drawing.Point(105, 108);
            this.comboBoxEditConstruction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditConstruction.Name = "comboBoxEditConstruction";
            this.comboBoxEditConstruction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditConstruction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditConstruction.Size = new System.Drawing.Size(252, 20);
            this.comboBoxEditConstruction.StyleController = this.dataLayoutControl1;
            this.comboBoxEditConstruction.TabIndex = 11;
            // 
            // comboBoxEditCellMapping
            // 
            this.comboBoxEditCellMapping.Location = new System.Drawing.Point(105, 84);
            this.comboBoxEditCellMapping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditCellMapping.Name = "comboBoxEditCellMapping";
            this.comboBoxEditCellMapping.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditCellMapping.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditCellMapping.Size = new System.Drawing.Size(252, 20);
            this.comboBoxEditCellMapping.StyleController = this.dataLayoutControl1;
            this.comboBoxEditCellMapping.TabIndex = 10;
            // 
            // comboBoxEditRiskLevel
            // 
            this.comboBoxEditRiskLevel.Location = new System.Drawing.Point(105, 60);
            this.comboBoxEditRiskLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditRiskLevel.Name = "comboBoxEditRiskLevel";
            this.comboBoxEditRiskLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditRiskLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditRiskLevel.Size = new System.Drawing.Size(252, 20);
            this.comboBoxEditRiskLevel.StyleController = this.dataLayoutControl1;
            this.comboBoxEditRiskLevel.TabIndex = 9;
            // 
            // comboBoxEditConstructionValue
            // 
            this.comboBoxEditConstructionValue.Location = new System.Drawing.Point(105, 36);
            this.comboBoxEditConstructionValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditConstructionValue.Name = "comboBoxEditConstructionValue";
            this.comboBoxEditConstructionValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditConstructionValue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditConstructionValue.Size = new System.Drawing.Size(252, 20);
            this.comboBoxEditConstructionValue.StyleController = this.dataLayoutControl1;
            this.comboBoxEditConstructionValue.TabIndex = 8;
            // 
            // comboBoxEditBusinessFeature
            // 
            this.comboBoxEditBusinessFeature.Location = new System.Drawing.Point(105, 12);
            this.comboBoxEditBusinessFeature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditBusinessFeature.Name = "comboBoxEditBusinessFeature";
            this.comboBoxEditBusinessFeature.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditBusinessFeature.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditBusinessFeature.Size = new System.Drawing.Size(252, 20);
            this.comboBoxEditBusinessFeature.StyleController = this.dataLayoutControl1;
            this.comboBoxEditBusinessFeature.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItemBusinessFeature,
            this.layoutControlItemConstructionValue,
            this.layoutControlItemRiskLevel,
            this.layoutControlItemCellMapping,
            this.layoutControlItemConstruction,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(369, 344);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 288);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(349, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemBusinessFeature
            // 
            this.layoutControlItemBusinessFeature.Control = this.comboBoxEditBusinessFeature;
            this.layoutControlItemBusinessFeature.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBusinessFeature.Name = "layoutControlItemBusinessFeature";
            this.layoutControlItemBusinessFeature.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItemBusinessFeature.Text = "Business Feature";
            this.layoutControlItemBusinessFeature.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItemConstructionValue
            // 
            this.layoutControlItemConstructionValue.Control = this.comboBoxEditConstructionValue;
            this.layoutControlItemConstructionValue.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemConstructionValue.Name = "layoutControlItemConstructionValue";
            this.layoutControlItemConstructionValue.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItemConstructionValue.Text = "Construction Value";
            this.layoutControlItemConstructionValue.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItemRiskLevel
            // 
            this.layoutControlItemRiskLevel.Control = this.comboBoxEditRiskLevel;
            this.layoutControlItemRiskLevel.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemRiskLevel.Name = "layoutControlItemRiskLevel";
            this.layoutControlItemRiskLevel.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItemRiskLevel.Text = "Risk Level";
            this.layoutControlItemRiskLevel.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItemCellMapping
            // 
            this.layoutControlItemCellMapping.Control = this.comboBoxEditCellMapping;
            this.layoutControlItemCellMapping.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItemCellMapping.Name = "layoutControlItemCellMapping";
            this.layoutControlItemCellMapping.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItemCellMapping.Text = "Cell Mapping";
            this.layoutControlItemCellMapping.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItemConstruction
            // 
            this.layoutControlItemConstruction.Control = this.comboBoxEditConstruction;
            this.layoutControlItemConstruction.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItemConstruction.Name = "layoutControlItemConstruction";
            this.layoutControlItemConstruction.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItemConstruction.Text = "Construction";
            this.layoutControlItemConstruction.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButtonCalc;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 162);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(349, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 246);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(349, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButtonSaveAs;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 204);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(349, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButtonLoadTemplate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(349, 42);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // CalculateTemplateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(369, 344);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CalculateTemplateWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculation template selection";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditConstruction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCellMapping.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditRiskLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditConstructionValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditBusinessFeature.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBusinessFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConstructionValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRiskLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCellMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConstruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditBusinessFeature;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBusinessFeature;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditConstruction;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditCellMapping;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditRiskLevel;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditConstructionValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemConstructionValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemRiskLevel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCellMapping;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemConstruction;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCalc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveAs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLoadTemplate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}