using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    enum SpawnType
    {
        SQUARE,
        PYRAMID,
        STAIRWAY
    }

    public GameObject coinPrefab;
    Vector2 min, max;
    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
       // InvokeRepeating("SpawnCoin", 0, 8f);
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnCoin", 0, 8f);
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnCoin");
    }
        

    public void SpawnCoin()
    {
        float randomPosY = Random.Range(min.y, 0.6f * max.y);
        SpawnType value = (SpawnType)Random.Range(0, 4);
        //value = 0;
        Vector2 startPos = new Vector2(max.x*1.3f, randomPosY);
        switch (value)
        {
            case SpawnType.SQUARE:
                for (int i = 0; i < 9; i++)
                {
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = startPos + new Vector2(i / 3, i % 3);
                }
                break;
            case SpawnType.PYRAMID:
                {
                    int row = 3, column = 5;
                    for (int i = 0; i < row; i++)
                        for (int j = 0; j < column; j++)
                            if (j >= i && j < column - i)
                            {
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = startPos + new Vector2(j, i);
                            }
                    break;
                }
            case SpawnType.STAIRWAY:
                {
                    int row = 3, column = 4;
                    for (int i = 0; i < row; i++)
                        for (int j = 0; j < column; j++)
                            if (j >= i)
                            {
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = startPos + new Vector2(j, i);
                            }
                    break;
                }
            default:
                break;
        }

    }
}
