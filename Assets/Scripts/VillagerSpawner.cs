using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    public GameObject VillagerPrefab;

    public SpeedOmeter SpeedOmeter;

    public float minRespawnTime = 1f;
    public static float maxRespawnTime = 4f;
    public float respawnTime = 3;
    //private int k;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    private void SpawnVillager()
    {
        //Screen limit bottom
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Screen limit top
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f - 0.5f;
        min.x = min.x + 0.225f + 0.5f;

        max.y = max.y - 0.285f - 5;
        min.y = min.y + 0.285f + 0.5f;

        
        GameObject a = Instantiate(VillagerPrefab) as GameObject;
        a.transform.position = new Vector2(max.x + 3, Random.Range(max.y - 0.3f, min.y));
        
    }

    IEnumerator Timer()
    {
        while (true)
        {
            //respawnTime = Random.Range(minRespawnTime, maxRespawnTime + 1);
            yield return new WaitForSeconds(respawnTime);
            SpawnVillager();
            counter++;

            //Respawn time reduce every 50 villagers
            if(counter % 50 == 0)
            {

                if(respawnTime > 1)
                {
                    respawnTime--;
                }
            }

            //Speed increase every 20 villagers
            if(counter % 20 == 0)
            {
                SpeedOmeter.IncreaseSpeed();
            }
        }

    }

}
