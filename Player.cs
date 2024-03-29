using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Controler controler;
    public bool isCutting;


    public float attackSpeed = 1f;
    public float attack = 100f;


    // Start is called before the first frame update
    void Start()
    {
        isCutting = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
