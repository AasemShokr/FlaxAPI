// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

namespace FlaxEditor.Surface.Archetypes
{
    /// <summary>
    /// Contains helper utilities for custom graph nodes management.
    /// </summary>
    public static class Custom
    {
        /// <summary>
        /// The dummy custom node used to help custom surface nodes management (loading and layout preserving on missing type).
        /// </summary>
        /// <seealso cref="FlaxEditor.Surface.SurfaceNode" />
        public class DummyCustomNode : SurfaceNode
        {
            /// <inheritdoc />
            public DummyCustomNode(uint id, VisjectSurfaceContext context)
            : base(id, context, new NodeArchetype(), new GroupArchetype())
            {
            }
        }

        /// <summary>
        /// The custom nodes group identifier. Reserved for nodes that are provided by external source eg: game scripts or editor plugin. Handling of those nodes is surface-type dependant.
        /// </summary>
        public const ushort GroupID = 13;

        /// <summary>
        /// Gets the name of the node type (C# typename).
        /// </summary>
        /// <param name="arch">The node archetype.</param>
        /// <returns>The node typename.</returns>
        public static string GetNodeTypeName(NodeArchetype arch)
        {
            return (string)arch.DefaultValues[0];
        }

        /// <summary>
        /// Gets the node group name.
        /// </summary>
        /// <remarks>Every custom node can specify the group that it belongs to.</remarks>
        /// <param name="arch">The node archetype.</param>
        /// <returns>The node group name.</returns>
        public static string GetNodeGroup(NodeArchetype arch)
        {
            return (string)arch.DefaultValues[1];
        }
    }
}
