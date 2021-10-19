using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SwitchAnimation(bool flag)
    {
        anim.SetBool("isAppear", flag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
