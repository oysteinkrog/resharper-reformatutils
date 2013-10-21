using System;
using JetBrains.ActionManagement;
using JetBrains.Annotations;
using JetBrains.Application.DataContext;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Services;
using JetBrains.ReSharper.Psi.Transactions;
using JetBrains.ReSharper.Psi.Tree;

namespace ReformatUtils
{
    [ActionHandler("ReformatUtils.ReformatMethodAction")]
    public class ReformatMethodAction : IActionHandler
    {
        public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
        {
            // must be in a text control
            var textControl = context.GetData(JetBrains.TextControl.DataContext.DataConstants.TEXT_CONTROL);
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
                var textControl = context.GetData(JetBrains.TextControl.DataContext.DataConstants.TEXT_CONTROL);
                if (textControl == null)
                    return;
                var solution = context.GetData(JetBrains.ProjectModel.DataContext.DataConstants.SOLUTION);

                // WORKS
                var elementPointed = TextControlToPsi.GetElementPointedByUser<IMethodDeclaration>(solution, textControl);
                if (elementPointed != null)
                {
                    FormatSafeWithTransaction(elementPointed.Body);
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