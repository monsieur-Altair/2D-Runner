using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    //public GameObject score;
    public float speed;
    Vector2 min;
    GameObject score;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreTag");
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
        if (position.x < min.x-1f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerTag" || collider.tag == "ObstacleTag") 
        {
            Destroy(gameObject);
            score.GetComponent<GameScore>().Score += 100;
        }
            
    }
}
