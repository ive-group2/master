using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MZU{
    public class feedback_from_Player : MonoBehaviour
    {
         public AudioClip ac2;
         G_GameScene G;
         Dragon_Anim_Script D;

         void Awake(){
            G=Finder.FindGO("Player").AddComponent<G_GameScene>();
            D=Finder.FindGO("Player").AddComponent<Dragon_Anim_Script>();
            D.anim = Finder.FindAnimator("Dragon");

         } 

         void OnCollisionEnter(Collision collision) {


                        
            if (collision.gameObject.name=="Stone1" || collision.gameObject.name=="Stone2" || collision.gameObject.name=="Stone3" ||
            collision.gameObject.name=="Stone4" || collision.gameObject.name=="Stone5" || collision.gameObject.name=="Stone6"){ G.playerHitStone(); }
            
            if (collision.gameObject.name=="Heart1"){ G.playerCollectHeart("Heart1"); }
            if (collision.gameObject.name=="Heart2"){ G.playerCollectHeart("Heart2"); }
            if (collision.gameObject.name=="Heart3"){ G.playerCollectHeart("Heart3"); }
            if (collision.gameObject.name=="Heart4"){ G.playerCollectHeart("Heart4"); }

            if (collision.gameObject.name=="Power1"){ G.playerCollectPowerUp("Power1"); }
            if (collision.gameObject.name=="Power2"){ G.playerCollectPowerUp("Power2"); }
            if (collision.gameObject.name=="Power3"){ G.playerCollectPowerUp("Power3"); }
            if (collision.gameObject.name=="Power4"){ G.playerCollectPowerUp("Power4"); }

            if (collision.gameObject.name=="TriggerBat1"){ Finder.FindRigidbody("Bat1").AddForce(0,0,-20f,ForceMode.VelocityChange);}
            if (collision.gameObject.name=="TriggerBat2"){ Finder.FindRigidbody("Bat2").AddForce(0,0,-20f,ForceMode.VelocityChange); }
            if (collision.gameObject.name=="TriggerBat3"){ Finder.FindRigidbody("Bat3").AddForce(0,0,-20f,ForceMode.VelocityChange); }

            if (collision.gameObject.name=="Bat1"){ G.playerHitStone(); }
            if (collision.gameObject.name=="Bat2"){ G.playerHitStone(); }
            if (collision.gameObject.name=="Bat3"){ G.playerHitStone(); }

            if (collision.gameObject.name=="Trigger"){ D.SMT_Fly();
                        Finder.FindAudio("Canvas: GM (HUD)").Pause();
                        Finder.FindAudio("Canvas: GM (HUD)").clip=ac2;
                        Finder.FindAudio("Canvas: GM (HUD)").Play();
                        Finder.FindText("Power Bar").text ="Granzon approaches you rapidly!";
                        //Time.timeScale = 0;
                        G_GameScene.flag=2;}

            
        }
    }
}