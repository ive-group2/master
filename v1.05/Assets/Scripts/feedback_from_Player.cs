using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MZU{
    public class feedback_from_Player : MonoBehaviour
    {
         G_GameScene G = new G_GameScene();     

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

            if (collision.gameObject.name=="Trigger"){ G_GameScene.GGOA("GranzonPic").Play("GranzonApproaches"); }
        }
    }
}