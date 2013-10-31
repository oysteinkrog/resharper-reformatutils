using JetBrains.ActionManagement;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using ReformatUtils.Actions.Base;

namespace ReformatUtils.Actions
{
    [ActionHandler("ReformatUtils.Actions.ReformatMethodAction")]
    public class ReformatMethodAction : ReformatTreeNodeActionHandlerBase<IMethodDeclaration>
    {
        protected override ITreeNode GetNodeToFormat(IMethodDeclaration element)
        {
            return element.Body;
        }
    }
}