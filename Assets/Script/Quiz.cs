using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] List<QuestionsSo> questions=new List<QuestionsSo>();
    QuestionsSo currentQuestion;
    
    [Header("answers")]
    [SerializeField]GameObject[] answersButton;
    int CorrectAnswer;
    bool hasanswersearly;

    [Header("buttonscolor")]
   [SerializeField]Sprite defultAnserSprite;
   [SerializeField]Sprite thecorrectAnswerSprite; 
   
   [Header("timer")]
   [SerializeField] Image TimerImage;
   TheTimer timer;

   [Header("scoring")]
   [SerializeField] TextMeshProUGUI scoreText;
   ScoreKepper scoreKepper;

   [Header("slider")]
    public bool IsCOmplete;
   [SerializeField] Slider progressBar;
   
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<TheTimer>();    
        scoreKepper=FindObjectOfType<ScoreKepper>();  
        progressBar=FindObjectOfType<Slider>();
        progressBar.maxValue=questions.Count;
        progressBar.value=0;

    }

    private void Update() {
        TimerImage.fillAmount=timer.fillFraction;
        if(timer.loadNextQuestion){
            getNextQuestion();
            timer.loadNextQuestion=false;
            hasanswersearly=false;
        }
        else if(!hasanswersearly && !timer.IsanswerningQuestions){
            displayAnswer(-1);
           SetButtonesState(false);
        }
    }

    public void onanswerSelected(int index){
        hasanswersearly=true;
        displayAnswer(index);  
        timer.CancelTimer();
        SetButtonesState(false);
        scoreText.text="Score:"+scoreKepper.CaculateScore() + "%";
        if(progressBar.value==progressBar.maxValue){
            IsCOmplete=true;
        }
    }

    void displayAnswer(int index){
        Image buttonImage;
        if(index==currentQuestion.GetCorrectAnswer()){
            questionText.text="Correct!";
            buttonImage =answersButton[index].GetComponent<Image>();
            buttonImage.sprite=thecorrectAnswerSprite;
            scoreKepper.setcorrectAnswer();
        }else{
            CorrectAnswer =currentQuestion.GetCorrectAnswer();
            string correctAnswer =currentQuestion.GetAnswer(CorrectAnswer);
            questionText.text="Sorry the correct answer was\n"+ correctAnswer;
            buttonImage =answersButton[CorrectAnswer].GetComponent<Image>();
            buttonImage.sprite=thecorrectAnswerSprite;
 
        }
    }



    void getNextQuestion(){
       if(questions.Count>0){
        SetButtonesState(true);
        SetdefultAnserSprite();
        getrandomeQustion();
        DisplayQuestions();
        
        progressBar.value++;
        scoreKepper.setQuestionSeen();
      }

    }

    private void getrandomeQustion()
    {
       int index = UnityEngine.Random.Range(0,questions.Count);        
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion)){
            questions.Remove(currentQuestion);
        }
            
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
        questionText.text=currentQuestion.GetQuestion();
        for(int i=0;i<answersButton.Length;i++){
          TextMeshProUGUI buttontext =answersButton[i].GetComponentInChildren<TextMeshProUGUI>();
          buttontext.text=currentQuestion.GetAnswer(i);
        }   
    }


    void SetButtonesState(bool state){
        for(int i=0;i<answersButton.Length;i++){
            Button button = answersButton[i].GetComponent<Button>();
            button.interactable=state;
        }

    }
}
