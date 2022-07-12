using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MZU
{
   public class G_Battle_MHS2 : MonoBehaviour{

   Dragon_Anim_Script d = new Dragon_Anim_Script();
   G_GameScene G = new G_GameScene();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake(){
      d.anim = Finder.FindAnimator("Dragon");
      d.SMT_Fly();
    }
   }
}


