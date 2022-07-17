using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCam_Follow_2P2 : MonoBehaviour
{
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player2");
               


    }

    void LateUpdate()
    {
      this.transform.position = new Vector3(_player.transform.position.x,3.2f,_player.transform.position.z-9);



    }
    
}
