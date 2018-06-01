// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using FlaxEngine;

namespace FlaxEditor.Options
{
    /// <summary>
    /// General editor options data container.
    /// </summary>
    [CustomEditor(typeof(Editor<GeneralOptions>))]
    public sealed class GeneralOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether enable editor analytics service.
        /// </summary>
        [EditorDisplay("Analytics"), Tooltip("Enables or disables anonymous editor analytics service used to improve editor experience and the quality")]
        public bool EnableEditorAnalytics { get; set; } = true;
    }
}