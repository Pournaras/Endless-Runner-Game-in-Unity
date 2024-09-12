using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{
    public GameObject GreenBeer;
    public GameObject BlueBeer;
    public GameObject RedBeer;
    public GameObject GoldenBeer;

    //private float minRespawnTime = 30;
    //private float maxRespawnTime = 35;
    private float respawnTime = 30;
    //private int k;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            //respawnTime = Random.Range(minRespawnTime, maxRespawnTime + 1);
            yield return new WaitForSeconds(respawnTime);
            SpawnBeer();
        }
    }

    private void SpawnBeer()
    {
        //Screen limit bottom
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Screen limit top
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f - 0.5f;
        min.x = min.x + 0.225f + 0.5f;

        max.y = max.y - 0.285f - 5;
        min.y = min.y + 0.285f + 0.5f;

        /*
        k = Random.Range(0, 5);

        if (k == 0)
        {
            GameObject a = Instantiate(GreenBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        if (k == 1)
        {
            GameObject a = Instantiate(BlueBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        if (k == 3)
        {
            GameObject a = Instantiate(RedBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        if (k == 4)
        {
            GameObject a = Instantiate(GoldenBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }
        */

        if(counter >= 0 && counter <= 2)
        {
            GameObject a = Instantiate(GreenBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }
        if(counter == 3 || counter == 4)
        {
            GameObject a = Instantiate(RedBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }
        if(counter == 5)
        {
            GameObject a = Instantiate(GoldenBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }
        if(counter == 6 || counter == 7)
        {
            GameObject a = Instantiate(BlueBeer) as GameObject;
            a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        }

        counter++;
    }

}
