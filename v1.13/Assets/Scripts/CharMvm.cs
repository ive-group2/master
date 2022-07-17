using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMvm : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float xRange1 = 25f;
    public float xRange2 = 50f;

    public float jf = 20f; //jumping force

    public static Rigidbody _rb;

    public Transform _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = this.transform;
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed * .85f;

        if(_player.position.x < xRange1)
        {_player.position = new Vector3(xRange1,_player.position.y,_player.position.z);}
        else if(_player.position.x > xRange2)
        {_player.position = new Vector3(xRange2,_player.position.y,_player.position.z);}
        else if(_player.position.y < 0.5f)
        {_player.position = new Vector3(_player.position.x,0.5f,_player.position.z);}
        else{
        _player.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);
        }
      
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jf);
        }  
    }
    
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            Debug.Log("AAAAB HIT");
            //audioSource.Play();
    }
}
