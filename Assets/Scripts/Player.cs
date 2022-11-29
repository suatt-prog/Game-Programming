using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject cam1;
    public GameObject cam2;
    Vector3 x_ekseninde_saga_hareket_vektoru;
    Vector2 y_ekseninde_hareket;
    float hiz_degiskeni = 5.0f;
    float yukari_hiz_degiskeni = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        //İki farklı kamera koydum birisi oyunu birisi pause menüsünü gösteriyor
        //İlk başta pause menüsü kamerası açıldığı için onu oyun kamerasını açtırıyorum
        cam1.SetActive(true);
        cam2.SetActive(false);
        rb=GetComponent<Rigidbody2D>();
        x_ekseninde_saga_hareket_vektoru = new Vector3(1.0f, 0.0f, 0.0f);
        y_ekseninde_hareket = new Vector2(0.0f, 1.0f);
        StartCoroutine(spawn());
    }
    public GameObject kus;
    float speed=3.5f;
    // Update is called once per frame
    float zaman=-1.0f;
    public int count=0;
    public bool dur=false;
    bool lose=false;
    bool presshold=false;
    void Update()
    {
        float hold=Input.GetAxis("Cancel");
        if(zaman<0 && !lose){
            //print(hold+"hold");
            if (transform.position.x > 50f)
            {
                cam2.SetActive(true);
                cam1.SetActive(false);
                dur = true;
                transform.position = new Vector3(-5f, transform.position.y, 0f);
            }
            if(hold==1.0f && !presshold){
                count++;
            }
            //print(count+"count");
            if(hold==1.0f && count%2==0 && !presshold){
                dur=false;
                //dur değişkenine diğer scriptlerde erişemiyorum o yüzden kullanılmayan transform.z
                //değerini 10 a eşitleyip dur değeri gibi kullanacağım
                transform.position = new Vector3(transform.position.x,transform.position.y,0.0f);
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
            if(hold==1.0f && count%2==1){
                dur=true;
                //dur değişkenine diğer scriptlerde erişemiyorum o yüzden kullanılmayan transform.z
                //değerini 10 a eşitleyip dur değeri gibi kullanacağım
                transform.position=new Vector3(transform.position.x,transform.position.y,10.0f);
                cam1.SetActive(false);
                cam2.SetActive(true);
                presshold=true;
            }
            zaman=0.13f;
        }
        if(Input.GetAxis("Cancel")!=1){
            presshold=false;
        }
        zaman-=Time.deltaTime;
        if(!dur){
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                // playerRigidbody.AddForce(x_ekseninde_saga_hareket_vektoru * hiz_degiskeni);
                transform.position += x_ekseninde_saga_hareket_vektoru * hiz_degiskeni * Time.deltaTime;
            }



            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                //transform.rotation = quaternion.Euler(0.0f, 180.0f, 0.0f);
                transform.position += -x_ekseninde_saga_hareket_vektoru * hiz_degiskeni * Time.deltaTime;
            }


            if ((Input.GetAxisRaw("Vertical") == 1) && Mathf.Approximately(rb.velocity.y, 0))
            {

                rb.AddForce(y_ekseninde_hareket * yukari_hiz_degiskeni, ForceMode2D.Impulse);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D info){
        if(info.gameObject.tag=="bomb"){
            dur=true;
            lose=true;
            cam2.SetActive(true);
            cam1.SetActive(false);
        }
    }
    public void devam(){
        if(!lose){
            count++;
            transform.position=new Vector3(transform.position.x,transform.position.y,0.0f);
            cam1.SetActive(true);
            cam2.SetActive(false);
            dur=false;
        }
    }
    public void yeniden(){
        transform.position = new Vector3(-5f, transform.position.y, 0f);
        Destroy(GameObject.Find("kus"));
        Destroy(GameObject.Find("bomb"));
        dur=false;
        lose=false;        
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
    IEnumerator spawn()
    {
        while(true){
            if(!dur){
                GameObject enemy=Instantiate(kus,new Vector3(transform.position.x+20f,Random.Range(1.5f,5.5f)),Quaternion.identity);
                enemy.transform.rotation = Quaternion.Euler(0f,0f,-90f);    
            }
            yield return new WaitForSeconds(4.0f);
        }
    }
}