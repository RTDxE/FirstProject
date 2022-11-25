using UnityEditor;
using UnityEngine;

namespace MergeRace
{
    [CustomEditor(typeof(StorableObject), true)]
    public class StorableObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var scriptableObject = (StorableObject)target;

            var defaultColor = GUI.backgroundColor;
            using (new EditorGUILayout.HorizontalScope())
            {
                GUI.backgroundColor = new Color(0.5f, 0.75f, 1f);
                if (GUILayout.Button("Load", GUILayout.Height(40)))
                {
                    scriptableObject.LoadFromFile();
                }

                GUI.backgroundColor = new Color(0.01f, 0.99f, 0.50f);
                if (GUILayout.Button("Save", GUILayout.Height(40)))
                {
                    scriptableObject.SaveToFile();
                }
            }

            GUI.backgroundColor = defaultColor;

            base.OnInspectorGUI();
        }
    }
}