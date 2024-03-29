using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{


    public GameObject apple;
    public Rigidbody rb;
    public TreeScript tree;
    public float time;
    public Vector3 startPos;
    public Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        time = 30f;
        startRot = new Quaternion(apple.transform.rotation.x, apple.transform.rotation.y, apple.transform.rotation.z, apple.transform.rotation.w);
        startPos = new Vector3(apple.transform.position.x, apple.transform.position.y, apple.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (tree.health <= 0f)
            apple.active = false;

        time -= Time.deltaTime;
        if(time <= 0)
        {
            rb.isKinematic = false;
            
        }
        if(time <= 20f && time > 10f)
        {
            apple.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        if (time <= 10f && time > 1f)
        {
            apple.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
    }

    public void OdNowa()
    {

        apple.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        apple.active = true;
        time = 30f;
        apple.transform.position = startPos;
        apple.transform.rotation = startRot;
        rb.isKinematic = true;
    }
}
