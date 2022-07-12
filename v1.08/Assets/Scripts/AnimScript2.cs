using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript2 : MonoBehaviour
{
   public float speed;
   public float rotSpeed;

   Animator anim;
   Rigidbody rb;

    void Awake(){
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
      anim.SetBool("isIdle",true);
      anim.SetBool("isWaling",false);

    }

    // Update is called once per frame
    void Update()
    {
    }

}
