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
    [ContextAction(Name = "ReformatMethod", Description = "Reformat method", Group = "C#")]
    public class ReformatMethod : ContextActionBase
    {
        private readonly ICSharpContextActionDataProvider _provider;
        private IMethodDeclaration _methodDeclaration;

        public ReformatMethod(ICSharpContextActionDataProvider provider)
        {
            _provider = provider;
        }

        public override string Text
        {
            get { return "Reformat method"; }
        }

        public override bool IsAvailable(IUserDataHolder cache)
        {
            var methodDeclaration = _provider.GetSelectedElement<IMethodDeclaration>(false, true);
            if (methodDeclaration != null)
            {
                // ensure that we are on a method and not just inside the scope of a method
                if (_provider.SelectedElement != null && methodDeclaration != _provider.SelectedElement.Parent)
                    return false;

                _methodDeclaration = methodDeclaration;
                return true;
            }
            return false;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            if (_methodDeclaration == null) return null;

            using (_methodDeclaration.Body.CreateWriteLock())
            {
                _methodDeclaration.Body.FormatNode();
            }
            return null;
        }
    }
}