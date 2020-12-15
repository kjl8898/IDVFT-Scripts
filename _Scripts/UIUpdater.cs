using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    ResourceManager resMan;

    public Text day;
    public Text wood;
    public Text woodChangeRate;
    public Text pop;
    public Text popChangeRate;
    public Text food;
    public Text foodChangeRate;
    public Text gold;
    public Text goldChangeRate;
    public Text military;
    public Text militaryChangeRate;

    // Start is called before the first frame update
    void Start()
    {
        resMan = GetComponent<ResourceManager>();

        woodChangeRate.color = Color.green;
        popChangeRate.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        day.text = resMan.day.ToString();
        wood.text = resMan.wood.ToString();
        woodChangeRate.text = resMan.woodChangeRate.ToString();
        pop.text = resMan.pop.ToString();
        popChangeRate.text = resMan.popChangeRate.ToString();


        food.text = resMan.foodTotal.ToString();
        if (resMan.foodTotal <= 0)
        {
            food.color = Color.red;
        }
        else
        {
            food.color = Color.white;
        }
        foodChangeRate.text = resMan.foodChangeRate.ToString();
        if (resMan.foodChangeRate <= 0)
        {
            foodChangeRate.color = Color.red;
        }
        else
        {
            foodChangeRate.color = Color.green;
        }

        gold.text = resMan.goldTotal.ToString();
        if (resMan.goldTotal <= 0)
        {
            gold.color = Color.red;
        }
        else
        {
            gold.color = Color.white;
        }
        goldChangeRate.text = resMan.goldChangeRate.ToString();
        if (resMan.goldChangeRate <= 0)
        {
            goldChangeRate.color = Color.red;
        }
        else
        {
            goldChangeRate.color = Color.green;
        }

        military.text = resMan.military.ToString();
        if(resMan.military >= 40 && resMan.military <= 60)
        {
            military.color = Color.green;
        }
        else if(resMan.military >= 20 && resMan.military <= 80)
        {
            military.color = Color.white;
        }
        else
        {
            military.color = Color.red;
        }

        militaryChangeRate.text = resMan.militaryChangeRate.ToString();
        if (resMan.militaryChangeRate < 0)
        {
            militaryChangeRate.color = Color.red;
        }
        else if (resMan.militaryChangeRate == 0)
        {
            militaryChangeRate.color = Color.white;
        }
        else
        {
            militaryChangeRate.color = Color.green;
        }

    }
}
