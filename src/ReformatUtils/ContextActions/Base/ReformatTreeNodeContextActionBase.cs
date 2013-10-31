using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.TextControl;
using JetBrains.Util;

namespace ReformatUtils.ContextActions.Base
{
    public abstract class ReformatTreeNodeContextActionBase<T> : ContextActionBase where T : class, ITreeNode
    {
        private readonly ICSharpContextActionDataProvider _contextActionDataProvider;
        private ITreeNode _block;

        protected ReformatTreeNodeContextActionBase(ICSharpContextActionDataProvider contextActionDataProvider)
        {
            _contextActionDataProvider = contextActionDataProvider;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            if (_block == null) return null;

            using (_block.CreateWriteLock())
            {
                _block.FormatNode();
            }
            return null;
        }

        protected abstract ITreeNode GetNodeToFormat(T element);

        public override bool IsAvailable(IUserDataHolder cache)
        {
            var element = _contextActionDataProvider.GetSelectedElement<T>(false, true);
            if (element == null) return false;

            if (_contextActionDataProvider.SelectedElement != null &&
                element != _contextActionDataProvider.SelectedElement.Parent)
                return false;

            _block = GetNodeToFormat(element);
            return true;
        }
    }
}