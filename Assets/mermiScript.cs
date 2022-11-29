using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiScript : MonoBehaviour
{
    public GameObject mermi_clone;
    public GameObject kus;
    public float timer = 0.0f;
    public int seconds;
    public Vector3 kus_ozisyon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(coll.IsTouching(transform.Find("taban").gameObject));
        transform.position += transform.rotation * new Vector3(20, 0, 0) * Time.deltaTime;
        timer += Time.deltaTime;
        // turn seconds in float to int
        seconds = (int)(timer % 60);
        if (seconds > 2)
        {
            Destroy(this.gameObject);
        }
    }

}
