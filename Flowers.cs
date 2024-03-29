using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flowers : MonoBehaviour
{
    public GameObject objectToLook;
    public Crosshair crosshair;
    public string name;
    public float refreshCooldown = 20f;
    public GameObject text;
    public ItemSorterInEq itemSort;
    public int iconId;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        name = GetComponent<Transform>().name;
    }

    // Update is called once per frame
    void Update()
    {

        if (crosshair.onCrosshair==name)
        {
            text.SetActive(true);
            text.transform.LookAt(objectToLook.transform);
        }
        else if(crosshair.onCrosshair != name)
        {
            text.SetActive(false);
        }

        if(crosshair.onCrosshair==name && Input.GetKeyDown(KeyCode.E))
        {
            
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            text.SetActive(false);
            itemSort.ItemPickUp(iconId, 1);
        }    

        if(GetComponent<MeshRenderer>().enabled == false && GetComponent<MeshCollider>().enabled == false)
        {
            refreshCooldown -= Time.deltaTime;
        }

        if (refreshCooldown <= 0)
        {
            refreshCooldown = 20f;
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshCollider>().enabled = true;
        }
    }
}
