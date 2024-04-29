using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    //Needs list: Food, Job, Socialise (be close to other NPC.), 
    public float foodNeed, jobNeed, socialNeed;
    public float 

    void Start()
    {
        foodNeed = 10f;
    }
    // Update is called once per frame
    void Update()
    {

        foodNeed=Mathf.Clamp(foodNeed, 0.001f, 1f);
        foodNeed -= Time.deltaTime * 0.01f;
    }
}
