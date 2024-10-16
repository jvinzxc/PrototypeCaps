using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlmanacScript : MonoBehaviour
{
    public GameObject almanacPanel;

    //animals
    public GameObject sheep;
    public GameObject blksheep;

    public GameObject pig;
    public GameObject blkpig;

    public GameObject cow;
    public GameObject blkcow;

    public GameObject chicken;
    public GameObject blkchicken;
    private int animalNum = 0;
    public TMP_Text text;

    //diseases
    private string sheeps;
    private string cows;
    private string pigs;
    private string chickens;

    public GameObject cpv;
    public GameObject blkcpv;

    public GameObject cd;
    public GameObject blkcd;

    public GameObject fp;
    public GameObject blkfp;

    public GameObject m;
    public GameObject blkm;

    public GameObject bvd;
    public GameObject blkbvd;

    //cures

    public GameObject eytenwan;
    public GameObject eytenwanlock;

    public GameObject siksenwan;
    public GameObject siksenwanlock;

    public GameObject paybenwan;
    public GameObject paybenwanlock;

    public GameObject efpi;
    public GameObject efpilock;

    public GameObject bsg;
    public GameObject bsglock;

    public GameObject doxy;
    public GameObject doxylock;

    public GameObject enro;
    public GameObject enrolock;

    public GameObject marbo;
    public GameObject marbolock;


    private void Start()
    {
        animalNum = 0;
        PlayerPrefs.SetInt("anum", animalNum);

    }
    void Update()
    {
        if (almanacPanel.activeSelf)
        {
            // Pause the game by setting timeScale to 0
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game by setting timeScale back to 1
            Time.timeScale = 1;
        }

       

        
    }

    public void SheepOkayClicked()
    {
        sheeps = "okay";
        PlayerPrefs.SetString("okay", sheeps);
        string sheepLock = PlayerPrefs.GetString("okay");

        if (sheepLock == "okay")
        {
            sheep.SetActive(true);
            blksheep.SetActive(false);

            animalNum++;
            PlayerPrefs.SetInt("anum", animalNum);
            text.text = animalNum.ToString();

            if (animalNum == 1)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
            else if (animalNum == 2)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
        }
    }

    public void PigsOkayClicked()
    {
        pigs = "okay";
        PlayerPrefs.SetString("okay", pigs);
        string pigsLock = PlayerPrefs.GetString("okay");


        if (pigsLock == "okay")
        {
            pig.SetActive(true);
            blkpig.SetActive(false);

            animalNum++;
            PlayerPrefs.SetInt("anum", animalNum);
            text.text = animalNum.ToString();

            if (animalNum == 1)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
            else if (animalNum == 2)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
            else if (animalNum == 3)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
        }
    }
    public void CowOkayClicked()
    {
        cows = "okay";
        PlayerPrefs.SetString("okay", cows);
        string cowLock = PlayerPrefs.GetString("okay");
        if (cowLock == "okay")
        {
            cow.SetActive(true);
            blkcow.SetActive(false);

            animalNum++;
            PlayerPrefs.SetInt("anum", animalNum);
            text.text = animalNum.ToString();

            if (animalNum == 1)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
            else if (animalNum == 2)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
            else if (animalNum == 3)
            {
                int curNum = PlayerPrefs.GetInt("anum");
                int upNum = curNum++;
                PlayerPrefs.SetInt("anum", upNum);
            }
        }
    }
    public void ChickenOkayBtn()
    {
        chicken.SetActive(true);
        blkchicken.SetActive(false);

        animalNum++;
        PlayerPrefs.SetInt("anum", animalNum);
        text.text = animalNum.ToString();

        if (animalNum == 1)
        {
            int curNum = PlayerPrefs.GetInt("anum");
            int upNum = curNum++;
            PlayerPrefs.SetInt("anum", upNum);
        }
        else if (animalNum == 2)
        {
            int curNum = PlayerPrefs.GetInt("anum");
            int upNum = curNum++;
            PlayerPrefs.SetInt("anum", upNum);
        }
        else if (animalNum == 3)
        {
            int curNum = PlayerPrefs.GetInt("anum");
            int upNum = curNum++;
            PlayerPrefs.SetInt("anum", upNum);
        }
    }
    public void diseaseBtnOkay()
    {
        int anumk = PlayerPrefs.GetInt("anum");
        if (anumk == 3)
        {
            cpv.SetActive(true);
            blkcpv.SetActive(false);

            cd.SetActive(true);
            blkcd.SetActive(false);

            fp.SetActive(true);
            blkfp.SetActive(false);

            m.SetActive(true);
            blkm.SetActive(false);

            bvd.SetActive(true);
            blkbvd.SetActive(false);
        }

    }

    public void cureBtnOkay()
    {
        int nm = PlayerPrefs.GetInt("anum");
        if (nm == 4)
        {
            eytenwan.SetActive(true);
            eytenwanlock.SetActive(false);

            siksenwan.SetActive(true);
            siksenwanlock.SetActive(false);

            paybenwan.SetActive(true);
            paybenwanlock.SetActive(false);

            efpi.SetActive(true);
            efpilock.SetActive(false);

            bsg.SetActive(true);
            bsglock.SetActive(false);

            doxy.SetActive(true);
            doxylock.SetActive(false);

            enro.SetActive(true);
            enrolock.SetActive(false);

            marbo.SetActive(true);
            marbolock.SetActive(false);

        }
    }
}
