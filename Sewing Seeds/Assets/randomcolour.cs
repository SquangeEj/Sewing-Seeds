using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcolour : MonoBehaviour
{
    public Renderer[] rends;
    private float randomhue, randomsat, randomval, randomalpha;
    public float maxhue, minhue;
    void Start()
    {
        randomhue = Random.Range(minhue, maxhue);
        randomsat = Random.Range(0.0f, 1.0f);
        randomval = Random.Range(0.0f, 1.0f);
        randomalpha = Random.Range(0.0f, 1.0f);
        foreach (Renderer rend in rends)
        {
            rend.material.color = Random.ColorHSV(randomhue, randomhue, randomsat, randomsat, randomval, randomval, randomalpha, randomalpha);
        }
    }

  
    
}
