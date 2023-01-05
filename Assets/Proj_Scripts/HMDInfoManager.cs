using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HMDInfoManager : MonoBehaviour
{

    [SerializeField] GameObject deviceSimulator;
    // Start is called before the first frame update
    void Start()
    {
        //XRSettings.isDeviceActive
       // Debug.Log("Is Device Active" + XRSettings.isDeviceActive);
        //Debug.Log("Device Name is : " + XRSettings.loadedDeviceName);


        if (!XRSettings.isDeviceActive)
        {
            Debug.Log("Meta is plugged in.");


                deviceSimulator.SetActive(false);
                Debug.Log("Simulator device set to" + deviceSimulator.activeSelf);
          
        }
        /*
        else if (XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" 
            || XRSettings.loadedDeviceName == "MockHMDDisplay"
            || XRSettings.loadedDeviceName == "MockHMD"))
        {
            Debug.Log("Using Mock HMD");
        }
        */
        else
        {
            Debug.Log("We have a headset: " + XRSettings.loadedDeviceName);

            if(XRSettings.loadedDeviceName == "Mock HMD")
            {
                deviceSimulator.SetActive(false);
                Debug.Log("Simulator device set to" + deviceSimulator.activeSelf);
            }
            else
            {
                Debug.Log("Simulator device set to true.");
            }
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
