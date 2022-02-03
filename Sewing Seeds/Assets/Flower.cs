using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Vector3 Scale, scalechange;
    public float growing = 0;



    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (growing < 100)
        {
            growing += 0.01f;
            grow();
        }
    }

    private void grow()
    {
        scalechange = new Vector3(0.0001f, 0.0001f, 0.0001f);
        gameObject.transform.localScale += scalechange;


    }
}
