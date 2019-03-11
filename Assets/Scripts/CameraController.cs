using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        Debug.Log("Quitting");
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
