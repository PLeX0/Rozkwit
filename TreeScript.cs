using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeScript : MonoBehaviour
{
    public Crosshair crosshair;
    public GameObject tree;
    public GameObject stump;
    public Apple[] apple = new Apple[9];
    public float MaxHealth = 1000f;
    public float health = 1000f;
    public float cooldown = 40f;
    public string name;
    public Player player;

    public float hitCooldown;

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        hitCooldown = player.attackSpeed;
        name = GetComponent<Transform>().name;
        stump.GetComponent<MeshCollider>().enabled = false;
        stump.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.isCutting == false && crosshair.onCrosshair != name && !Input.GetKey(KeyCode.Mouse0))
        {
            hitCooldown = player.attackSpeed;
        } 
       
        if (crosshair.onCrosshair == name && Input.GetKey(KeyCode.Mouse0))
        {
            
            player.isCutting = true;
            if (hitCooldown.Equals(player.attackSpeed))
                hitCooldown -= Time.deltaTime;
            else if (!hitCooldown.Equals(player.attackSpeed) && hitCooldown > 0)
                hitCooldown -= Time.deltaTime;
            else if (hitCooldown <= 0)
            {
                health -= player.attack;
                Debug.Log(health);
                hitCooldown = player.attackSpeed;
            }
        }
        else
        {
            player.isCutting = false;
        }
            
        
        if(health<=0)
        {
            tree.GetComponent<MeshCollider>().enabled = false;
            tree.GetComponent<MeshRenderer>().enabled = false;
            cooldown -= Time.deltaTime;
            stump.GetComponent<MeshCollider>().enabled = true;
            stump.GetComponent<MeshRenderer>().enabled = true;
        }

        if(cooldown<=0)
        {
            tree.GetComponent<MeshRenderer>().enabled = true;
            tree.GetComponent<MeshCollider>().enabled = true;
            health = MaxHealth;

            apple[0].OdNowa();
            apple[1].OdNowa();
            apple[2].OdNowa();
            apple[3].OdNowa();
            apple[4].OdNowa();
            apple[5].OdNowa();
            apple[6].OdNowa();
            apple[7].OdNowa();
            apple[8].OdNowa();
            
            cooldown = 40f;
            stump.GetComponent<MeshCollider>().enabled = false;
            stump.GetComponent<MeshRenderer>().enabled = false;
            
        }

        if (player.isCutting == true)
        {
            crosshair.circleBar.gameObject.active = true;
            crosshair.circleBar.fillAmount = 1-(health/1000);
        }
        else if (player.isCutting == false)
        {
           crosshair.circleBar.gameObject.active = false;
        }
    }
}
