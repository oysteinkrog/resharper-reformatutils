using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using ReformatUtils.ContextActions.Base;

namespace ReformatUtils.ContextActions
{
    [ContextAction(Name = "ReformatInterface", Description = DescriptionText, Group = "C#")]
    public class ReformatInterface : ReformatClassLikeDeclarationContextActionBase<IInterfaceDeclaration>
    {
        private const string DescriptionText = "Reformat interface";

        public ReformatInterface(ICSharpContextActionDataProvider contextActionDataProvider)
            : base(contextActionDataProvider)
        {
        }

        public override string Text
        {
            get { return DescriptionText; }
        }
    }
}