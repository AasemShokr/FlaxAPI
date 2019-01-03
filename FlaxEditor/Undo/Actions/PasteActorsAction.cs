// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using FlaxEditor.SceneGraph;
using FlaxEngine;

namespace FlaxEditor.Actions
{
    /// <summary>
    /// Implementation of <see cref="IUndoAction"/> used to paste a set of <see cref="ActorNode"/>.
    /// </summary>
    /// <seealso cref="FlaxEditor.IUndoAction" />
    public class PasteActorsAction : IUndoAction
    {
        private Dictionary<Guid, Guid> _idsMapping;
        private byte[] _data;
        private Guid _pasteParent;

        /// <summary>
        /// The node parents.
        /// </summary>
        protected List<Guid> _nodeParents;

        /// <summary>
        /// Initializes a new instance of the <see cref="PasteActorsAction"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="objectIds">The object ids.</param>
        /// <param name="pasteParent">The paste parent object id.</param>
        /// <param name="name">The action name.</param>
        protected PasteActorsAction(byte[] data, Guid[] objectIds, ref Guid pasteParent, string name)
        {
            ActionString = name;

            _pasteParent = pasteParent;
            _idsMapping = new Dictionary<Guid, Guid>(objectIds.Length * 4);
            for (int i = 0; i < objectIds.Length; i++)
            {
                _idsMapping[objectIds[i]] = Guid.NewGuid();
            }

            _nodeParents = new List<Guid>(objectIds.Length);
            _data = data;
        }

        internal static PasteActorsAction Paste(byte[] data, Guid pasteParent)
        {
            var objectIds = Actor.TryGetSerializedObjectsIds(data);
            if (objectIds == null)
                return null;

            return new PasteActorsAction(data, objectIds, ref pasteParent, "Paste actors");
        }

        internal static PasteActorsAction Duplicate(byte[] data, Guid pasteParent)
        {
            var objectIds = Actor.TryGetSerializedObjectsIds(data);
            if (objectIds == null)
                return null;

            return new PasteActorsAction(data, objectIds, ref pasteParent, "Duplicate actors");
        }

        /// <summary>
        /// Links the broken parent reference (missing parent). By default links the actor to the first scene.
        /// </summary>
        /// <param name="actor">The actor.</param>
        protected virtual void LinkBrokenParentReference(Actor actor)
        {
            // Link to the first scene root
            if (SceneManager.ScenesCount == 0)
                throw new Exception("Failed to paste actor with a broken reference. No loaded scenes.");
            actor.SetParent(SceneManager.GetScene(0), false);
        }

        /// <inheritdoc />
        public string ActionString { get; }

        /// <summary>
        /// Performs the paste/duplicate action and outputs created objects nodes.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <param name="nodeParents">The node parents.</param>
        public virtual void Do(out List<ActorNode> nodes, out List<ActorNode> nodeParents)
        {
            // Restore objects
            var actors = Actor.FromBytes(_data, _idsMapping);
            if (actors == null)
            {
                nodes = null;
                nodeParents = null;
                return;
            }
            nodes = new List<ActorNode>(actors.Length);
            for (int i = 0; i < actors.Length; i++)
            {
                var actor = actors[i];

                // Check if has no parent linked (broken reference eg. old parent not existing)
                if (actor.Parent == null)
                {
                    LinkBrokenParentReference(actor);
                }

                var foundNode = SceneGraphFactory.FindNode(actor.ID);
                if (foundNode is ActorNode node)
                {
                    nodes.Add(node);
                }
            }

            nodeParents = nodes.BuildNodesParents();

            // Cache pasted nodes ids (parents only)
            _nodeParents.Clear();
            _nodeParents.Capacity = Mathf.Max(_nodeParents.Capacity, nodeParents.Count);
            for (int i = 0; i < nodeParents.Count; i++)
            {
                _nodeParents.Add(nodeParents[i].ID);
            }

            var pasteParentNode = Editor.Instance.Scene.GetActorNode(_pasteParent);
            if (pasteParentNode != null)
            {
                // Move pasted actors to the parent target (if specified and valid)
                for (int i = 0; i < nodeParents.Count; i++)
                {
                    nodeParents[i].Actor.SetParent(pasteParentNode.Actor, false);
                }
            }

            for (int i = 0; i < nodeParents.Count; i++)
            {
                // Fix name collisions (only for parents)
                var node = nodeParents[i];
                var parent = node.Actor?.Parent;
                if (parent != null)
                {
                    string name = node.Name;
                    Actor[] children = parent.GetChildren();
                    if (children.Count(x => x.Name == name) > 1)
                    {
                        // Generate new name
                        node.Actor.Name = StringUtils.IncrementNameNumber(name, x => children.All(y => y.Name != x));
                    }
                }

                Editor.Instance.Scene.MarkSceneEdited(node.ParentScene);
            }
        }

        /// <inheritdoc />
        public void Do()
        {
            Do(out _, out _);
        }

        /// <inheritdoc />
        public virtual void Undo()
        {
            // Remove objects
            for (int i = 0; i < _nodeParents.Count; i++)
            {
                var node = SceneGraphFactory.FindNode(_nodeParents[i]);
                Editor.Instance.Scene.MarkSceneEdited(node.ParentScene);
                node.Delete();
            }
            _nodeParents.Clear();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _nodeParents?.Clear();
            _idsMapping?.Clear();
            _data = null;
        }
    }
}
