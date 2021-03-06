// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// A collider represented by an arbitrary mesh.
    /// </summary>
    [Serializable]
    public sealed partial class MeshCollider : Collider
    {
        /// <summary>
        /// Creates new <see cref="MeshCollider"/> object.
        /// </summary>
        private MeshCollider() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="MeshCollider"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static MeshCollider New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(MeshCollider)) as MeshCollider;
#endif
        }

        /// <summary>
        /// Gets or sets the linked collision mesh data asset.
        /// </summary>
        /// <remarks>
        /// Linked collision data asset that contains convex mesh or triangle mesh used to represent a mesh collider shape.
        /// </remarks>
        [UnmanagedCall]
        [EditorOrder(100), EditorDisplay("Collider"), Tooltip("Linked collision data asset that contains convex mesh or triangle mesh used to represent a mesh collider shape.")]
        public CollisionData CollisionData
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetCollisionData(unmanagedPtr); }
            set { Internal_SetCollisionData(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern CollisionData Internal_GetCollisionData(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetCollisionData(IntPtr obj, IntPtr val);
#endif

        #endregion
    }
}
