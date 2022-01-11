using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="quiz question",fileName ="a new question")]
public class QuestionsSo : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string question="enter new question text here";
    [SerializeField]string[] TheAnswers=new string[4]; 

    [SerializeReference]int indexCorrect;
    public string GetQuestion(){

        return question;
    } 

    public int GetCorrectAnswer(){

        return indexCorrect;
    }

    public string GetAnswer(int index){

        return TheAnswers[index];
    }  
   
}
