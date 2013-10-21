using System;
using JetBrains.ActionManagement;
using JetBrains.Annotations;
using JetBrains.Application.DataContext;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.Services;
using JetBrains.ReSharper.Psi.Transactions;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.TextControl;
using DataConstants = JetBrains.TextControl.DataContext.DataConstants;

namespace ReformatUtils
{
    [ActionHandler("ReformatUtils.ReformatStatementAction")]
    public class ReformatStatementAction : IActionHandler
    {
        public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
        {
            // must be in a text control
            ITextControl textControl = context.GetData(DataConstants.TEXT_CONTROL);
            if (textControl == null)
                return false;
            return true;
        }

        public void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            if (!Update(context, ActionPresentation.Empty, null))
            {
                if (nextExecute == null)
                    return;
                nextExecute();
            }
            else
            {
                ITextControl textControl = context.GetData(DataConstants.TEXT_CONTROL);
                if (textControl == null)
                    return;
                ISolution solution = context.GetData(JetBrains.ProjectModel.DataContext.DataConstants.SOLUTION);

                var elementPointed = TextControlToPsi.GetElementPointedByUser<IStatement>(solution, textControl);
                if (elementPointed != null)
                {
                    FormatSafeWithTransaction(elementPointed);
                }
            }
        }

        private static void FormatSafeWithTransaction([NotNull] ITreeNode node)
        {
            if (node == null) throw new ArgumentNullException("node");
            using (PsiTransactionCookie.CreateAutoCommitCookieWithCachesUpdate(node.GetPsiServices(), "reformat"))
            {
                using (node.CreateWriteLock())
                {
                    node.FormatNode();
                }
            }
        }
    }
}