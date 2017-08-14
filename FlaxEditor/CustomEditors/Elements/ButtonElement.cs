////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEngine.GUI;

namespace FlaxEditor.CustomEditors.Elements
{
    /// <summary>
    /// The button element.
    /// </summary>
    /// <seealso cref="FlaxEditor.CustomEditors.LayoutElement" />
    public class ButtonElement : LayoutElement
    {
        /// <summary>
        /// The button.
        /// </summary>
        public readonly Button Button = new Button(0, 0);
        
        /// <summary>
        /// Initializes the element.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Init(string text)
        {
            Button.Text = text;
        }

        /// <inheritdoc />
        public override Control Control => Button;
    }
}