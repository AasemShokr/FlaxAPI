// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;
using FlaxEngine.Rendering;

namespace FlaxEngine.Rendering
{
    /// <summary>
    /// Graphics Device is a basic GPU work manager that is responsible to manage graphics resources as well as perform scene rendering and submit frames to the user.
    /// </summary>
    public static partial class GraphicsDevice
    {
        /// <summary>
        /// Gets the graphics device limits description.
        /// </summary>
        [UnmanagedCall]
        public static DeviceLimits Limits
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { DeviceLimits resultAsRef; Internal_GetLimits(out resultAsRef); return resultAsRef; }
#endif
        }

        /// <summary>
        /// Gets the graphics device rendering backend type.
        /// </summary>
        [UnmanagedCall]
        public static RendererType RendererType
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetRendererType(); }
#endif
        }

        /// <summary>
        /// Gets the graphics device shaders profile type.
        /// </summary>
        [UnmanagedCall]
        public static ShaderProfile ShaderProfile
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetShaderProfile(); }
#endif
        }

        /// <summary>
        /// Gets the total estimated graphics memory usage (in bytes).
        /// </summary>
        [UnmanagedCall]
        public static ulong MemoryUsage
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetMemoryUsage(); }
#endif
        }

        /// <summary>
        /// Gets the native pointer to the underlying graphics device. It's a low-level platform-specific handle.
        /// </summary>
        [UnmanagedCall]
        public static IntPtr NativePtr
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetNativePtr(); }
#endif
        }

        /// <summary>
        /// Gets the GPU vendor identifier.
        /// </summary>
        [UnmanagedCall]
        public static int VendorId
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetVendorId(); }
#endif
        }

        /// <summary>
        /// Gets a string that contains the GPU adapter description. Used for presentation to the user.
        /// </summary>
        [UnmanagedCall]
        public static string Description
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetDescription(); }
#endif
        }

        /// <summary>
        /// Dumps all resources information to the log.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static void DumpResourcesToLog()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_DumpResourcesToLog();
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetLimits(out DeviceLimits resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern RendererType Internal_GetRendererType();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ShaderProfile Internal_GetShaderProfile();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong Internal_GetMemoryUsage();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern IntPtr Internal_GetNativePtr();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetVendorId();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string Internal_GetDescription();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_DumpResourcesToLog();
#endif

        #endregion
    }
}
