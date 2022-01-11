using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionsSo questions;

    [SerializeField]GameObject[] answersButton;

    int CorrectAnswer;
   [SerializeField]Sprite defultAnserSprite;
   [SerializeField]Sprite thecorrectAnswerSprite; 
    // Start is called before the first frame update
    void Start()
    {
       DisplayQuestions();   
       
    
    }

    public void onanswerSelected(int index){
        Image buttonImage;
        if(index==questions.GetCorrectAnswer()){
            questionText.text="Correct!";
            buttonImage =answersButton[index].GetComponent<Image>();
            buttonImage.sprite=thecorrectAnswerSprite;

        }else{
            CorrectAnswer =questions.GetCorrectAnswer();
            string correctAnswer =questions.GetAnswer(CorrectAnswer);
            questionText.text="Sorry the correct answer was\n"+ correctAnswer;
            buttonImage =answersButton[CorrectAnswer].GetComponent<Image>();
            buttonImage.sprite=thecorrectAnswerSprite;
 
        }

        SetButtonesState(false);

    }

    void getNextQuestion(){
        SetButtonesState(true);
        SetdefultAnserSprite();
        DisplayQuestions();
    }

    private void SetdefultAnserSprite()
    {
       Image buttonImage1;
       for(int i=0;i<answersButton.Length;i++){
        buttonImage1=answersButton[i].GetComponent<Image>();
        buttonImage1.sprite=defultAnserSprite;
       }
    }

    void DisplayQuestions(){
        questionText.text=questions.GetQuestion();
        for(int i=0;i<answersButton.Length;i++){
          TextMeshProUGUI buttontext =answersButton[i].GetComponentInChildren<TextMeshProUGUI>();
          buttontext.text=questions.GetAnswer(i);
        }   
    }


    void SetButtonesState(bool state){
        for(int i=0;i<answersButton.Length;i++){
            Button button = answersButton[i].GetComponent<Button>();
            button.interactable=state;
        }

    }
}
