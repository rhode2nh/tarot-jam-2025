using UnityEngine;

public class QuestBank : MonoBehaviour
{
    [SerializeField] private SerializableStack<QuestData> _quests = new();

    public QuestData FetchQuest()
    {
        return _quests.Pop();
    }

    public bool QuestsAvailable()
    {
        return _quests.Count > 0;
    }
}
