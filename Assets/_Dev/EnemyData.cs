using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/New Enemy")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
}
