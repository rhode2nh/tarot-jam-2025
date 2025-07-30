using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[InitializeOnLoad]
public class ModularSnapTool
{
    private static ModularSnapConfig _snapConfig;

    static ModularSnapTool()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        LoadConfig();
    }

    static void LoadConfig()
    {
        if (_snapConfig == null)
        {
            _snapConfig = Resources.Load<ModularSnapConfig>("SnapConfig");
        }
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        if (Selection.transforms.Length == 0)
            return;

        if (!Tools.current.Equals(Tool.Move))
            return;

        Event e = Event.current;
        if (!e.control && !e.shift) // Use Ctrl or Shift to enable snapping
            return;

        foreach (Transform t in Selection.transforms)
        {
            // if (PrefabUtility.IsPartOfPrefabInstance(t))
            //     PrefabUtility.UnpackPrefabInstance(t.gameObject, PrefabUnpackMode.OutermostRoot, InteractionMode.UserAction);

            Vector3 offset = Vector3.zero;
            if (!t.TryGetComponent(out ModularPiece piece)) return;
            Vector3 pos = t.position;

            if (piece.type == ModularPiece.PieceType.Floor)
            {
                float y = Mathf.Round(pos.y);
                // t.transform.position = new Vector3(pos.x, y, pos.z) + (floor.transform.up * FloorThickness);
                offset = t.up * _snapConfig.FloorThickness;
            }
                // offset = new Vector3(0, t.localScale.y / 2, 0); // Adjust for floor thickness
            else if (piece.type == ModularPiece.PieceType.Wall || piece.type == ModularPiece.PieceType.WallAcessory)
            {
                float x = Mathf.Round(pos.x);
                float z = Mathf.Round(pos.z);
                offset = (t.forward * _snapConfig.WallThickness);
            }
            // else if (t.GetComponent<ModularPiece>())
            //     offset = new Vector3(0, t.localScale.y / 2, 0); // Adjust for wall height

            Vector3 snappedPos = new Vector3(
                Mathf.Round((t.position.x) / _snapConfig.GridSize.x) * _snapConfig.GridSize.x,
                Mathf.Round((t.position.y) / _snapConfig.GridSize.y) * _snapConfig.GridSize.y,
                Mathf.Round((t.position.z) / _snapConfig.GridSize.z) * _snapConfig.GridSize.z
            ) + offset;

            if (t.position != snappedPos)
            {
                Undo.RecordObject(t, "Snap Modular");
                t.position = snappedPos;
            }
        }
    }
}
