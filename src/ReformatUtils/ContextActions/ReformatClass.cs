using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using ReformatUtils.ContextActions.Base;

namespace ReformatUtils.ContextActions
{
    [ContextAction(Name = "ReformatClass", Description = Description, Group = "C#")]
    public class ReformatClass : ReformatClassLikeDeclarationContextActionBase<IClassDeclaration>
    {
        private const string Description = "Reformat class";

        public ReformatClass(ICSharpContextActionDataProvider contextActionDataProvider)
            : base(contextActionDataProvider)
        {
        }

        public override string Text
        {
            get { return Description; }
        }
    }
}