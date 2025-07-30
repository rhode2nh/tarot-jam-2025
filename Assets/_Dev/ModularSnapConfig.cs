using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ModularSnapConfig", menuName = "Scriptable Objects/ModularSnapConfig")]
public class ModularSnapConfig : ScriptableObject
{
    [field: SerializeField] public Vector3 GridSize { get; private set; }
    [field: SerializeField] public float WallThickness { get; private set; }
    [field: SerializeField] public float FloorThickness { get; private set; }
    
    public void CalculateWalls()
    {
        List<ModularPiece> walls = FindObjectsByType<ModularPiece>(FindObjectsSortMode.None).Where(x => x.type == ModularPiece.PieceType.Wall || x.type == ModularPiece.PieceType.WallAcessory).ToList();
        foreach (ModularPiece wall in walls)
        {
            Vector3 pos = wall.transform.position;
            float x = Mathf.Round(pos.x);
            float z = Mathf.Round(pos.z);
            wall.transform.position = new Vector3(x, pos.y, z) + (wall.transform.forward * WallThickness);
        }
    }
    
    public void CalculateFloors()
    {
        List<ModularPiece> floors = FindObjectsByType<ModularPiece>(FindObjectsSortMode.None).Where(x => x.type == ModularPiece.PieceType.Floor).ToList();
        foreach (ModularPiece floor in floors)
        {
            Vector3 pos = floor.transform.position;
            float y = Mathf.Round(pos.y * 2f) / 2f;
            floor.transform.position = new Vector3(pos.x, y, pos.z) + (floor.transform.up * FloorThickness);
        }
    }
}
