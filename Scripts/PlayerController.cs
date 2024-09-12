using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text EndText;
    public Text LifeCounter;
    public Text PointCounter;
    public Text VillagerCounter;

    public GameObject RestartB;
    public GameObject GoBackB;
    public GameObject ExitB;
    public GameObject PauseM;
    public GameObject Scroll;
    public GameObject BlueBeerIcon;
    public GameObject RedBeerIcon;

    public float speed;
    public bool punching;
    private float effect_time = 20;
    private bool redbeer = false;

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.15f;

    private int lf_counter = 3;
    private int pt_counter = 0;
    private int vil_counter = 0;
    private int highscore;
    private bool highscore_check = false;
    //public static bool vil_escape = false;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);

        EndText.text = "";
        LifeCounter.text = "Ζωές: 3";
        VillagerCounter.text = "Χωρικοί: 0";
        PointCounter.text = "Πόντοι: 0 (" + highscore.ToString() + ")";

        punching = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
        
        //Set Punch
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
        }

       
        //Punch timer
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;

            }
        }
        
    }

    void Move(Vector2 direction)
    {
        //Screen limit bottom
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Screen limit top
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f - 0.2f;
        min.x = min.x + 0.225f + 0.7f;


        max.y = max.y - 0.285f - 5.1f;
        min.y = min.y + 0.285f + 0.5f;

        //Get current position
        Vector2 pos = transform.position;

        //Calculate new position
        pos += direction * speed * Time.deltaTime;

        //New position inside screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Update position
        transform.position = pos;
    }
    
    //Collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Villager")
        {

            if(attacking)
            {
                GetComponent<AudioSource>().Play();

                if (redbeer) Score(20);
                else Score(10);
            }
            else
            {
                if (redbeer) Score(10);
                else Score(5);
            }

            vil_counter += 1;

            VillagerCounter.text = "Χωρικοί: " + vil_counter.ToString();

            //Win with 100 villagers
            if(vil_counter == 100)
            {
                End(0);
            }

        }

        if(collision.tag == "Obstacle")
        {
            lf_counter -= 1;

            LifeCounter.text = "Ζωές: " + lf_counter.ToString();

            Score(-10);

            if(lf_counter == 0)
            {
                End(1);
            }
        }

        if(collision.tag == "GreenBeer")
        {
            Score(50);
        }

        if(collision.tag == "BlueBeer")
        {
            Score(50);

            StartCoroutine(BlueBeerEffect());
        }

        if(collision.tag == "RedBeer")
        {
            Score(10);

            StartCoroutine(RedBeerEffect());
        }

        if(collision.tag == "GoldenBeer")
        {
            Score(100);

            lf_counter += 1;
            LifeCounter.text = "Ζωές: " + lf_counter.ToString();
        }

    }
    
    IEnumerator BlueBeerEffect()
    {
        speed += 2;
        BlueBeerIcon.SetActive(true);

        yield return new WaitForSeconds(effect_time);

        BlueBeerIcon.SetActive(false);
        speed -= 2;
    }

    IEnumerator RedBeerEffect()
    {
        redbeer = true;
        RedBeerIcon.SetActive(true);

        yield return new WaitForSeconds(effect_time);

        RedBeerIcon.SetActive(false);
        redbeer = false;

    }

    public void End(int a)
    {
        Scroll.SetActive(true);

        if (a == 0)
        {
            EndText.text = "Συγχαρητήρια!";
        }
        if (a == 1)
        {
            if (highscore_check == false)
            {
                EndText.text = "Τέλος";
            }
            if (highscore_check == true)
            {
                EndText.text = "Νέα υψηλότερη βαθμολογία!";
            }
        }
        if(a == 2)
        {
            EndText.text = "Οι χωρικοί ξέφυγαν!";
        }

        RestartB.SetActive(true);
        GoBackB.SetActive(true);
        ExitB.SetActive(true);
        PauseM.SetActive(false);

        Time.timeScale = 0f;
    }

    private void Score(int points)
    {

        pt_counter += points;

        if(pt_counter < 0)
        {
            pt_counter = 0;
        }

        if(pt_counter > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", pt_counter);
            highscore = PlayerPrefs.GetInt("HighScore", 0);
            highscore_check = true;
        }

        PointCounter.text = "Πόντοι: " + pt_counter.ToString() + " (" + highscore.ToString() + ")";
    }

}
