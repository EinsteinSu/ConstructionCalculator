using System;
using DevExpress.XtraBars.FluentDesignSystem;

namespace ConstructionCalculator
{
    public partial class MainView : FluentDesignForm
    {
        public MainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
            fluent.WithEvent<EventArgs>(this, "Load").EventToCommand(x => x.OnLoaded(null), x => x.DefaultModule);
            fluent.BindCommand(accordionControlElementFile, (x, m) => x.Show(m), x => x.Modules[0]);
            fluent.BindCommand(accordionControlElementBV, (x, m) => x.Show(m), x => x.Modules[1]);
            fluent.BindCommand(accordionControlElementBE, (x, m) => x.Show(m), x => x.Modules[2]);
        }
    }
}