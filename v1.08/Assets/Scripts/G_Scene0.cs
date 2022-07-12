using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace MZU
{
   public class G_Scene0 : MonoBehaviour
    {
        public static GameObject GGO(string name){ GameObject go=GameObject.Find(name); return go; }
        public static Animator GGOA(string name){ Animator goa=GameObject.Find(name).GetComponent<Animator>(); return goa; }
    }
}
