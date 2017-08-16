////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using FlaxEditor.History;
using FlaxEngine;

namespace FlaxEditor
{
    /// <summary>
    /// Implementation of <see cref="Undo"/> customized for the <see cref="Editor"/>.
    /// </summary>
    /// <seealso cref="FlaxEditor.Undo" />
    public class EditorUndo : Undo
    {
        private readonly Editor _editor;

        internal EditorUndo(Editor editor)
        {
            _editor = editor;
        }

        /// <inheritdoc />
        public override bool Enabled
        {
            get => _editor.StateMachine.CurrentState.CanUseUndoRedo;
            set => throw new AccessViolationException("Cannot change enabled state of the editor main undo.");
        }

        /// <inheritdoc />
        protected override void OnAction(IUndoAction action)
        {
            CheckSceneEdited(action);
            base.OnAction(action);
        }

        /// <inheritdoc />
        protected override void OnUndo(IUndoAction action)
        {
            CheckSceneEdited(action);
            base.OnUndo(action);
        }

        /// <inheritdoc />
        protected override void OnRedo(IUndoAction action)
        {
            CheckSceneEdited(action);
            base.OnRedo(action);
        }

        /// <summary>
        /// Checks if the any scene has been edited after performing the given action.
        /// </summary>
        /// <param name="action">The action.</param>
        private void CheckSceneEdited(IUndoAction action)
        {
            // Note: this is automatic tracking system to check if undo action modifies scene objects
            
            if (action is UndoActionObject undoActionObject)
            {
                var data = undoActionObject.PrepareData();
                
                if (data.TargetInstance is SceneGraph.SceneGraphNode node)
                {
                    Editor.Instance.Scene.MarkSceneEdited(node.ParentScene);
                }
                else if (data.TargetInstance is Actor actor)
                {
                    Editor.Instance.Scene.MarkSceneEdited(actor.Scene);
                }
            }
            else if (action is TransformObjectsAction transformObjectsAction)
            {
                var data = transformObjectsAction.Data;

                for (int i = 0; i < data.Selection.Length; i++)
                {
                    Editor.Instance.Scene.MarkSceneEdited(data.Selection[i].ParentScene);
                }
            }
        }
    }
}
