////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaxEditor.Content
{
    /// <summary>
    /// Helper content item used to mock UI during creating new assets by <see cref="FlaxEditor.Windows.ContentWindow"/>.
    /// </summary>
    /// <seealso cref="FlaxEditor.Content.ContentItem" />
    public sealed class NewItem : ContentItem
    {
        /// <summary>
        /// Gets the proxy object related to the created asset.
        /// </summary>
        /// <value>
        /// The content proxy.
        /// </value>
        public ContentProxy Proxy { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewItem"/> class.
        /// </summary>
        /// <param name="path">The path for the new item.</param>
        /// <param name="proxy">The content proxy object.</param>
        public NewItem(string path, ContentProxy proxy)
            : base(path)
        {
            Proxy = proxy;
        }

        /// <inheritdoc />
        public override ContentItemType ItemType => ContentItemType.Other;

        /// <inheritdoc />
        public override string DefaultPreviewName => "Document64";

        /// <inheritdoc />
        protected override bool DrawShadow => true;
    }
}
