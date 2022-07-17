using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MZU
{
   public class AnimScript2 : MonoBehaviour
   {
      public float speed;
      public float rotSpeed;

      Animator anim;
      Rigidbody rb;

      Cam_Anim_Script Cam = new Cam_Anim_Script();
      

      void Awake(){
         anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody>();
         Cam.anim = Finder.FindAnimator("Main Camera");
         Cam.CSST_Idle();

      }
      // Start is called before the first frame update
      void Start()
      {
         anim.SetBool("isIdle",true);
         anim.SetBool("isRunning",false);

      }

      // Update is called once per frame
      void Update()
      {
         if(Input.GetKeyDown(KeyCode.W)){
            Cam.CSST_Attack();
         }
         else if(Input.GetKeyDown(KeyCode.S)){
            Cam.CSST_BeingAttacked();
         }
         else{
            Cam.CSST_Idle();
         }
      }

   }

}
