using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCam_Follow : MonoBehaviour
{
    private GameObject _player;

    Vector2 rotation = Vector2.zero;
    public float speed = 3; 

    void Start()
    {
        _player = GameObject.Find("Player");
               


    }

    void LateUpdate()
    {
      this.transform.position = new Vector3(_player.transform.position.x,3.2f,_player.transform.position.z-9);
		this.rotation.y += Input.GetAxis("Mouse X");
		this.rotation.x += -Input.GetAxis("Mouse Y");

		transform.eulerAngles = (Vector2)rotation * speed;


    }
    
}
