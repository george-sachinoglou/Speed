using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    
    public GameObject[] list;
    GameObject barrier;
    
    public Camera cam;
    Vector3 screenSpawn;
    Vector3 barrierPos;
    int choice;
    float camHeight;
    float camWidth;
    


    // Start is called before the first frame update
    void Start()
    {
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
  
        
        screenSpawn = new Vector3(Random.Range(-camWidth / 2 + 1, camWidth / 2 - 1f), this.transform.position.y, 0);
        barrier = Instantiate(list[0], screenSpawn, Quaternion.identity);
        
       

    }

    // Update is called once per frame
    void Update()
    {
        
        barrierPos = barrier.transform.position;
        if (this.transform.position.y - barrierPos.y > 2.5 && ScoreManager.scoreCount < 10)
        {
            SpawnerStageOne();
        }

        if (this.transform.position.y - barrierPos.y > 2.5 && ScoreManager.scoreCount >= 10 && ScoreManager.scoreCount < 20)
        {
            SpawnerStageTwo();
        }

        if (this.transform.position.y - barrierPos.y > 2.5 && ScoreManager.scoreCount >= 20 && ScoreManager.scoreCount < 30)
        {
            SpawnerStageThree();
        }

        if (this.transform.position.y - barrierPos.y > 2.5 && ScoreManager.scoreCount >= 30)
        {
            SpawnerStageFour();
        }





    }

    void SpawnerStageOne()
    {
         
        screenSpawn = new Vector3(Random.Range(-camWidth / 2  + 1, camWidth / 2 - 1f), this.transform.position.y, 0);
        barrier = Instantiate(list[0], screenSpawn, Quaternion.identity);

    }
    
    void SpawnerStageTwo()
    {
        choice = Random.Range(0, 2);
        screenSpawn = new Vector3(Random.Range(-camWidth / 2 + 1, camWidth / 2 - 1f), this.transform.position.y, 0);
        barrier = Instantiate(list[choice], screenSpawn, Quaternion.identity);
    }

    void SpawnerStageThree()
    {
        choice = Random.Range(4, 6);
        screenSpawn = new Vector3( 0, this.transform.position.y, 0);
        barrier = Instantiate(list[choice], screenSpawn, Quaternion.identity);
    }

    void SpawnerStageFour()
    {
        choice = Random.Range(0, 6);
        if (choice < 4)
        {
            screenSpawn = new Vector3(Random.Range(-camWidth / 2 + 1, camWidth / 2 - 1f), this.transform.position.y, 0);
            barrier = Instantiate(list[choice], screenSpawn, Quaternion.identity);
        }
        else
        {
            screenSpawn = new Vector3( 0, this.transform.position.y, 0);
            barrier = Instantiate(list[choice], screenSpawn, Quaternion.identity);
        }
    }






}
