using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.TextControl;
using JetBrains.Util;

namespace ReformatUtils
{
    [ContextAction(Name = "ReformatClass", Description = "Reformat class", Group = "C#")]
    public class ReformatClass : ContextActionBase
    {
        private readonly ICSharpContextActionDataProvider _provider;
        private IClassDeclaration _classDeclaration;

        public ReformatClass(ICSharpContextActionDataProvider provider)
        {
            _provider = provider;
        }

        public override string Text
        {
            get { return "Reformat class"; }
        }

        public override bool IsAvailable(IUserDataHolder cache)
        {
            var classDeclaration = _provider.GetSelectedElement<IClassDeclaration>(false, true);
            if (classDeclaration != null)
            {
                // ensure that we are on a class and not just inside the scope of a classS
                if (_provider.SelectedElement != null && classDeclaration != _provider.SelectedElement.Parent)
                    return false;

                _classDeclaration = classDeclaration;
                return true;
            }
            return false;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            if (_classDeclaration == null) return null;

            using (_classDeclaration.Body.CreateWriteLock())
            {
                _classDeclaration.Body.FormatNode();
            }
            return null;
        }
    }
}