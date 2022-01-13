using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTimer : MonoBehaviour
{
    [SerializeField]float TimetoCompleteQuestions = 30f;
    [SerializeField]float TimetoShowCorrectAnswer=10f;

    public bool loadNextQuestion;
    public float fillFraction;

   public bool IsanswerningQuestions;
    float TimerValue;

    void Update()
    {
        UpdateTimer();   
    }

    public void CancelTimer(){
        TimerValue=0;
    }

    private void UpdateTimer()
    {
        TimerValue-=Time.deltaTime;

        if(IsanswerningQuestions){
           if(TimerValue>0){

              fillFraction=TimerValue/TimetoCompleteQuestions;

           }else{
               IsanswerningQuestions=false;
               TimerValue=TimetoShowCorrectAnswer; 
           }  
        }
        else{
            if(TimerValue>0){
              fillFraction=TimerValue/TimetoShowCorrectAnswer;
            }else{
                IsanswerningQuestions=true;
                TimerValue=TimetoCompleteQuestions;
                loadNextQuestion=true;


            }     
        }
    }
}
