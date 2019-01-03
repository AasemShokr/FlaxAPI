// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Point light emits light from point in all directions.
    /// </summary>
    [Serializable]
    public sealed partial class PointLight : LightWithShadow
    {
        /// <summary>
        /// Creates new <see cref="PointLight"/> object.
        /// </summary>
        private PointLight() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="PointLight"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static PointLight New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(PointLight)) as PointLight;
#endif
        }

        /// <summary>
        /// Gets or sets light radius parameter.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(1), EditorDisplay("Light"), Tooltip("Light radius"), Limit(0, 100000, 0.1f)]
        public float Radius
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetRadius(unmanagedPtr); }
            set { Internal_SetRadius(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets light source bulb radius parameter.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(2), EditorDisplay("Light"), Tooltip("Light bulb source radius"), Limit(0, 1000, 0.01f)]
        public float SourceRadius
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetSourceRadius(unmanagedPtr); }
            set { Internal_SetSourceRadius(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets light source bulb length parameter.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(3), EditorDisplay("Light"), Tooltip("Light build source length"), Limit(0, 1000, 0.01f)]
        public float SourceLength
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetSourceLength(unmanagedPtr); }
            set { Internal_SetSourceLength(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets light source radial falloff parameter. Controls the radial falloff of light when UseInverseSquaredFalloff is disabled.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(13), EditorDisplay("Light"), Tooltip("Controls the radial falloff of light when UseInverseSquaredFalloff is disabled."), Limit(2, 16, 0.01f)]
        public float FallOffExponent
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetFallOffExponent(unmanagedPtr); }
            set { Internal_SetFallOffExponent(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the value indicating whether to use physically based inverse squared distance falloff.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(14), EditorDisplay("Light"), Tooltip("Whether to use physically based inverse squared distance falloff, where Radius is only clamping the light's contribution.")]
        public bool UseInverseSquaredFalloff
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetUseInverseSquaredFalloff(unmanagedPtr); }
            set { Internal_SetUseInverseSquaredFalloff(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the IES texture (light profiles from real world measured data).
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(211), EditorDisplay("IES Profile", "IES Texture"), Tooltip("IES texture (light profiles from real world measured data)")]
        public IESProfile IESTexture
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetIESTexture(unmanagedPtr); }
            set { Internal_SetIESTexture(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        /// <summary>
        /// Enables or disables using light brightness from IES profile.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(212), EditorDisplay("IES Profile", "Use IES Brightness"), Tooltip("Enable/disable using light brightness from IES profile")]
        public bool UseIESBrightness
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetUseIESBrightness(unmanagedPtr); }
            set { Internal_SetUseIESBrightness(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the global scale for IES brightness contribution.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(213), Limit(0, 10000, 0.01f), EditorDisplay("IES Profile", "Brightness Scale"), Tooltip("Global scale for IES brightness contribution")]
        public float IESBrightnessScale
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetIESBrightnessScale(unmanagedPtr); }
            set { Internal_SetIESBrightnessScale(unmanagedPtr, value); }
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetRadius(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetRadius(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetSourceRadius(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetSourceRadius(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetSourceLength(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetSourceLength(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetFallOffExponent(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetFallOffExponent(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetUseInverseSquaredFalloff(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetUseInverseSquaredFalloff(IntPtr obj, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern IESProfile Internal_GetIESTexture(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetIESTexture(IntPtr obj, IntPtr val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetUseIESBrightness(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetUseIESBrightness(IntPtr obj, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetIESBrightnessScale(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetIESBrightnessScale(IntPtr obj, float val);
#endif

        #endregion
    }
}
