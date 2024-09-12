using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public static float speed;
   
    private Rigidbody2D rb;

    public GameObject sprite;
    

    //GameObject obj;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //obj = GameObject.FindGameObjectWithTag("SpeedOmeter");

    }

    // Update is called once per frame
    void Update()
    {
        //speed = obj.GetComponent<SpeedOmeter>().obstacleSpeed;
        rb.velocity = new Vector2(-speed, 0);

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player" || collision.tag == "Punch")
        {
           

            sprite.SetActive(false);
            GetComponent<AudioSource>().Play();

          
        }
    }
}
