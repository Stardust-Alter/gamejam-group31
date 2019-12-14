using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManagement : MonoBehaviour
{
    public static SEManagement _Instance; 


    const string audioDir = "Audio/";

    public void PlaySE(string sePath)
    {
            GameObject go = ResourceInterface.InstantiateGO("SEPlayer", this.transform);
            go.GetComponent<SEPlayer>().init(audioDir + sePath);

    }
}
