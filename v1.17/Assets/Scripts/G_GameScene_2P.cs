using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace MZU
{


   public class G_GameScene_2P : MonoBehaviour
   {
        #region Variable Declarations , Initializations & Timer

            public static float timecount = 0f;
            public static int player_HP_Now = 100;
            public static int player_Power_Now = 0;
            public static int flag=0;
            public AudioClip ac2;

            //Timer Start & Init.
            void Start() { StartCoroutine("Timer"); }
            IEnumerator Timer(){
                while(true){
                timecount = Time.time;
                int ms = (int)((timecount-(int)timecount)*100);
                int second = (int)(timecount%60);
                int min= (int)(timecount/60%60);
                Finder.FindText("Timer").text = "Timer: \n"+string.Format("{0:00}:{1:00}:{2:00}",min,second,ms);
                yield return null;
                }
            }
        #endregion



        #region Case Manager & Events
            //Case Manager
            public void playerHitStone(){ L.Log("Player hit the stone."); Finder.FindRigidbody("Player").AddForce(new Vector3(0,100,-300)); playerReceiveStoneDamage();}
            public void playerCollectHeart(String ID){ L.Log("Player collected the heart."); Finder.FindGO(ID).SetActive(false); playerReceiveHeal(); }
            public void playerCollectPowerUp(String ID){L.Log("Player collected the PowerUp."); Finder.FindGO(ID).SetActive(false); playerReceivePowerUp();}

            bool IsGranzonApproaching(){return Finder.FindAnimator("GranzonPic").GetCurrentAnimatorStateInfo(0).IsName("GranzonApproaches");}
            bool IsGranzonApproached(){return Finder.FindAnimator("GranzonPic").GetCurrentAnimatorStateInfo(0).normalizedTime>=1;}

            //Events

        #endregion

        #region Value Setters

            public void playerReceiveStoneDamage(){ player_HP_Now = player_HP_Now-10; Finder.FindSlider("Health Bar").value = player_HP_Now; }

            public void playerReceiveHeal(){ player_HP_Now = player_HP_Now+10; Finder.FindSlider("Health Bar").value = player_HP_Now; }

            public void playerReceivePowerUp(){ player_Power_Now = player_Power_Now+5; Finder.FindText("Power Bar").text = "P: " + player_Power_Now; }
  
        #endregion

        #region Update
            void Update() {}

        #endregion
    }
}
