using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    Vector2 min, max;
    public GameObject obstaclePrefab;
    public GameObject healPrefab;

    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnObstacle", 0, 8f);
        InvokeRepeating("SpawnHeal", 5f, 8f);
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnObstacle");
        CancelInvoke("SpawnHeal");
    }
    void SpawnObstacle()
    {
        float randomPosY = Random.Range(min.y + 1.2f, max.y - 1.2f);
        float z=Random.Range(0f,90f);
        GameObject obstacle = Instantiate(obstaclePrefab, new Vector2(1.2f * max.x, randomPosY), new Quaternion(0,0,z, 10));
    }
    void SpawnHeal()
    {
        float randomPosY = Random.Range(min.y + 1.2f, max.y - 1.2f);
        GameObject heal = Instantiate(healPrefab, new Vector2(1.2f * max.x, randomPosY),new Quaternion(0, 0, 0, 10));
    }
}
//transform.Rotate(Vector3(0, 0, 50));
////instead of :
//transform.eulerAngles = new Vector3(0, 0, 50);
////or like you said
//transform.eulerAngles = Vector3.forward * 50;
// obstacle.GetComponent<SpriteRenderer>().transform.eulerAngles=(Vector3.forward * 90f);