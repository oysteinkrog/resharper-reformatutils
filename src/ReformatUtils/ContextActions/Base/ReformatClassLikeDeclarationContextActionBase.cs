using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace ReformatUtils.ContextActions.Base
{
    public abstract class ReformatClassLikeDeclarationContextActionBase<T> : ReformatTreeNodeContextActionBase<T>
        where T : class, ITreeNode, IClassLikeDeclaration
    {
        protected ReformatClassLikeDeclarationContextActionBase(
            ICSharpContextActionDataProvider contextActionDataProvider) : base(contextActionDataProvider)
        {
        }

        protected override ITreeNode GetNodeToFormat(T element)
        {
            return element.Body;
        }
    }
}