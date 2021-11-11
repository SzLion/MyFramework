using UnityEditor;
using UnityEngine;
namespace CounterApp
{
    public class EditorCounterApp : EditorWindow
    {
        [MenuItem("EditorCounterApp/Open")] 
        static void Open()
        {
            CounterApp.DestoryArchitecture();
            CounterApp.OnRegisterPatch += app =>
            {                
                app.RegisterUtility<IStorage>(new EditorPrefsStorage());
                
            };

            var editorCounterApp = GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100,100,400,600);
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
               new AddCountCommand().Execute();
            }

            GUILayout.Label(CounterApp .Get<ICounterModel>().Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                new SubCountCommand().Execute();
            }
        }
    }
}