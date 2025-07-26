using UnityEngine;
using Wannabuh.FPSController;

public class TarotCard : MonoBehaviour, IQuestTrigger
{
    [SerializeField] private TarotCardData cardData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>() != null)
        {
            CardManager.Instance.AddCard(cardData);
            UpdateQuests();
            Destroy(gameObject);
        }
    }

    public void UpdateQuests()
    {
        QuestManager.Instance.UpdateQuests();
    }
}
