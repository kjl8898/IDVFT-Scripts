using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Camera cam;

    public AudioClip buyBuilding;
    AudioSource audioSource;

    ResourceManager resMan;
    EventManager evMan;

    [Header("Building Costs")]
    public int plainsWoodCost = 1;
    public int plainsPopCost = 2;
    public int forestWoodCost = 3;
    public int forestPopCost = 4;
    public int hillsWoodCost = 5;
    public int hillsPopCost = 6;
    public int coastWoodCost = 7;
    public int coastPopCost = 8;

    [Header("Building Tiles")]
    public GameObject Plains_H;
    public GameObject Plains_F;
    public GameObject Plains_B;

    public GameObject Forest_LM;
    public GameObject Forest_HG;
    public GameObject Forest_SD;

    public GameObject Hills_M;
    public GameObject Hills_T;
    public GameObject Hills_SH;

    public GameObject Coast_F;
    public GameObject Coast_M;
    public GameObject Coast_SR;

    [Header("Info Panels")]
    public GameObject PlainsInfo;
    public GameObject ForestInfo;
    public GameObject HillsInfo;
    public GameObject CoastInfo;


    // Start is called before the first frame update
    void Start()
    {
        resMan = GetComponent<ResourceManager>();
        evMan = GetComponent<EventManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Creates a raycast from the camera to the mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && !evMan.gameOver)
        {
            GameObject tile = hit.transform.gameObject;

            if(tile.tag == "Plains" && !PlainsInfo.activeSelf)
            {
                PlainsInfo.SetActive(true);
                ForestInfo.SetActive(false);
                HillsInfo.SetActive(false);
                CoastInfo.SetActive(false);
            }
            if (tile.tag == "Forest" && !ForestInfo.activeSelf)
            {
                PlainsInfo.SetActive(false);
                ForestInfo.SetActive(true);
                HillsInfo.SetActive(false);
                CoastInfo.SetActive(false);
            }
            if (tile.tag == "Hills" && !HillsInfo.activeSelf)
            {
                PlainsInfo.SetActive(false);
                ForestInfo.SetActive(false);
                HillsInfo.SetActive(true);
                CoastInfo.SetActive(false);
            }
            if (tile.tag == "Coast" && !CoastInfo.activeSelf)
            {
                PlainsInfo.SetActive(false);
                ForestInfo.SetActive(false);
                HillsInfo.SetActive(false);
                CoastInfo.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                switch(tile.tag)
                {
                    case "Plains":
                        if(resMan.wood >= plainsWoodCost
                            && resMan.pop >= plainsPopCost)
                        {
                            resMan.wood -= plainsWoodCost;
                            resMan.pop -= plainsPopCost;

                            GenerateBuilding(tile, Random.Range(0, 3));
                        }
                        break;

                    case "Forest":
                        if(resMan.wood >= forestWoodCost
                            && resMan.pop >= forestPopCost)
                        {
                            resMan.wood -= forestWoodCost;
                            resMan.pop -= forestPopCost;

                            GenerateBuilding(tile, Random.Range(3, 6));
                        }
                        break;

                    case "Hills":
                        if(resMan.wood >= hillsWoodCost
                            && resMan.pop >= hillsPopCost)
                        {
                            resMan.wood -= hillsWoodCost;
                            resMan.pop -= hillsPopCost;

                            GenerateBuilding(tile, Random.Range(6, 9));
                        }
                        break;

                    case "Coast":
                        if (resMan.wood >= coastWoodCost
                            && resMan.pop >= coastPopCost)
                        {
                            resMan.wood -= coastWoodCost;
                            resMan.pop -= coastPopCost;

                            GenerateBuilding(tile, Random.Range(9, 12));
                        }
                        break;
                }
            }
        }
    }

    public void GenerateBuilding(GameObject tile, int building)
    {
        audioSource.PlayOneShot(buyBuilding);

        resMan.lastPurchaseDate = resMan.day;

        switch (building)
        {
            case 0:
                Instantiate(Plains_H, tile.transform.position, tile.transform.rotation);
                resMan.numHouse++;
                break;
            case 1:
                Instantiate(Plains_F, tile.transform.position, tile.transform.rotation);
                resMan.numFarm++;
                break;
            case 2:
                Instantiate(Plains_B, tile.transform.position, tile.transform.rotation);
                resMan.numBarracks++;
                break;
            case 3:
                Instantiate(Forest_LM, tile.transform.position, tile.transform.rotation);
                resMan.numLumberMill++;
                break;
            case 4:
                Instantiate(Forest_HG, tile.transform.position, tile.transform.rotation);
                resMan.numHuntingGround++;
                break;
            case 5:
                Instantiate(Forest_SD, tile.transform.position, tile.transform.rotation);
                resMan.numSmuggleDen++;
                break;
            case 6:
                Instantiate(Hills_M, tile.transform.position, tile.transform.rotation);
                resMan.numMine++;
                break;
            case 7:
                Instantiate(Hills_T, tile.transform.position, tile.transform.rotation);
                resMan.numTower++;
                break;
            case 8:
                Instantiate(Hills_SH, tile.transform.position, tile.transform.rotation);
                resMan.numSteppeHouse++;
                break;
            case 9:
                Instantiate(Coast_F, tile.transform.position, tile.transform.rotation);
                resMan.numFish++;
                break;
            case 10:
                Instantiate(Coast_M, tile.transform.position, tile.transform.rotation);
                resMan.numMarket++;
                break;
            case 11:
                Instantiate(Coast_SR, tile.transform.position, tile.transform.rotation);
                resMan.numSeaRaider++;
                break;
        }

        Destroy(tile);
    }
}
