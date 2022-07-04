using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MZU{

    public class Scene0 : MonoBehaviour
    {
        void Update() {
            if (Input.GetKeyDown(KeyCode.Return)){
                G_Scene0.GGOA("btnStart").Play("anm_btnstart_fadeout");
                Debug.Log("Enter key was pressed.");
            }

            if(AnimatorFinished()){
            _switch_in_menu_scene();
            }
            
            
        }
        void _switch_in_menu_scene(){
        G_Scene0.GGO("btnStart").SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        bool AnimatorFinished(){
        return G_Scene0.GGOA("btnStart").GetCurrentAnimatorStateInfo(0).normalizedTime>=1 && G_Scene0.GGOA("btnStart").GetCurrentAnimatorStateInfo(0).IsName("anm_btnstart_fadeout");
        }


    }
}