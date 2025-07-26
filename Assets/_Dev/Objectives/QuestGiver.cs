using System;
using UnityEngine;
using Wannabuh.FPSController;

public class QuestGiver : MonoBehaviour, IInteractable
{
    private QuestBank _questBank;

    private void Awake()
    {
        _questBank = GetComponentInParent<QuestBank>();
    }

    public void Interact(FPSController fpsController)
    {
        if (!_questBank.QuestsAvailable()) return;
        
        QuestManager.Instance.AddQuest(_questBank.FetchQuest());
    }
}
