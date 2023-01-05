using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class RotationRelocate : MonoBehaviour
{
    [SerializeField] Vector3 rotationT;
    [SerializeField] float speedT;
    Vector3 localPosition;

    // Start is called before the first frame update
    void Start()
    {
        localPosition = gameObject.GetComponent<Transform>().position;
        Vector3 gloablPosition = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("ChangePosition", Time.deltaTime, 5);

        /*
        if(Time.deltaTime % 5 == 0)
        {
            transform.position = localPosition;
        }
        */

        transform.Rotate(rotationT * speedT * Time.deltaTime);
    }

    void ChangePosition()
    {
        transform.position = localPosition;
    }
}
