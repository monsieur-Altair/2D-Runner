using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed = 1f;
    private float cameraLength;
    bool isMove = true;


    void Start()
    {
        cameraLength = Camera.main.orthographicSize * 2f * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove)
            return;
        Vector2 position = transform.position;
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    private void FixedUpdate()
    {
        if (!isMove)
            return;
        if (transform.position.x < -cameraLength)
            transform.position = new Vector2(cameraLength, transform.position.y);
    }

    public void Stop()
    {
        isMove = false;
    }

    public void Continue()
    {
        isMove = true;
    }

    public void IncreaseSpeed(float value)
    {
        speed *= value;
    }
}
