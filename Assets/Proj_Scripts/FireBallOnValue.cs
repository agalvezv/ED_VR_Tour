using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using System;
using Random = System.Random;
using Unity.VisualScripting;

public class FireBallOnValue : MonoBehaviour
{

    public GameObject nerfball;
    public Transform spawnPoint;
    //[SerializeField]
    public float fireSpeed;
    public float expDec;
    Random random = new Random();


    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grababble = GetComponent<XRGrabInteractable>();
        grababble.activated.AddListener(FireBall);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBall(ActivateEventArgs arg)
    {


        float destroyTime = random.Next(2, 7);
       

        GameObject spawnedNerf = Instantiate(nerfball);
        spawnedNerf.transform.position = spawnPoint.position;
        /*
        while (spawnedNerf != null)
        {
            expDec *= expDec;
        }
        */
        spawnedNerf.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed * expDec;
        
        Destroy(spawnedNerf, destroyTime);
    }

}
