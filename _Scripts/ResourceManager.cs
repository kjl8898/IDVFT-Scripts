using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    EventManager evMan;

    float time;
    public int secPerDay = 3;
    public int day = 1;
    public int lastPurchaseDate = 0;

    [Header("Resources and Production")]
    public int foodTotal = 10;
    public int foodChangeRate = 0;
    public int goldTotal = 10;
    public int goldChangeRate = 0;

    public int wood = 10;
    public int woodChangeRate = 0;
    public int pop = 5;
    public int popChangeRate = 0;

    public int military = 50;
    public int militaryChangeRate = 0;

    [Header("Buildings")]
    public int castlePopProd = 1;
    public int castleFoodUse = 1;
    public int castleGoldUse = 1;

    public int numHouse = 0;
    public int numFarm = 0;
    public int numBarracks = 0;

    public int numLumberMill = 0;
    public int numHuntingGround = 0;
    public int numSmuggleDen = 0;

    public int numMine = 0;
    public int numTower = 0;
    public int numSteppeHouse = 0;

    public int numFish = 0;
    public int numMarket = 0;
    public int numSeaRaider = 0;

    [Header("Building Production Stats")]
    public int housePopProd = 1;
    public int houseGoldProd = 0;
    public int houseFoodUse = 1;

    public int farmFoodProd = 2;

    public int barracksMilitaryProd = 1;
    public int barracksGoldUse = 1;

    public int lumberWoodProd = 2;

    public int huntingFoodProd = 4;
    public int huntingGoldUse = 1;

    public int smugglerGoldProd = 2;
    public int smugglerMilitaryUse = 1;

    public int mineGoldProd = 3;
    public int mineMilitaryUse = 2;

    public int towerGoldUse = 3;
    public int towerMilitaryProd = 2;

    public int steppePopProd = 5;
    public int steppeGoldProd = 0;
    public int steppeFoodUse = 4;
    public int steppeMilitaryUse = 2;

    public int fishingFoodProd = 6;
    public int fishingGoldUse = 4;

    public int marketGoldProd = 4;
    public int marketWoodProd = 4;
    public int marketMilitaryUse = 3;

    public int raiderMilitaryProd = 3;
    public int raiderFoodUse = 6;


    // Start is called before the first frame update
    void Start()
    {
        evMan = GetComponent<EventManager>();

        time = Time.time;
        numLumberMill = 1;
        numHouse = 1;

        CalculateChangeRates();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= (time + secPerDay) && !evMan.gameOver)
        {
            day++;

            DailyResources();
            evMan.EventCheck();

            time = Time.time;
        }
    }

    // Daily Resources
    //      Applies all income and deductions for the day.
    void DailyResources()
    {
        CalculateChangeRates();

        foodTotal += foodChangeRate;
        goldTotal += goldChangeRate;
        wood += woodChangeRate;
        pop += popChangeRate;
        military += militaryChangeRate;
    }

    void CalculateChangeRates()
    {
        foodChangeRate =
            -castleFoodUse
            - (houseFoodUse * numHouse)
            + (farmFoodProd * numFarm)
            + (huntingFoodProd * numHuntingGround)
            - (steppeFoodUse * numSteppeHouse)
            + (fishingFoodProd * numFish)
            - (raiderFoodUse * numSeaRaider);

        goldChangeRate =
            - castleGoldUse
            - (barracksGoldUse * numBarracks)
            - (huntingGoldUse * numHuntingGround)
            + (smugglerGoldProd * numSmuggleDen)
            + (mineGoldProd * numMine)
            - (towerGoldUse * numTower)
            - (fishingGoldUse * numFish)
            + (marketGoldProd * numMarket);

        woodChangeRate =
            + (lumberWoodProd * numLumberMill)
            + (marketWoodProd * numMarket);

        popChangeRate =
            + castlePopProd
            + (housePopProd * numHouse)
            + (steppePopProd * numSteppeHouse);

        militaryChangeRate =
            + (barracksMilitaryProd * numBarracks)
            - (smugglerMilitaryUse * numSmuggleDen)
            - (mineMilitaryUse * numMine)
            + (towerMilitaryProd * numTower)
            - (steppeMilitaryUse * numSteppeHouse)
            - (marketMilitaryUse * numMarket)
            + (raiderMilitaryProd * numSeaRaider);
    }
}
