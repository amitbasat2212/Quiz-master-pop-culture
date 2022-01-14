using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoreText;
    ScoreKepper scoreKepper;
    
    void Awake()
    {
        scoreKepper=FindObjectOfType<ScoreKepper>();
    }

    public void SHOWfinaleScore(){
        finalscoreText.text="congratulations!\n you scored:"
         +scoreKepper.CaculateScore() +"%";
    }    

    
}
