using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal : MonoBehaviour
{
    public GoalType goalType;

    public int requirmentAmount = 3;
    public int currentAmount;

    public bool IsReached()
    {
        return(currentAmount == requirmentAmount);
    }
    public void AnimalHealed()
    {
        if(goalType == GoalType.Heal)
        {
            currentAmount++;
        }
    }
    public void AnimalRecued()
    {
        if (goalType == GoalType.Rescue)
        {
            currentAmount++;
        }
    }
    public void AnimalSleep()
    {
        if (goalType == GoalType.Sleep)
        {
            currentAmount++;
        }
    }
}
public enum GoalType
{
    Heal,
    Rescue,
    Sleep
}
