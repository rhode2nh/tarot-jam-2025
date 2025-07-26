using System.Linq;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public QuestData QuestData { get; private set; }
    public QuestStatus Status { get; private set; }

    public Quest(QuestData questData, QuestStatus status = QuestStatus.NOT_STARTED)
    {
        QuestData = questData;
        Status = status;
    }

    public void StartQuest()
    {
        Status = QuestStatus.IN_PROGRESS;
    }

    public void UpdateQuest()
    {
        if (Status == QuestStatus.NOT_STARTED) return;
        
        if (QuestData.Requirements.Any(requirement => !requirement.IsCompleted()))
        {
            Status = QuestStatus.IN_PROGRESS;
            return;
        }

        Debug.Log("Quest Completed!");
        Status = QuestStatus.COMPLETED;
    }
}

public enum QuestStatus
{
    NOT_STARTED,
    IN_PROGRESS,
    COMPLETED,
}