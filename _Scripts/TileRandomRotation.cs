using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
    }
}
