using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Pickups/Health")]
public class HealthData : ScriptableObject
{
    [field: SerializeField] public float Health;

    public void Apply()
    {
        
    }
}
