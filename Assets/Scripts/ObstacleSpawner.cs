using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    private PlayerController playerController;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, 2f);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if(playerController.isGameOver == false)
        {
            Instantiate(obstaclePrefab, new Vector3(10, 0.4f, 6f), obstaclePrefab.transform.rotation);
        }
        
    }
}
