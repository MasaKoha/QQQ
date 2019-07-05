using System.IO;
using UnityEditor;
using UnityEngine;

namespace QQQ.Editor
{
    public class QQQEditorWindow : EditorWindow
    {
        [MenuItem("Window/QQQ")]
        private static void Open()
        {
            EditorWindow.GetWindow<QQQEditorWindow>("QQQ");
        }

        private void OnEnable()
        {
        }

        private void OnGUI()
        {
            var style = new GUIStyle(GUI.skin.label);
            style.wordWrap = true;

            var files = Directory.GetFiles(Application.persistentDataPath);

            if (GUILayout.Button("Delete All Persistent Data"))
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            GUILayout.Label("↓Application.persistentDataPath↓", style);
            GUILayout.Label(Application.persistentDataPath, style);
        }
    }
}