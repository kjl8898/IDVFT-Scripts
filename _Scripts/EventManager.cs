using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public AudioClip loseClip;
    public AudioClip winClip;
    AudioSource audioSource;

    public GameObject starvationMessage;
    public GameObject bankruptMessage;
    public GameObject raidedMessage;
    public GameObject overthrownMessage;
    public GameObject winMessage;

    ResourceManager resMan;
    TileManager tileManager;

    List<GameObject> openTilesList;
    public GameObject autoPurchaseMessage;

    public int daysUntilAutoPurchase = 5;

    public bool gameOver = false;

    bool goingBankrupt = false;
    int bankruptDate;

    bool starving = false;
    int starvationDate;

    // Start is called before the first frame update
    void Start()
    {
        resMan = GetComponent<ResourceManager>();
        audioSource = GetComponent<AudioSource>();
        tileManager = GetComponent<TileManager>();
    }

    public void EventCheck()
    {
        // Starvation Check
        if (!starving && resMan.foodTotal <= 0)
        {
            starving = true;
            starvationDate = resMan.day + 6;
        }
        else if (starving && resMan.day == starvationDate)
        {
            gameOver = true;
            starvationMessage.SetActive(true);
            audioSource.Stop();
            audioSource.PlayOneShot(loseClip);
        }
        else if (starving && resMan.foodTotal > 0)
        {
            starving = false;
        }

        // Bankruptcy Check
        if (!goingBankrupt && resMan.goldTotal <= 0)
        {
            goingBankrupt = true;
            bankruptDate = resMan.day + 6;
        }
        else if (goingBankrupt && resMan.day == bankruptDate)
        {
            gameOver = true;
            bankruptMessage.SetActive(true);
            audioSource.Stop();
            audioSource.PlayOneShot(loseClip);
        }
        else if (goingBankrupt && resMan.goldTotal > 0)
        {
            goingBankrupt = false;
        }

        // Raid/Overthrow Check
        if (resMan.military <= 0)
        {
            gameOver = true;
            raidedMessage.SetActive(true);
            audioSource.Stop();
            audioSource.PlayOneShot(loseClip);
        }
        if (resMan.military >= 100)
        {
            gameOver = true;
            overthrownMessage.SetActive(true);
            audioSource.Stop();
            audioSource.PlayOneShot(loseClip);
        }

        // Win Check
        if (resMan.day >= 30)
        {
            gameOver = true;
            winMessage.SetActive(true);
            audioSource.Stop();
            audioSource.PlayOneShot(winClip);
        }

        // Check Auto Purchase

        if(resMan.day >= (resMan.lastPurchaseDate + daysUntilAutoPurchase))
        {
            resMan.lastPurchaseDate = resMan.day;

            if(resMan.wood >= tileManager.coastWoodCost && resMan.pop >= tileManager.coastPopCost)
            {
                openTilesList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Coast"));

                resMan.wood -= tileManager.coastWoodCost;
                resMan.pop -= tileManager.coastPopCost;

                tileManager.GenerateBuilding(openTilesList[Random.Range(0, openTilesList.Count)], Random.Range(9, 12));
            }
            else if (resMan.wood >= tileManager.hillsWoodCost && resMan.pop >= tileManager.hillsPopCost)
            {
                openTilesList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Hills"));

                resMan.wood -= tileManager.hillsWoodCost;
                resMan.pop -= tileManager.hillsPopCost;

                tileManager.GenerateBuilding(openTilesList[Random.Range(0, openTilesList.Count)], Random.Range(6, 9));
            }
            else if (resMan.wood >= tileManager.forestWoodCost && resMan.pop >= tileManager.forestPopCost)
            {
                openTilesList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Forest"));

                resMan.wood -= tileManager.forestWoodCost;
                resMan.pop -= tileManager.forestPopCost;

                tileManager.GenerateBuilding(openTilesList[Random.Range(0, openTilesList.Count)], Random.Range(3, 6));
            }
            else if (resMan.wood >= tileManager.plainsWoodCost && resMan.pop >= tileManager.plainsPopCost)
            {
                openTilesList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Forest"));

                resMan.wood -= tileManager.plainsWoodCost;
                resMan.pop -= tileManager.plainsPopCost;

                tileManager.GenerateBuilding(openTilesList[Random.Range(0, openTilesList.Count)], Random.Range(0, 3));
            }

            autoPurchaseMessage.SetActive(true);
        }
    }
}
