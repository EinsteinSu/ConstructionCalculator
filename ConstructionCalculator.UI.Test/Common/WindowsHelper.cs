using System.Windows;

namespace ConstructionCalculator.UI.Test.Common
{
    public static class WindowsHelper
    {
        public static bool GetShowDialog(this Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.WindowStyle = WindowStyle.ToolWindow;
            var result = window.ShowDialog();
            if (result.HasValue && result.Value) return true;

            return false;
        }
    }
}