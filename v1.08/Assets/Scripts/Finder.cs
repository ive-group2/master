using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MZU{
   public class Finder : MonoBehaviour
   {
      #region GGO Series
      public static GameObject FindGO(string name){ GameObject go=GameObject.Find(name); return go; }
      public static Text FindText(string name){ Text got=GameObject.Find(name).GetComponent<Text>(); return got; }
      public static Animator FindAnimator(string name){ Animator goa=GameObject.Find(name).GetComponent<Animator>(); return goa; }
      public static AudioSource FindAudio(string name){ AudioSource gos=GameObject.Find(name).GetComponent<AudioSource>(); return gos; }
      public static AudioSource[] FindAudioArr(string name){ AudioSource[] gos_m=GameObject.Find(name).GetComponents<AudioSource>(); return gos_m; }
      public static Transform FindTransform(string name){ Transform gotf=GameObject.Find(name).transform; return gotf; }
      public static Slider FindSlider(string name){ Slider gosl=GameObject.Find(name).GetComponent<Slider>(); return gosl; }
      public static Rigidbody FindRigidbody(string name){ Rigidbody gorb=GameObject.Find(name).GetComponent<Rigidbody>(); return gorb; }
      #endregion
   }
}