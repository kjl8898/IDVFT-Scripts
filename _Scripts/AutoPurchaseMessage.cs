using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPurchaseMessage : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("HideMessage", 3);
    }

    void HideMessage()
    {
        gameObject.SetActive(false);
    }
}
