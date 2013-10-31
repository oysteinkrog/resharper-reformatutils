using JetBrains.ActionManagement;
using JetBrains.ReSharper.Psi.Tree;
using ReformatUtils.Actions.Base;

namespace ReformatUtils.Actions
{
    [ActionHandler("ReformatUtils.Actions.ReformatStatementAction")]
    public class ReformatStatementAction : ReformatTreeNodeActionHandlerBase<IStatement>
    {
        protected override ITreeNode GetNodeToFormat(IStatement element)
        {
            return element;
        }
    }
}