using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSorterInEq : MonoBehaviour
{
    public Image[] itemSlot = new Image[36];
    public bool[] isEmpty = new bool[36];
    public Sprite[] itemSprite = new Sprite[1];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemPickUp(int id, int count)
    {
        for (int i = 0; i<36; i++)
        {
            if(isEmpty[i] == true)
            {
                itemSlot[i].sprite = itemSprite[id];
                isEmpty[i] = false;
                break;
            }
            
        }
    }
}
