namespace SimpleRPG.Game.Engine.Models;
public class QuestStatus
{
    public QuestStatus(Quest quest)
    {
        PlayerQuest = quest;
    }

    public Quest PlayerQuest { get; set; }

    public bool IsCompleted { get; set; } = false;
}
