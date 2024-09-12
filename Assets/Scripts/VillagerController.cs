using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour
{
    public GameObject DisableStanding;
    public GameObject DisableBoots;
    public GameObject EnableDown;
    public GameObject DisableShadow;

    GameObject obj;

    public float speed;
    private int punched = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        obj = GameObject.FindGameObjectWithTag("SpeedOmeter");
    }

    // Update is called once per frame
    void Update()
    {
        speed = obj.GetComponent<SpeedOmeter>().villagerSpeed;
      
        if(punched == 1)
        {
            speed -= 0.4f;
        }
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }

         if ( (collision.tag == "Player" || collision.tag == "Punch" ) && punched == 0)
        {
            GetComponent<AudioSource>().Play();

            GetPunched();
        }
    }

    public void GetPunched()
    {
        punched = 1;
        speed -= 0.4f;
        DisableStanding.SetActive(false);
        DisableBoots.SetActive(false);
        DisableShadow.SetActive(false);
        EnableDown.SetActive(true);
        
    }


}