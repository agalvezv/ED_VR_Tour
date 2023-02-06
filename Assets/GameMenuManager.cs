using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{

    public Transform pcamera;
    public float spawnD;
    public int flip;
    public GameObject menu;
    public InputActionProperty showButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(showButton.action.WasPerformedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = pcamera.position + new Vector3(pcamera.forward.x, 0, pcamera.forward.z).normalized * spawnD;
        }

        menu.transform.LookAt(new Vector3(pcamera.position.x, menu.transform.position.y, pcamera.position.z));
        menu.transform.forward *= flip;

    }
}
