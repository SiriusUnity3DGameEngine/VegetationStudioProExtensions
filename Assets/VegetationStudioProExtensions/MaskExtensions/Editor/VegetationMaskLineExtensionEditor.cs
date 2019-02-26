﻿using AwesomeTechnologies;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace VegetationStudioProExtensions
{
    [CustomEditor(typeof(VegetationMaskLineExtension))]
    [CanEditMultipleObjects]
    public class VegetationMaskLineExtensionEditor : BaseEditor<VegetationMaskLineExtension>
    {
        private VegetationMaskLineExtension extension;
        private VegetationMaskLine mask;

        private SerializedProperty container;

        public void OnEnable()
        {
            extension = (VegetationMaskLineExtension)target;

            mask = extension.GetComponent<VegetationMaskLine>();

            container = FindProperty(x => x.container);
        }

        public override void OnInspectorGUI()
        {
            // we draw our own inspector
            // DrawDefaultInspector();

            serializedObject.Update();

            GUILayout.BeginVertical("box");
            {
                EditorGUILayout.HelpBox("Create a line mask using all of the children of the specified container", MessageType.Info);

                //
                // properties
                //

                GUILayout.BeginHorizontal();
                {
                    // show error color in case there's no container
                    if (extension.container == null)
                    {
                        SetErrorBackgroundColor();
                    }

                    EditorGUILayout.PropertyField(container, new GUIContent("Container", "The transforms of the children of this container (parent) object will be used to create the line mask"));

                    // default color in case error color was set
                    SetDefaultBackgroundColor();
                }
                GUILayout.EndHorizontal();

                EditorGUILayout.LabelField("Children", GetChildCount().ToString());

                EditorGUILayout.Space();

                //
                // buttons
                //

                GUILayout.BeginHorizontal();
                {
                    // enable create line mask button only if there are children
                    SetGuiEnabled(GetChildCount() > 0);

                    // create line mask
                    if (GUILayout.Button("Create Line Mask"))
                    {
                        CreateLineMask();
                    }

                    // enable gui again in case it got disabled
                    SetGuiEnabled(true);

                    // clear line mask
                    if (GUILayout.Button("Clear Line Mask"))
                    {
                        ClearLineMask();
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }

        private int GetChildCount()
        {
            if (extension.container == null)
                return 0;

            return extension.container.GetComponentInChildren<Transform>().childCount;
        }

        private void ClearLineMask()
        {
            mask.ClearNodes();
        }

        private void CreateLineMask()
        {
            if (extension.container == null)
            {
                Debug.LogError("Container isn't set. Please specify a GameObject which contains transforms as children.");
                return;
            }

            Vector3[] positions = extension.container.GetComponentsInChildren<Transform>().Select(x => x.position).ToArray();

            mask.ClearNodes();
            mask.AddNodesToEnd(positions);

        }

    }
}
