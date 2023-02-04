using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentNamePopup : MonoBehaviour
{
    public Canvas studentNameCanvas;
    public Text studentNameText;
    public Button studentNameButton;

    void Start()
    {
        studentNameCanvas.gameObject.SetActive(false);
        studentNameButton.onClick.AddListener(ShowStudentNamePopup);
    }

    public void ShowStudentNamePopup()
    {
        studentNameCanvas.gameObject.SetActive(true);
        studentNameText.text = "Student Name: John Doe";
    }
}