#if UNITY_EDITOR
using UnityEditor;

public class WorldPosViewer : Editor {
    void OnInspectorGUI() {

        EditorGUILayout.BeginHorizontal();
        //target.position = EditorGUILayout.Vector3Field("World Pos", target.position);
        //this will display the target's world pos.
        EditorGUILayout.EndHorizontal();

    }
}
#endif