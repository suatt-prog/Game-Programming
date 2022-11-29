using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    public int count=0;
    // Update is called once per frame
    void Update()
    {
        //transform.rotation*=Quaternion.Euler(GameObject.Find("Player").transform.position);
        if(GameObject.Find("Player").transform.position.z!=10.0f){
            if(count<10){
                rb.AddForce((GameObject.Find("Player").transform.position-transform.position)*5);
                count++;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(GameObject.Find("Player").transform.position.z!=10.0f){
            if(collisionInfo.gameObject.tag=="Oyuncu")
            {
                Destroy(this.gameObject);
            }
            if (collisionInfo.gameObject.tag == "taban")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
