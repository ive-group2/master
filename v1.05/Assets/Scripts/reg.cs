using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Microsoft.Win32;


    public class reg : MonoBehaviour
    {
        // Start is called before the first frame update

    //    public static extern object GetValue (string keyName, string valueName, object defaultValue);
/*
        [DllImport("Microsoft.Win32.Registry.dll")]
        public static extern object Registry.OpenSubKey (string name, bool writable);
        [DllImport("Microsoft.Win32.Registry.dll")]  
        public static extern object OpenSubKey(string folder);
        
        [DllImport("Microsoft.Win32.Registry.dll")]
        public static extern object GetValue (string keyName);*/
    

        void Start()
        {
            
            try{
            RegistryKey my_reg_folder = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MingZ Soft");
            string x = my_reg_folder.GetValue("Location").ToString();
            Debug.Log(x);
            //init_get_set_registry();
            }
            catch(EntryPointNotFoundException ex){
                Debug.Log('a');
                
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        
    }
