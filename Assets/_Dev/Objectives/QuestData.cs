using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/New Quest")]
public class QuestData : ScriptableObject
{
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [SerializeField] public List<RequirementData> Requirements = new();
}
