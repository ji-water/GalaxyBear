﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    
    Animator ani;
   

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetInteger("animation", 15);
    }

    /*
    // Update is called once per frame
    void Update()
    {
       // ani.SetInteger("animation", 15);
    }
    */
}
