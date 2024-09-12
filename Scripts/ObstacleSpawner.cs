using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject WellPrefab;
    public GameObject CarriagePrefab;
    public GameObject BarrelPrefab;
    public GameObject MarketPrefab;

    GameObject obj;

    //private float minRespawnTime = 1f;
    //private float maxRespawnTime = 1f;
    private float respawnTime;
    private float speed;
    private float distance = 2.8f;
    private int k;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("SpeedOmeter");

        StartCoroutine(Timer());
    }

    private void SpawnObstacle()
    {
        //Screen limit bottom
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Screen limit top
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f - 0.5f;
        min.x = min.x + 0.225f + 0.5f;

        max.y = max.y - 0.285f - 5;
        min.y = min.y + 0.285f + 0.5f;

        k = Random.Range(0, 5);

        if( k == 0 )
        {
            GameObject a = Instantiate(CarriagePrefab) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        if( k == 1 )
        {
            GameObject a = Instantiate(WellPrefab) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        if (k == 3)
        {
            GameObject a = Instantiate(BarrelPrefab) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        if (k == 4)
        {
            GameObject a = Instantiate(MarketPrefab) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }
    }

    IEnumerator Timer()
    {
        while(true)
        {
            speed = obj.GetComponent<SpeedOmeter>().obstacleSpeed;

            respawnTime = distance / speed;

            //respawnTime = Random.Range(minRespawnTime, maxRespawnTime + 1);
            yield return new WaitForSeconds(respawnTime);
            SpawnObstacle();
        }
    }
}
