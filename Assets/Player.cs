using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int gold = 0;

    public TextMeshProUGUI goldText;

    public QuestGiver quest;
    void Update()
    {
        goldText.text = gold.ToString();
        GoHeal();
    }
    public void GoHeal()
    {
        if (quest.isActive)
        {
            
            if (quest.goal.IsReached())
            {
                gold += quest.goldreward;
                quest.Complete();
            }
        }
    }

}    
