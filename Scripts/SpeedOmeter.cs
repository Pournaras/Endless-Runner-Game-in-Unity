using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOmeter : MonoBehaviour
{
    public float obstacleSpeed;
    public float villagerSpeed;
    public float groundSpeed;
    public float wallSpeed;
    public float beerSpeed;

    //private float timer = 30f;
    private float increase_speed = 0.20f;

    // Start is called before the first frame update
    void Start()
    {
        obstacleSpeed = 2.8f;
        villagerSpeed = 3.2f;
        groundSpeed = 2.8f;
        wallSpeed = 2f;
        beerSpeed = 2.3f;

        ObstacleController.speed = obstacleSpeed;
        //VillagerController.speed = villagerSpeed;
        ScrollingGround.speed = groundSpeed;
        ScrollingWall.speed = wallSpeed;
        BeerController.speed = beerSpeed;

        //StartCoroutine(Timer());
    }

    /*
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            IncreaseSpeed();
        }
    }
    */

    public void IncreaseSpeed()
    {
        obstacleSpeed += increase_speed;
        villagerSpeed += increase_speed;
        groundSpeed += increase_speed;
        wallSpeed += increase_speed;
        beerSpeed += increase_speed;

        ObstacleController.speed = obstacleSpeed;
        //VillagerController.speed = villagerSpeed;
        ScrollingGround.speed = groundSpeed;
        ScrollingWall.speed = wallSpeed;
        BeerController.speed = beerSpeed;
    }

}
