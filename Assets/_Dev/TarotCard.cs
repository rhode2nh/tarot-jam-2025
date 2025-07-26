using UnityEngine;
using Wannabuh.FPSController;

public class TarotCard : MonoBehaviour
{
    [SerializeField] private TarotCardData cardData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>() != null)
        {
            CardManager.Instance.AddCard(cardData);
            Destroy(gameObject);
        }
    }
    
}
