using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    ThorQuestSystem thor;
    public int requiredAmount;
    public int currentAmount;


    #region Quest Goal Checker
    public bool isReached()
    {
        return (this.currentAmount >= this.requiredAmount);
    }
    public bool isCompleted()
    {
        return (this.currentAmount == this.requiredAmount);
    }
    #endregion

    #region Quest Goals
    public void Destroyed()
    {
        if (goalType == GoalType.Destroy)
            currentAmount = thor.questCurrentAmount;
            requiredAmount = thor.questCurrentAmount;
            currentAmount--;
    }

    public void Captured()
    {
        if (goalType == GoalType.Capture)
            currentAmount = thor.questCurrentAmount;
            requiredAmount = thor.questRequiredAmount;
            currentAmount++;
    }

    public void Defended()
    {
        if (goalType == GoalType.Defend)
        {
            currentAmount = thor.questCurrentAmount;
            requiredAmount = thor.questRequiredAmount;
        }
    }

    public void Created()
    {
        if (goalType == GoalType.Create)
        {
            currentAmount = thor.questCurrentAmount;
            requiredAmount = thor.questRequiredAmount;
            currentAmount++;
        }
    }

    #endregion
}
public enum GoalType
{
    Destroy,
    Capture,
    Defend,
    Create
}
