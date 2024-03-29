using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public float range = 2f;
    public string onCrosshair;
    public Image circleBar;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        circleBar.gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            onCrosshair = hit.transform.name;
        }
        else
        {
            onCrosshair = null;
        }

       
    }
}
