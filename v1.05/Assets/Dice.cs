using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MZU{

   public class Dice : MonoBehaviour
   {
      Animator m_Animator;
      bool m_Jump;
      // Start is called before the first frame update
      void Start()
      {
            m_Animator = G_GameScene.GGOA("dice2");
            m_Jump = false;
            
      }

      // Update is called once per frame
      void Update()
      {
            if (Input.GetKey(KeyCode.Space)){
               m_Jump = true;
               //m_Animator.Play("Jump");
            }

         //Otherwise the GameObject cannot jump.
         else m_Jump = false;

         //If the GameObject is not jumping, send that the Boolean “Jump” is false to the Animator. The jump animation does not play.
         if (m_Jump == false)
               m_Animator.SetBool("Jump", false);

         //The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
         if (m_Jump == true)
               m_Animator.SetBool("Jump", true);
      }
   }

}
