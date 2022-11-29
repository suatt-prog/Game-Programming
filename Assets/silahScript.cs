using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class silahScript : MonoBehaviour
{
    public float mouse_hareketi;
    [SerializeField] GameObject mermi;
    [SerializeField] GameObject clone_mermi;
    [SerializeField] GameObject silah_ucu;
    public List<GameObject> mermi_list;
   
    Vector3 silah_yonu;  // silahýn sadece z rotasyonunu deðiþtireceðiz buna göre bir vektör tanýmlamasý yaptým
    
    public Vector3 silah_rotasyon , silah_ucu_pozisyon , silah_pozisyon;
    public float mesafe, Zrotasyonu , yeniZ;

    void Start()
    {
        silah_yonu = new Vector3(0.0f, 0.0f, 5.0f);
        silah_ucu = transform.Find("silahUcu").gameObject;
        silah_ucu_pozisyon = new Vector3(0, 0, 0);
        silah_pozisyon = new Vector3(0, 0, 0);
    }

    bool kontrol = false;
 
    void Update()
    {

        silah_ucu_pozisyon = silah_ucu.transform.position;
        silah_pozisyon = transform.position;
        

            if (transform.parent != null)
            {
                if (true)
                {
                    
                    //Debug.Log(mouse_hareketi);
                    mouse_hareketi = Input.GetAxis("Mouse Y");
                    //Debug.Log(mouse_hareketi);
                    silah_rotasyon = mouse_hareketi * silah_yonu;
                    //Debug.Log(silah_rotasyon);
                    if (mouse_hareketi < 0 && transform.localRotation.z >= -0.10f )
                    {
                        transform.rotation *= Quaternion.Euler(silah_rotasyon);
                    }
                    else if (mouse_hareketi > 0 && transform.localRotation.z <= 0.55)
                    {
                        transform.rotation *= Quaternion.Euler(silah_rotasyon);
                    }
                   
                    

                  
                    
                }

                
             Vector3 mermi_olusma_pozisyonu = new Vector3(silah_ucu.transform.position.x, silah_ucu.transform.position.y, transform.position.z);
                if(Input.GetButtonDown("Fire1"))
                {
                kontrol = true;
                clone_mermi = Instantiate(mermi, mermi_olusma_pozisyonu, Quaternion.identity);
                clone_mermi.transform.rotation *= transform.rotation;
                }

                if(kontrol)
                {
                clone_mermi.transform.position += clone_mermi.transform.rotation * new Vector3(20,0,0) * Time.deltaTime;
                
                }


        }





    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Oyuncu"))
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }
}
