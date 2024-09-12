using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleDestroyerController : MonoBehaviour
{
    public Text EndText;
    public GameObject PauseM;
    public GameObject RestartB;
    public GameObject ExitB;
    public GameObject Scroll;

    public PlayerController PlayerController;

    private int counter;

    // Start is called before the first frame update
    void Start()
    {      
        counter = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "VillagerIsDown")
        {
            counter = 0;
        }
        if(collision.tag == "Villager")
        {
            counter++;
        }

        if(counter == 2)
        {
            //PlayerController.vil_escape = true;
            PlayerController.End(2);
        }
      
    }
}