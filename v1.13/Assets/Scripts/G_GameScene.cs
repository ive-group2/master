using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace MZU
{

   public class L : MonoBehaviour { public static void Log(String str) { Debug.Log(str); } public static void Log(int x) { Debug.Log(x); }  }

   public class T : MonoBehaviour { public static float DT = Time.deltaTime; }

   public class G_GameScene : MonoBehaviour
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
            void Update() {
                try{
                    if(flag==0){
                        if(IsGranzonApproaching()){
                            L.Log("Changed to new BGM.");
                            Finder.FindAudio("Canvas: GM (HUD)").Pause();
                            Finder.FindAudio("Canvas: GM (HUD)").clip=ac2;
                            Finder.FindAudio("Canvas: GM (HUD)").Play();
                            flag=1;
                        }
                    }
                    if(flag==1){
                        if(IsGranzonApproached()){
                        Finder.FindText("Power Bar").text ="Granzon approaches you rapidly!";
                        Time.timeScale = 0;
                        flag=2;
                        }
                    }
                    if (flag==2 && Input.GetKeyDown(KeyCode.Return)){
                        StopCoroutine("Timer");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                    }
                    if (Input.GetKeyDown(KeyCode.Escape)){
                        Application.Quit();
                    }
                }
                catch(NullReferenceException ex){/*L.Log(flag+"Update NRX.");*/}

            }
        #endregion
    }
}
