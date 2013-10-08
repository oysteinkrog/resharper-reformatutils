using System.Windows.Forms;
using JetBrains.ActionManagement;
using JetBrains.Application.DataContext;

namespace resharper_reformatutils
{
    [ActionHandler("resharper-reformatutils.About")]
    public class AboutAction : IActionHandler
    {
        public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
        {
            // return true or false to enable/disable this action
            return true;
        }

        public void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            MessageBox.Show(
                "Reformatting Utilities\nØystein Krog\n\nA resharper plugin that provides actions and shortcuts for reformatting based on scope (e.g. reformat method)",
                "About Reformatting Utilities",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}