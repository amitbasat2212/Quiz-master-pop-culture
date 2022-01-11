using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionsSo questions;

    // Start is called before the first frame update
    void Start()
    {
        questionText.text=questions.GetQuestion();
    }

    
}
