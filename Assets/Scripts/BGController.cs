using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject[] array;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("StopScrolling", 2f);
       // Invoke("ContinueScrolling", 10f);
        //InvokeRepeating("IncreaseSpeed", 0f,2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopScrolling()
    {
        for (int i = 0; i < array.Length; i++)
            array[i].GetComponent<Scrolling>().Stop();
    }
    public void StartScrolling()
    {
        for (int i = 0; i < array.Length; i++)
            array[i].GetComponent<Scrolling>().Continue();
    }

    void IncreaseSpeed()
    {
        foreach (var bg in array)
        {
            bg.GetComponent<Scrolling>().IncreaseSpeed(1.5f);
        }
    }
}
