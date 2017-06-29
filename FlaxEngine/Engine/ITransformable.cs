﻿////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

namespace FlaxEngine
{
    /// <summary>
    /// Interface for objects that can be transformed.
    /// </summary>
    public interface ITransformable
    {
        /// <summary>
        /// Gets or sets the transform.
        /// </summary>
        /// <value>
        /// The transform.
        /// </value>
        Transform Transform { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>     
        Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        Quaternion Orientation { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        Vector3 Scale { get; set; }
    }
}
