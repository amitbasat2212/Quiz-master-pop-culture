using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKepper : MonoBehaviour
{
    int correctAnswer=0;
    int QuestionSeen=0;

    public int GetcorrectAnswer(){
       return correctAnswer;     
    }

    public void setcorrectAnswer(){
       correctAnswer++;   
    }

    public int GetQuestionSeen(){
       return QuestionSeen;     
    }

     public void setQuestionSeen(){
       QuestionSeen++;   
    }

    public int CaculateScore(){
        return Mathf.RoundToInt(correctAnswer/(float)QuestionSeen*100);
    }




    
}
