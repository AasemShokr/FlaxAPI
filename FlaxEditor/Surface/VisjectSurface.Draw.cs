// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using FlaxEditor.Surface.Elements;
using FlaxEngine;

namespace FlaxEditor.Surface
{
    public partial class VisjectSurface
    {
        /// <inheritdoc />
        public override void Update(float deltaTime)
        {
            // Update scale
            var currentScale = _rootControl.Scale.X;
            if (Mathf.Abs(_targetScale - currentScale) > 0.001f)
            {
                var scale = new Vector2(Mathf.Lerp(currentScale, _targetScale, deltaTime * 10.0f));
                _rootControl.Scale = scale;
            }

            // Navigate when mouse is near the edge and is doing sth
            bool isMovingWithMouse = false;
            if (IsMovingSelection || IsConnecting)
            {
                Vector2 moveVector = Vector2.Zero;
                float edgeDetectDistance = 22.0f;
                if (_mousePos.X < edgeDetectDistance)
                {
                    moveVector.X -= 1;
                }
                if (_mousePos.Y < edgeDetectDistance)
                {
                    moveVector.Y -= 1;
                }
                if (_mousePos.X > Width - edgeDetectDistance)
                {
                    moveVector.X += 1;
                }
                if (_mousePos.Y > Height - edgeDetectDistance)
                {
                    moveVector.Y += 1;
                }
                moveVector.Normalize();
                isMovingWithMouse = moveVector.LengthSquared > Mathf.Epsilon;
                if (isMovingWithMouse)
                {
                    _rootControl.Location -= moveVector * _moveViewWithMouseDragSpeed;
                }
            }
            _moveViewWithMouseDragSpeed = isMovingWithMouse ? Mathf.Clamp(_moveViewWithMouseDragSpeed + deltaTime * 20.0f, 1.0f, 8.0f) : 1.0f;

            base.Update(deltaTime);
        }

        /// <summary>
        /// Draws the surface background.
        /// </summary>
        protected virtual void DrawBackground()
        {
            var background = Style.Background;
            if (background && background.ResidentMipLevels > 0)
            {
                var bSize = background.Size;
                float bw = bSize.X;
                float bh = bSize.Y;
                Vector2 pos = Vector2.Mod(bSize);

                if (pos.X > 0)
                    pos.X -= bw;
                if (pos.Y > 0)
                    pos.Y -= bh;

                int maxI = Mathf.CeilToInt(Width / bw + 1.0f);
                int maxJ = Mathf.CeilToInt(Height / bh + 1.0f);

                for (int i = 0; i < maxI; i++)
                {
                    for (int j = 0; j < maxJ; j++)
                    {
                        Render2D.DrawTexture(background, new Rectangle(pos.X + i * bw, pos.Y + j * bh, bw, bh), Color.White);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the selection background.
        /// </summary>
        /// <remarks>Called only when user is selecting nodes using rectangle tool.</remarks>
        protected virtual void DrawSelection()
        {
            var selectionRect = Rectangle.FromPoints(_leftMouseDownPos, _mousePos);
            Render2D.FillRectangle(selectionRect, Color.Orange * 0.4f);
            Render2D.DrawRectangle(selectionRect, Color.Orange);
        }

        /// <summary>
        /// Draws the comment creating background.
        /// </summary>
        /// <remarks>Called only when user is creating comment using rectangle tool.</remarks>
        protected virtual void DrawCommenting()
        {
            var selectionRect = Rectangle.FromPoints(_leftMouseDownPos, _mousePos);
            Render2D.FillRectangle(selectionRect, Color.White * 0.4f);
            Render2D.DrawRectangle(selectionRect, Color.White);
        }

        /// <summary>
        /// Draws all the connections between surface nodes.
        /// </summary>
        /// <param name="mousePosition">The current mouse position (in surface-space).</param>
        protected virtual void DrawConnections(ref Vector2 mousePosition)
        {
            // Draw all connections at once to boost batching process
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].DrawConnections(ref mousePosition);
            }
        }

        /// <summary>
        /// Draws the connecting line.
        /// </summary>
        /// <remarks>Called only when user is connecting nodes.</remarks>
        protected virtual void DrawConnectingLine()
        {
            // Get start position
            Vector2 startPos = _connectionInstigator.ConnectionOrigin;

            // Check if mouse is over any of box
            Vector2 endPos = _activeVisjectCM.Visible ? _rootControl.PointFromParent(ref _cmStartPos) : _rootControl.PointFromParent(ref _mousePos);
            Color lineColor = Style.Colors.Connecting;
            if (_lastInstigatorUnderMouse != null && !_activeVisjectCM.Visible)
            {
                // Check if can connect objects
                bool canConnect = _connectionInstigator.CanConnectWith(_lastInstigatorUnderMouse);
                lineColor = canConnect ? Style.Colors.ConnectingValid : Style.Colors.ConnectingInvalid;
                endPos = _lastInstigatorUnderMouse.ConnectionOrigin;
            }

            // Draw connection
            _connectionInstigator.DrawConnectingLine(ref startPos, ref endPos, ref lineColor);
        }

        /// <summary>
        /// Draws the contents of the surface (nodes, connections, comments, etc.).
        /// </summary>
        protected virtual void DrawContents()
        {
            base.Draw();
        }

        /// <inheritdoc />
        public override void Draw()
        {
            var style = FlaxEngine.GUI.Style.Current;
            var rect = new Rectangle(Vector2.Zero, Size);

            DrawBackground();

            _rootControl.DrawComments();

            if (IsCreatingComment)
            {
                DrawCommenting();
            }
            else if (IsSelecting)
            {
                DrawSelection();
            }

            // Push surface view transform (scale and offset)
            Render2D.PushTransform(ref _rootControl._cachedTransform);

            var mousePos = _rootControl.PointFromParent(ref _mousePos);
            DrawConnections(ref mousePos);

            if (IsConnecting)
            {
                DrawConnectingLine();
            }

            Render2D.PopTransform();

            DrawContents();

            //Render2D.DrawText(style.FontTitle, string.Format("Scale: {0}", _rootControl.Scale), rect, Enabled ? Color.Red : Color.Black);

            // Draw border
            if (ContainsFocus)
            {
                Render2D.DrawRectangle(new Rectangle(0, 0, rect.Width - 2, rect.Height - 2), style.BackgroundSelected);
            }

            // Draw disabled overlay
            //if (!Enabled)
            //    Render2D.FillRectangle(rect, new Color(0.2f, 0.2f, 0.2f, 0.5f), true);
        }
    }
}
