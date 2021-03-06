// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// The interface to get Screen information from Flax.
    /// </summary>
    public static partial class Screen
    {
        /// <summary>
        /// Gets or sets the fullscreen mode.
        /// </summary>
        /// <remarks>
        /// A fullscreen mode switch may not happen immediately. It will be performed before next frame rendering.
        /// </remarks>
        [UnmanagedCall]
        public static bool IsFullscreen
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetIsFullscreen(); }
            set { Internal_SetIsFullscreen(value); }
#endif
        }

        /// <summary>
        /// Gets or sets the window size.
        /// </summary>
        /// <remarks>
        /// Resizing may not happen immediately. It will be performed before next frame rendering.
        /// </remarks>
        [UnmanagedCall]
        public static Vector2 Size
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector2 resultAsRef; Internal_GetSize(out resultAsRef); return resultAsRef; }
            set { Internal_SetSize(ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets the cursor visible flag. Allows to hide the cursor or show it.
        /// </summary>
        [UnmanagedCall]
        public static bool CursorVisible
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetCursorVisible(); }
            set { Internal_SetCursorVisible(value); }
#endif
        }

        /// <summary>
        /// Gets or sets the cursor lock mode. Allows to lock or unlock mouse cursor movement.
        /// </summary>
        [UnmanagedCall]
        public static CursorLockMode CursorLock
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetCursorLock(); }
            set { Internal_SetCursorLock(value); }
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetIsFullscreen();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetIsFullscreen(bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetSize(out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetSize(ref Vector2 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetCursorVisible();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetCursorVisible(bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern CursorLockMode Internal_GetCursorLock();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetCursorLock(CursorLockMode val);
#endif

        #endregion
    }
}
