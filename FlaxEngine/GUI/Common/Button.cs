// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using System;

namespace FlaxEngine.GUI
{
    /// <summary>
    /// Button control
    /// </summary>
    public class Button : Control
    {
        /// <summary>
        /// The default height fro the buttons.
        /// </summary>
        public const float DefaultHeight = 24.0f;

        /// <summary>
        /// The mouse down flag.
        /// </summary>
        protected bool _mouseDown;

        /// <summary>
        /// Button text property.
        /// </summary>
        [EditorOrder(10), Tooltip("The buton label text.")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the font used to draw button text.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2000)]
        public FontReference Font { get; set; }

        /// <summary>
        /// Gets or sets the custom material used to render the text. It must has domain set to GUI and have a public texture parameter named Font used to sample font atlas texture with font characters data.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2000), Tooltip("Custom material used to render the text. It must has domain set to GUI and have a public texture parameter named Font used to sample font atlas texture with font characters data.")]
        public MaterialBase TextMaterial { get; set; }

        /// <summary>
        /// Gets or sets the color used to draw button text.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2000)]
        public Color TextColor;

        /// <summary>
        /// Event fired when user clicks on the button
        /// </summary>
        public event Action Clicked;

        /// <summary>
        /// Event fired when user clicks on the button
        /// </summary>
        public event Action<Button> ButtonClicked;

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2000)]
        public Color BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the background color when button is selected.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2010)]
        public Color BackgroundColorSelected { get; set; }

        /// <summary>
        /// Gets or sets the border color when button is selected.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2020)]
        public Color BorderColorSelected { get; set; }

        /// <summary>
        /// Gets or sets the background color when button is highlighted.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2000)]
        public Color BackgroundColorHighlighted { get; set; }

        /// <summary>
        /// Gets or sets the border color when button is highlighted.
        /// </summary>
        [EditorDisplay("Style"), EditorOrder(2000)]
        public Color BorderColorHighlighted { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
        : this(0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="x">Position X coordinate</param>
        /// <param name="y">Position Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Button(float x, float y, float width = 120, float height = DefaultHeight)
        : base(x, y, width, height)
        {
            var style = Style.Current;
            Font = new FontReference(style.FontMedium);
            TextColor = style.Foreground;
            BackgroundColor = style.BackgroundNormal;
            BorderColor = style.BorderNormal;
            BackgroundColorSelected = style.BackgroundSelected;
            BorderColorSelected = style.BorderSelected;
            BackgroundColorHighlighted = style.BackgroundHighlighted;
            BorderColorHighlighted = style.BorderHighlighted;
        }

        /// <summary>
        /// Called when mouse clicks the button.
        /// </summary>
        protected virtual void OnClick()
        {
            Clicked?.Invoke();
            ButtonClicked?.Invoke(this);
        }

        /// <summary>
        /// Sets the button colors palette based on a given main color.
        /// </summary>
        /// <param name="color">The main color.</param>
        public void SetColors(Color color)
        {
            BackgroundColor = color;
            BorderColor = color.RGBMultiplied(0.5f);
            BackgroundColorSelected = color.RGBMultiplied(0.8f);
            BorderColorSelected = BorderColor;
            BackgroundColorHighlighted = color.RGBMultiplied(1.2f);
            BorderColorHighlighted = BorderColor;
        }

        #region Control

        /// <inheritdoc />
        public override void Draw()
        {
            // Cache data
            Rectangle clientRect = new Rectangle(Vector2.Zero, Size);
            bool enabled = EnabledInHierarchy;
            Color backgroundColor = BackgroundColor;
            Color borderColor = BorderColor;
            Color textColor = TextColor;
            if (!enabled)
            {
                backgroundColor *= 0.5f;
                borderColor *= 0.5f;
                textColor *= 0.6f;
            }
            else if (_mouseDown)
            {
                backgroundColor = BackgroundColorSelected;
                borderColor = BorderColorSelected;
            }
            else if (IsMouseOver)
            {
                backgroundColor = BackgroundColorHighlighted;
                borderColor = BorderColorHighlighted;
            }

            // Draw background
            Render2D.FillRectangle(clientRect, backgroundColor);
            Render2D.DrawRectangle(clientRect, borderColor);

            // Draw text
            Render2D.DrawText(Font.GetFont(), TextMaterial, Text, clientRect, textColor, TextAlignment.Center, TextAlignment.Center);
        }

        /// <inheritdoc />
        public override void OnMouseLeave()
        {
            // Clear flag
            _mouseDown = false;

            base.OnMouseLeave();
        }

        /// <inheritdoc />
        public override bool OnMouseDown(Vector2 location, MouseButton buttons)
        {
            // Check mouse button
            if (buttons == MouseButton.Left)
            {
                // Set flag
                _mouseDown = true;
            }

            return base.OnMouseDown(location, buttons);
        }

        /// <inheritdoc />
        public override bool OnMouseUp(Vector2 location, MouseButton buttons)
        {
            // Check mouse button and flag
            if (_mouseDown && buttons == MouseButton.Left)
            {
                // Clear flag
                _mouseDown = false;

                // Call event
                OnClick();

                // Handled
                return true;
            }

            return base.OnMouseUp(location, buttons);
        }

        /// <inheritdoc />
        public override void OnLostFocus()
        {
            // Clear flag
            _mouseDown = false;

            base.OnLostFocus();
        }

        #endregion
    }
}
