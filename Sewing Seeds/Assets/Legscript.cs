using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legscript : MonoBehaviour
{

    public Animator leg;
    // Start is called before the first frame update
    void Start()
    {
        leg.Play(0, -1, Random.value);
    }

   
}
