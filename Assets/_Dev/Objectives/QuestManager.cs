using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestData> _allQuests;
    [SerializeField] private List<Quest> _quests = new();

    public static QuestManager Instance;

    private void Awake()
    {
        Instance = this;
        foreach (var questData in _allQuests)
        {
            _quests.Add(new Quest(questData, QuestStatus.IN_PROGRESS));
        }
    }

    public void UpdateQuests()
    {
        foreach (var quest in _quests)
        {
            quest.UpdateQuest();
        }
    }

    public void AddQuest(QuestData questData)
    {
        _quests.Add(new Quest(questData, QuestStatus.IN_PROGRESS));
        UpdateQuests();
    }
}
