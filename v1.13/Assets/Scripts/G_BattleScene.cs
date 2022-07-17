using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace MZU
{
   public class G_BattleScene : MonoBehaviour
   {
        #region Variable Declarations , Initializations & Timer

            public static int player_InBattle_HP_Now = G_GameScene.player_HP_Now;
            public static int enemy_InBattle_HP_Now = 200;
            public static int player_InBattle_Power_Now = G_GameScene.player_Power_Now;

            public static int currFlag=0;

            public static int IsPlayerInputted = 0;
            public static char theCharPlayerInputted = '0';

            public static string[] Q = new string[5]; //Questions included given answers.
            public static char[] CA = new char[5]; //CA for correct answers. 
            
            public static int which_question_to_ask = 0;

            public AudioClip ac2;
            public AudioClip ac3;

            //Timer Start & Init.
            void Start(){dialogWriter(0);
            GGOSL("Player_HPBar").value=player_InBattle_HP_Now;
            GGOSL("Enemy_HPBar").maxValue=enemy_InBattle_HP_Now;
            GGOSL("Enemy_HPBar").value=enemy_InBattle_HP_Now;
            }
        #endregion

        #region GGO Series
            public static GameObject GGO(string name){ GameObject go=GameObject.Find(name); return go; }
            public static Text GGOT(string name){ Text got=GameObject.Find(name).GetComponent<Text>(); return got; }
            public static Animator GGOA(string name){ Animator goa=GameObject.Find(name).GetComponent<Animator>(); return goa; }
            public static AudioSource GGOS(string name){ AudioSource gos=GameObject.Find(name).GetComponent<AudioSource>(); return gos; }
            public static AudioSource[] GGOS_m(string name){ AudioSource[] gos_m=GameObject.Find(name).GetComponents<AudioSource>(); return gos_m; }
            public static Transform GGOTF(string name){ Transform gotf=GameObject.Find(name).transform; return gotf; }
            public static Slider GGOSL(string name){ Slider gosl=GameObject.Find(name).GetComponent<Slider>(); return gosl; }
            public static Rigidbody GGORB(string name){ Rigidbody gorb=GameObject.Find(name).GetComponent<Rigidbody>(); return gorb; }
            public static void GGMSM(string msg){ GameObject.Find("Canvas: GM (HUD)").SendMessage(msg); }
            public static void GGMSM(string msg,int value){ GameObject.Find("Canvas: GM (HUD)").SendMessage(msg,value); }
            public static void GGMSM(string msg,string strvalue){ GameObject.Find("Canvas: GM (HUD)").SendMessage(msg,strvalue); }
        #endregion

        #region Case Manager & Events
            //Case Manager
            public void dialogWriter(int localFlag){
                //Conversation that needs enter:
                //0,1,2,3,6,7,8,9,10
                //(exc.4,5)

                //Logic:
                //0123 desc,then answer Question (refer to 3,4,5)
                //-correct -playeratk -checkpostroundstate
                //-incorrect -noatk -noneedtocheck

                //67, then check player alive
                //-alive -repeatround
                //-dead -gameover

                Q[0] = "Q: Which animal has 4 legs?\n\nA. Spider   ||   B. Pig   ||   C. Human   ||   D. Duck";
                Q[1] = "Q: Which of the following color is NOT three primary colors in drawing?\n\nA. Red   ||   B. Blue   ||   C. Green   ||   D. Yellow";
                Q[2] = "Q: Which drink is the healthiest?\n\nA. Water   ||   B. Cola   ||   C. Lemon Tea   ||   D. Vodka";
                Q[3] = "Q: Which mountain is the highest in Hong Kong\n\nA. Lantau Peak   ||   B. Tsz Wan Shan   ||   C. Tai Mo Shan   ||   D. Victoria Peak";
                Q[4] = "Q: Which continent is the biggest?\n\nA. Asia   ||   B. Europe   ||   C. North America   ||   D. South America";

                CA[0] = 'B';
                CA[1] = 'C';
                CA[2] = 'A';
                CA[3] = 'C';
                CA[4] = 'A';


                if (localFlag==0) { GGOT("DialogText").text = "Granzon starts the battle against you.\n\n<Enter>"+G_GameScene.player_Power_Now; currFlag=1; }

                else if (localFlag==1) { GGOT("DialogText").text = "This is your turn. Press Enter to attack.\n\n<Enter>"; currFlag=2; }
                else if (localFlag==2) { GGOT("DialogText").text = "Press the correct letter for answering the question.\n\n<Enter>"; currFlag=3; }
                else if (localFlag==3) { GGOT("DialogText").text = Q[which_question_to_ask]; }
                

                else if (localFlag==4) { /*Animation*/ playerAttack();
                GGOT("DialogText").text = "You are correct. You dealt 80 damage to Granzon.\n\n<Enter>"; L.Log("granzon hp:"+enemy_InBattle_HP_Now);
                if(checkPostRoundState()==1){currFlag=9;} else{currFlag=6;} }
                
                else if (localFlag==5) { GGOT("DialogText").text = "Sorry, you are wrong."; currFlag=6; }

                else if (localFlag==6) { GGOT("DialogText").text = "This is enemy turn. Press Enter to continue.\n\n<Enter>"; currFlag=7; }
                else if (localFlag==7) { /*Animation*/ enemyAttack(); GGOT("DialogText").text = "Granzon dealt 20 damage to you.\n\n<Enter>";
                L.Log("ur hp:"+player_InBattle_HP_Now);
                if(checkPostRoundState()==0){currFlag=8;} else{currFlag=10;} }

                /*check who die*/
                else if (localFlag==8) { GGOT("DialogText").text = "Continue to next turn.\n\n<Enter>"; currFlag=1;theCharPlayerInputted='0';IsPlayerInputted=0;}

                else if (localFlag==9) { GGOT("DialogText").text = "Granzon is defeated. You won. Congratulations!\n\n<Enter>"; currFlag=11; }
                else if (localFlag==10) { GGOT("DialogText").text = "You are defeated. You lost. Sorry...\n\n<Enter>"; currFlag=12; }
                
                //else if (localFlag==11) { /*Animation*/ playerWon();}
                //else if (localFlag==12) { /*Animation*/ playerLost();} 
            }

            public void playerAttack(){enemyReceiveDamage();}
            public void enemyAttack(){playerReceiveDamage();}
            
            public void playerWon(){}
            public void playerLost(){}

            //Events
            public int checkPostRoundState(){
                if(player_InBattle_HP_Now>0 && enemy_InBattle_HP_Now>0){return 0;}
                else if(player_InBattle_HP_Now<=0){return 1;}
                else if(enemy_InBattle_HP_Now<=0){return 2;}
            return 0;}

            

        #endregion

        #region Value Setters

            public void playerReceiveDamage(){ player_InBattle_HP_Now = player_InBattle_HP_Now-20; GGOSL("Player_HPBar").value= player_InBattle_HP_Now; }
            public void enemyReceiveDamage(){ enemy_InBattle_HP_Now = enemy_InBattle_HP_Now-80; GGOSL("Enemy_HPBar").value= enemy_InBattle_HP_Now; }

  
        #endregion

        #region Update
            void Update() {
                if(Input.GetKeyDown(KeyCode.Return)){

                    GGOS("SE").clip = ac2; GGOS("SE").Play();

                    if(currFlag==1){dialogWriter(1);}
                    else if(currFlag==2){dialogWriter(2);}
                    else if(currFlag==3){dialogWriter(3);}
                    else if (currFlag==6){dialogWriter(6);}
                    else if (currFlag==7){dialogWriter(7);}
                    else if (currFlag==8){dialogWriter(8);}
                    else if (currFlag==9){dialogWriter(9);}
                    else if (currFlag==10){dialogWriter(10);}
                    else if (currFlag==11){Application.Quit();}
                    else if (currFlag==12){Application.Quit();}
                }
                if(currFlag==3 && IsPlayerInputted==0){
                    if(Input.GetKeyDown(KeyCode.A)){theCharPlayerInputted='A';IsPlayerInputted=1;}
                    else if (Input.GetKeyDown(KeyCode.B)){theCharPlayerInputted='B';IsPlayerInputted=1;}
                    else if (Input.GetKeyDown(KeyCode.C)){theCharPlayerInputted='C';IsPlayerInputted=1;}
                    else if (Input.GetKeyDown(KeyCode.D)){theCharPlayerInputted='D';IsPlayerInputted=1;}
                    if(theCharPlayerInputted=='A' || theCharPlayerInputted=='B' || theCharPlayerInputted=='C' || theCharPlayerInputted=='D'){

                        GGOS("SE").clip = ac2; GGOS("SE").Play();

                        L.Log(theCharPlayerInputted);
                        if(theCharPlayerInputted==CA[which_question_to_ask]){dialogWriter(4);which_question_to_ask++;}
                        else{dialogWriter(5);which_question_to_ask++;}
                    }
                }
                if(enemy_InBattle_HP_Now<=0){dialogWriter(9);}
                else if(player_InBattle_HP_Now<=0){dialogWriter(10);}



            }
        #endregion
    }
}
