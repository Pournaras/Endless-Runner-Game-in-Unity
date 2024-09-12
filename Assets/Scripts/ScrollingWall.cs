using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingWall : MonoBehaviour
{
    public float scrollspeed;
    private Rigidbody2D rb;

    //GameObject obj;

    [SerializeField]
    public static float speed;
    [SerializeField]
    private Transform neighbour;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //obj = GameObject.FindGameObjectWithTag("SpeedOmeter");

    }

    // Update is called once per frame
    void Update()
    {
        //speed = obj.GetComponent<SpeedOmeter>().wallSpeed;
        rb.velocity = new Vector2(-speed, 0);
    }

    public void Move()
    {
        transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);

    }

    public void SnapToNeighbour()
    {
        transform.position = new Vector2(neighbour.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ResetTrigger")
        {
            SnapToNeighbour();
        }
    }


}
