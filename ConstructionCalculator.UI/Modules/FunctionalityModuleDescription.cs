using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.ViewModel;

namespace ConstructionCalculator.Modules
{
    public class FunctionalityModuleDescription : ModuleDescription<FunctionalityModuleDescription>
    {
        public FunctionalityModuleDescription(string title, string documentType, string @group, Func<FunctionalityModuleDescription, object> peekCollectionViewModelFactory = null) : base(title, documentType, @group, peekCollectionViewModelFactory)
        {
        }
    }
}
