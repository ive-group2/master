using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject go;
    public static int playerHP = 100;
    public static int dmg = 5;
    
    public Slider HP_Bar;


    void Start(){
        
    }
    // Start is called before the first frame update

    public void UpdateHealth(int hp){
        HP_Bar = go.GetComponent<Slider>();
        playerHP = playerHP-dmg;
        HP_Bar.value = playerHP;

    }
}
