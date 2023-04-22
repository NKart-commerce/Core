using NKart.Web.Models;

namespace NKart.Web.Search.Provisional
{
    using System;

    using NKart.Core;
    using NKart.Core.Trees;
    using NKart.Web.Models;

    /// <summary>
    /// Represents a tree node visitor that finds a particular product filter group in the tree.
    /// </summary>
    internal class PrimedProductFilterGroupVisitor : TreeNodeVistorBase<ProductFilterGroupNode>
    {
        /// <summary>
        /// The target product filter group.
        /// </summary>
        private readonly IProductFilterGroup _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimedProductFilterGroupVisitor"/> class.
        /// </summary>
        /// <param name="group">
        /// The <see cref="IProductFilterGroup"/>.
        /// </param>
        public PrimedProductFilterGroupVisitor(IProductFilterGroup group)
        {
            Ensure.ParameterNotNull(group, "group");
            _group = group;
        }

        /// <summary>
        /// Performs the check on each tree node item.
        /// </summary>
        /// <param name="item">
        /// The tree node item.
        /// </param>
        public override void Visit(TreeNode<ProductFilterGroupNode> item)
        {
            if (item.Value.Item.Key == _group.Key) Enqueue(item);
        }
    }
}