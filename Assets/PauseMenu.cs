using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject crossHair;
    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject Ammo;
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject Coins;
    [SerializeField] GameObject Quest;
    public bool setting;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setting = !setting;
            if (setting == true)
            {
                Pause();
                Map();
                Cross();
                AmmoUI();
                Invent();
                pButton();
                OffCoinbar();
                OffQuestbar();
            }
            else
            {
                Resume();
                Mtrue();
                Ctrue();
                Atrue();
                Itrue();
                ptrue();
                OnCoinbar();
                OnQuestbar();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Map()
    {
        miniMap.SetActive(false);
    }
    public void Cross()
    {
        crossHair.SetActive(false);
    }
    public void Mtrue()
    {
        miniMap.SetActive(true);
    }
    public void Ctrue()
    {
        crossHair.SetActive(true);
    }
    public void AmmoUI()
    {
        Ammo.SetActive(false);
    }
    public void Atrue()
    {
        Ammo.SetActive(true);
    }
    public void Invent()
    {
        Inventory.SetActive(false);
    }
    public void Itrue()
    {
        Inventory.SetActive(true);
    }
    public void pButton()
    {
        pauseButton.SetActive(false);
    }
    public void ptrue()
    {
        pauseButton.SetActive(true);
    }
    public void OffCoinbar()
    {
        Coins.SetActive(false);
    }
    public void OnCoinbar()
    {
        Coins.SetActive(true);
    }
    public void OffQuestbar()
    {
        Quest.SetActive(false);
    }
    public void OnQuestbar()
    {
        Quest.SetActive(true);
    }
}
