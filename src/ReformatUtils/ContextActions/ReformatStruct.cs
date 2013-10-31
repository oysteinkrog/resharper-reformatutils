using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using ReformatUtils.ContextActions.Base;

namespace ReformatUtils.ContextActions
{
    [ContextAction(Name = "ReformatStruct", Description = Description, Group = "C#")]
    public class ReformatStruct : ReformatTreeNodeContextActionBase<IStructDeclaration>
    {
        private const string Description = "Reformat struct";

        public ReformatStruct(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        public override string Text
        {
            get { return Description; }
        }

        protected override ITreeNode GetNodeToFormat(IStructDeclaration element)
        {
            return element.Body;
        }
    }
}