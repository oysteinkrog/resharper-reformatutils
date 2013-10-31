using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using ReformatUtils.ContextActions.Base;

namespace ReformatUtils.ContextActions
{
    [ContextAction(Name = "ReformatMethod", Description = Description, Group = "C#")]
    public class ReformatMethod : ReformatTreeNodeContextActionBase<IMethodDeclaration>
    {
        private const string Description = "Reformat method";

        public ReformatMethod(ICSharpContextActionDataProvider provider) : base(provider)
        {
        }

        public override string Text
        {
            get { return Description; }
        }

        protected override ITreeNode GetNodeToFormat(IMethodDeclaration element)
        {
            return element.Body;
        }
    }
}