using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript_2P : MonoBehaviour
{
   public float speed;
   public float rotSpeed;

   Animator anim;
   Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      var z = Input.GetAxis("Vertical")*speed;
      var y = Input.GetAxis("Horizontal")*rotSpeed;

      transform.Translate(0,0,z);
      transform.Rotate(0,y,0);   

      if(Input.GetKey(KeyCode.I)){
         //rb.velocity = new Vector3(0,0,0);
         this.transform.Translate(0,0,0.25f);
         anim.SetBool("isRunning",true);
         anim.SetBool("isIdle",false);
         if(Input.GetKey(KeyCode.L)){this.transform.Rotate(0,1.8f,0);}
         else if(Input.GetKey(KeyCode.J)){this.transform.Rotate(0,-1.8f,0);}

      }
      else if(Input.GetKey(KeyCode.J)){
         this.transform.Rotate(0,-1.8f,0);
      }
      else if(Input.GetKey(KeyCode.L)){
         this.transform.Rotate(0,1.8f,0);
      }
      /*else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ){
                  anim.SetBool("isWalking",true);
         anim.SetBool("isIdle",false);
      }*/
      else{
         anim.SetBool("isIdle",true);
         anim.SetBool("isRunning",false);
      }
    }
}
