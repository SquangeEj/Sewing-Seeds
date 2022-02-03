using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Vector3 Scale, scalechange;
    public float growing = 0;
    public float maxgrow = 100;
    public float growspeed = 1;
    

    

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        growspeed = ((growspeed * 1000) * Random.Range(0.1f, 1.5f));

    }
    // Update is called once per frame
    void Update()
    {
        if (growing < maxgrow)
        {
            growing += maxgrow /growspeed ; //lower growspeed = faster growing
            grow();
        }
    }

    private void grow()
    {
        scalechange = new Vector3(0.0001f, 0.0001f, 0.0001f);
        gameObject.transform.localScale += scalechange;


    }
}
