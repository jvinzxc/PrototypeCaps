using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QuestGiver : MonoBehaviour
{
    public bool isActive;
    public int goldreward = 500;

    public Player player;
    public QuestGoal goal;

    public GameObject questWindow;
    public TextMeshProUGUI goldText;
    public GameObject completed;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        goldText.text = goldreward.ToString();
    }
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        isActive = true;
    }
    public void Complete()
    {
        isActive = false;
        completed.SetActive(true);
    }
}
