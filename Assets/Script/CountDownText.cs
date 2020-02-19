using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CountDownText : MonoBehaviour
{

    
    Text countdown;
    int temporimanente;

    void Update()
    {
        countdown.text = PlayerPrefs.GetInt("Time").ToString();
    }
    void OnEnable()
    {
        countdown = GetComponent<Text>();
        countdown.text = "120";
       
    }

    

}
