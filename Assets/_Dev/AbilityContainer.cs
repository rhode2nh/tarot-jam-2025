using UnityEngine;

public class AbilityContainer : MonoBehaviour
{
    [SerializeField] private AbilityData _abilityData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<AbilityManager>(out var abilityManager))
        {
            _abilityData.Realize(other.gameObject);
            Destroy(gameObject);
        }
    }
}
