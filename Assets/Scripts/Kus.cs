using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kus : MonoBehaviour
{
    public GameObject bomb;
    Rigidbody2D rb;
    GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").transform.position.z!=10.0f){
            transform.position+=new Vector3(-0.02f,0f,0f);        
            if(transform.position.x< -45f){
                Destroy(this.gameObject);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "mermi")
        {
            print("vurdunuz player");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
    IEnumerator spawn()
    {
        while(true){
            if(GameObject.Find("Player").transform.position.z!=10.0f){
                enemy=Instantiate(bomb,transform.position,Quaternion.identity);
                enemy.transform.rotation=Quaternion.Euler(GameObject.Find("Player").transform.position);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
