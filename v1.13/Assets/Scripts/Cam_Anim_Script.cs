using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Anim_Script : MonoBehaviour
{
   public Animator anim;
   // Start is called before the first frame update
   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {
      
   }
   public void CSST_Idle(){
      anim.SetBool("isIdle",true);
      anim.SetBool("isPlayerAtk",false);
      anim.SetBool("isPlayerBeingAtkd",false);
   }
   public void CSST_Attack(){
      anim.SetBool("isIdle",false);
      anim.SetBool("isPlayerAtk",true);
      anim.SetBool("isPlayerBeingAtkd",false);
   }
   public void CSST_BeingAttacked(){
      anim.SetBool("isIdle",false);
      anim.SetBool("isPlayerAtk",false);
      anim.SetBool("isPlayerBeingAtkd",true);
   }

}
