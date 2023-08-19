using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{


  
 
        void Awake()
        {
            GameObject[] Musicobj = GameObject.FindGameObjectsWithTag("GameMusic");

            if (Musicobj.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
    

}
