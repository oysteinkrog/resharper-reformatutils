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
    [ContextAction(Name = "ReformatInterface", Description = DescriptionText, Group = "C#")]
    public class ReformatInterface : ContextActionBase
    {
        private const string DescriptionText = "Reformat interface";
        private readonly ICSharpContextActionDataProvider _provider;
        private IClassLikeDeclaration _interfaceDeclaration;

        public ReformatInterface(ICSharpContextActionDataProvider provider)
        {
            _provider = provider;
        }

        public override string Text
        {
            get { return DescriptionText; }
        }

        public override bool IsAvailable(IUserDataHolder cache)
        {
            var interfaceDeclaration = _provider.GetSelectedElement<IInterfaceDeclaration>(false, true);
            if (interfaceDeclaration != null)
            {
                // ensure that we are on a class and not just inside the scope of a classS
                if (_provider.SelectedElement != null && interfaceDeclaration != _provider.SelectedElement.Parent)
                    return false;

                _interfaceDeclaration = interfaceDeclaration;
                return true;
            }
            return false;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            if (_interfaceDeclaration == null) return null;

            using (_interfaceDeclaration.Body.CreateWriteLock())
            {
                _interfaceDeclaration.Body.FormatNode();
            }
            return null;
        }
    }
}