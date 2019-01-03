// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using FlaxEngine;

namespace FlaxEditor.SceneGraph.Actors
{
    /// <summary>
    /// Scene tree node for <see cref="AudioSource"/> actor type.
    /// </summary>
    /// <seealso cref="ActorNodeWithIcon" />
    public sealed class AudioSourceNode : ActorNodeWithIcon
    {
        /// <inheritdoc />
        public AudioSourceNode(Actor actor)
        : base(actor)
        {
        }
    }
}
