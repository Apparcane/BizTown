using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public Material mt;
    public float mtS = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mt.mainTextureOffset = new Vector2(Time.time * mtS * Time.deltaTime, 0f);
        Vector3 pos = rb.position;
        rb.position += Vector3.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
