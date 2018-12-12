namespace ConstructionCalculator
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.groupFile = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementFile = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.groupBaseParameters = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementBV = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementBE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementCV = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.groupParameters = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementRL = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementCM = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.groupCalc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementcalc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.navigationFrame1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(202, 30);
            this.fluentDesignFormContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(335, 368);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.navigationPage2;
            this.navigationFrame1.Size = new System.Drawing.Size(335, 368);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(335, 368);
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(335, 368);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.groupFile,
            this.groupBaseParameters,
            this.groupParameters,
            this.groupCalc});
            this.accordionControl1.Location = new System.Drawing.Point(0, 30);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(202, 368);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // groupFile
            // 
            this.groupFile.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementFile});
            this.groupFile.Name = "groupFile";
            this.groupFile.Text = "Files";
            // 
            // accordionControlElementFile
            // 
            this.accordionControlElementFile.Name = "accordionControlElementFile";
            this.accordionControlElementFile.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementFile.Text = "File";
            // 
            // groupBaseParameters
            // 
            this.groupBaseParameters.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementBV,
            this.accordionControlElementBE,
            this.accordionControlElementCV});
            this.groupBaseParameters.Expanded = true;
            this.groupBaseParameters.Name = "groupBaseParameters";
            this.groupBaseParameters.Text = "Base Parameters";
            // 
            // accordionControlElementBV
            // 
            this.accordionControlElementBV.Name = "accordionControlElementBV";
            this.accordionControlElementBV.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementBV.Text = "Business Value";
            // 
            // accordionControlElementBE
            // 
            this.accordionControlElementBE.Name = "accordionControlElementBE";
            this.accordionControlElementBE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementBE.Text = "Business Feature";
            // 
            // accordionControlElementCV
            // 
            this.accordionControlElementCV.Name = "accordionControlElementCV";
            this.accordionControlElementCV.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementCV.Text = "Construction Value";
            // 
            // groupParameters
            // 
            this.groupParameters.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementRL,
            this.accordionControlElementCM});
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Text = "Parameters";
            // 
            // accordionControlElementRL
            // 
            this.accordionControlElementRL.Name = "accordionControlElementRL";
            this.accordionControlElementRL.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementRL.Text = "Risk Level";
            // 
            // accordionControlElementCM
            // 
            this.accordionControlElementCM.Name = "accordionControlElementCM";
            this.accordionControlElementCM.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementCM.Text = "Cell Mapping";
            // 
            // groupCalc
            // 
            this.groupCalc.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementcalc});
            this.groupCalc.Name = "groupCalc";
            this.groupCalc.Text = "Construction Calculate";
            // 
            // accordionControlElementcalc
            // 
            this.accordionControlElementcalc.Name = "accordionControlElementcalc";
            this.accordionControlElementcalc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementcalc.Text = "Calculator";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(537, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(null, false, this.navigationFrame1)});
            this.mvvmContext1.ViewModelType = typeof(ConstructionCalculator.MainViewModel);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 398);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainView";
            this.NavigationControl = this.accordionControl1;
            this.Text = "MainView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement groupBaseParameters;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementBV;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementBE;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementCV;
        private DevExpress.XtraBars.Navigation.AccordionControlElement groupParameters;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementRL;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementCM;
        private DevExpress.XtraBars.Navigation.AccordionControlElement groupCalc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementcalc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement groupFile;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementFile;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
    }
}

