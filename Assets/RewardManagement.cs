using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardManagement : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;

    private Hitbox hitbox;

    private void Start()
    {
        
    }
    private void Update()
    {
        coinText.text = coinCount.ToString();

        if(hitbox.animalHp == 100)
        {
            coinCount++;
        }
    }
}
