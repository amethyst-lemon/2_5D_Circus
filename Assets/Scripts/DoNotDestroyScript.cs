using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


        //GameObject[] effectsObj = GameObject.FindGameObjectsWithTag("SoundEffects");
       // if (effectsObj.Length > 1)
       // {
        //    Destroy(this.gameObject);
       // }
       // DontDestroyOnLoad(this.gameObject);
    }
}
