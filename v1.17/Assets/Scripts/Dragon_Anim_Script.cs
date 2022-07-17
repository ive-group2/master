using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Anim_Script : MonoBehaviour
{
   public Animator anim;

   void Start(){
      
   }

   void Awake(){
      
   }
   void Update(){
        
   }
   public void SMT_Idle(){
      anim.SetBool("isIdling",true);
      anim.SetBool("isWalking",false);
      anim.SetBool("isRunning",false);
      anim.SetBool("isFlying",false);      
   }
   public void SMT_Walk(){
      anim.SetBool("isIdling",false);
      anim.SetBool("isWalking",true);
      anim.SetBool("isRunning",false);
      anim.SetBool("isFlying",false);      
   }
   public void SMT_Run(){
      anim.SetBool("isIdling",false);
      anim.SetBool("isWalking",false);
      anim.SetBool("isRunning",true);
      anim.SetBool("isFlying",false);
   }
   public void SMT_Fly(){
      anim.SetBool("isIdling",false);
      anim.SetBool("isWalking",false);
      anim.SetBool("isRunning",false);
      anim.SetBool("isFlying",true);      
   }
}
