using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScorePointScript : MonoBehaviour
{

    public int punteggio;
    Text score;
    // Start is called before the first frame update
    void OnEnable()
    {

        score = GetComponent<Text>();
        score.text = "0";

    }
    private void OnDisable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score.text = punteggio.ToString();
    }
}
