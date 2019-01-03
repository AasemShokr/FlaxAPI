// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using FlaxEngine.GUI;
using NUnit.Framework;
using Assert = FlaxEngine.Assertions.Assert;

namespace FlaxEngine.Tests
{
    [TestFixture]
    public class TextControl
    {
        public class SimpleControl : Control
        {
            public SimpleControl(bool canFocus, float x, float y, float width, float height)
            : base(x, y, width, height)
            {
                CanFocus = canFocus;
            }

            public SimpleControl(bool canFocus, Vector2 location, Vector2 size)
            : base(location, size)
            {
                CanFocus = canFocus;
            }

            public SimpleControl(bool canFocus, Rectangle bounds)
            : base(bounds)
            {
                CanFocus = canFocus;
            }
        }

        [Test]
        public void ControlTestApi()
        {
            var testRect = new Rectangle(0, 5, 20, 25);
            var basic = new SimpleControl(true, 0, 5, 20, 25);
            var vec2 = new SimpleControl(true, new Vector2(0, 5), new Vector2(20, 25));
            var rect = new SimpleControl(true, testRect);

            Assert.AreEqual(testRect.Location, basic.Location);
            Assert.AreEqual(testRect.Location, vec2.Location);
            Assert.AreEqual(testRect.Location, rect.Location);

            Assert.AreEqual(true, basic.CanFocus);
            Assert.AreEqual(true, vec2.CanFocus);
            Assert.AreEqual(true, rect.CanFocus);

            Assert.AreEqual(testRect.Size, basic.Size);
            Assert.AreEqual(testRect.Size, vec2.Size);
            Assert.AreEqual(testRect.Size, rect.Size);

            Assert.AreEqual(testRect, basic.Bounds);
            Assert.AreEqual(testRect, vec2.Bounds);
            Assert.AreEqual(testRect, rect.Bounds);

            Assert.AreEqual(testRect.Top, rect.Top);
            Assert.AreEqual(testRect.Left, rect.Left);
            Assert.AreEqual(testRect.Right, rect.Right);
            Assert.AreEqual(testRect.Bottom, rect.Bottom);
            Assert.AreEqual(testRect.BottomRight, rect.BottomRight);
            Assert.AreEqual(testRect.BottomLeft, rect.BottomLeft);
            Assert.AreEqual(testRect.UpperLeft, rect.UpperLeft);
            Assert.AreEqual(testRect.UpperRight, rect.UpperRight);

            Assert.AreEqual(testRect.Center, rect.Center);

            Assert.AreEqual(testRect.Width, rect.Width);
            Assert.AreEqual(testRect.Height, rect.Height);

            Assert.AreEqual(testRect.X, rect.X);
            Assert.AreEqual(testRect.Y, rect.Y);

            testRect = new Rectangle(1, 6, 21, 26);
            rect.X = 1;
            rect.Y = 6;
            rect.Width = 21;
            rect.Height = 26;
            Assert.AreEqual(testRect, rect.Bounds);

            testRect = new Rectangle(2, 7, 22, 27);
            rect.Location = new Vector2(2, 7);
            rect.Size = new Vector2(22, 27);
            Assert.AreEqual(testRect, rect.Bounds);

            rect.BackgroundColor = Color.Azure;
            Assert.AreEqual(Color.Azure, rect.BackgroundColor);

            Assert.IsTrue(rect.Enabled);
            rect.Enabled = false;
            Assert.IsFalse(rect.Enabled);
            rect.Enabled = true;
            Assert.IsTrue(rect.Enabled);

            Assert.IsTrue(rect.Visible);
            rect.Visible = false;
            Assert.IsFalse(rect.Visible);
            rect.Visible = true;
            Assert.IsTrue(rect.Visible);
        }

        [Test]
        public void ControlTestEvents()
        {
            //var control = new TestControl(true, new Rectangle(0, 5, 20, 25));
            //Action<Control> action = ctrl => Assert.AreEqual(control, ctrl);
            //control.OnLocationChanged += action;
        }
    }
}
