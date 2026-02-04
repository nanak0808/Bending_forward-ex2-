using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionController : MonoBehaviour
{
    public float expansionRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.z = temp.z * expansionRate;
        transform.position = temp;
    }
}
