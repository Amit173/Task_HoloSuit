using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    float xRotation = 5f;
    public TextMeshProUGUI ResumeText;
    public TextMeshProUGUI MenuText;
    public GameObject MenuCanvas;
    public GameObject MainGameCanvas;

    public GameObject PlayerCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerCamera.transform.Rotate(0f , xRotation, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerCamera.transform.Rotate(0f,-xRotation,  0f);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            PlayerCamera.transform.Rotate(xRotation,0f, 0f);
        }
        if(Input.GetKey(KeyCode.E))
        {
            PlayerCamera.transform.Rotate(-xRotation, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0f, -3f, 0f);
            PlayerCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Escape Key down");
            ResumeText.text = "Resume";
            MenuText.text = "Menu";
            MainGameCanvas.SetActive(false);
            MenuCanvas.SetActive(true);
        }
    }
}
