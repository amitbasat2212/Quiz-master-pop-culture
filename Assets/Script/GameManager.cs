using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScript rndsecene;


     void Awake() {
        quiz=FindObjectOfType<Quiz>();
        rndsecene=FindObjectOfType<EndScript>();

    }

    void Start()
    {        
        quiz.gameObject.SetActive(true);
        rndsecene.gameObject.SetActive(false);    
    }

   
    void Update()
    {
        if(quiz.isComplete){
            
            quiz.gameObject.SetActive(false);
            rndsecene.gameObject.SetActive(true);
            rndsecene.SHOWfinaleScore();
        }
    }

    public void onReplayMethod(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
