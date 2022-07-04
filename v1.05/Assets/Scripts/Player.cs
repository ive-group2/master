using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MZU{

   public class Player : MonoBehaviour
   {
      Transform x;

      void Awake(){
         x = G_GameScene.GGOTF("Cube");
      }

      // Start is called before the first frame update
      void Start()
      {
         
      }

      // Update is called once per frame
      void Update()
      {

         if(Input.GetKey(KeyCode.W))
         {
            this.GetComponent<Rigidbody>().velocity = new Vector3(2,0,0);
         }


      }
   }
}