using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using System;

public class SignManager : MonoBehaviour
{

    [SerializeField] GameObject signField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleTimer()
    {
        Debug.Log("A minute has passed.");
        signField.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("This successfully happened.");
        signField.SetActive(false);
        System.Timers.Timer timer = new(interval: 60000);
        timer.Elapsed += (sender, e) => HandleTimer();
        timer.Start();

        timer.Dispose();
        
    }
}


