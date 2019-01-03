// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using FlaxEngine;

namespace FlaxEditor.SceneGraph
{
    /// <summary>
    /// Scene Graph node type used for the collider shapes.
    /// </summary>
    /// <seealso cref="ActorNode" />
    /// <seealso cref="Collider" />
    public class ColliderNode : ActorNode
    {
        /// <inheritdoc />
        public ColliderNode(Actor actor)
        : base(actor)
        {
        }

        /// <inheritdoc />
        public override bool RayCastSelf(ref RayCastData ray, out float distance)
        {
            // Check if skip raycasts
            if ((ray.Flags & RayCastData.FlagTypes.SkipColliders) == RayCastData.FlagTypes.SkipColliders)
            {
                distance = 0;
                return false;
            }

            return base.RayCastSelf(ref ray, out distance);
        }
    }
}
