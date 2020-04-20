using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogeManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI textDialoge;

    public GameObject endOf;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialoge(Dialoge dialoge){
        sentences.Clear();
        foreach(string sentence in dialoge.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialoge();
            return;
        }

        string sentence = sentences.Dequeue();
        textDialoge.text = sentence;
        
    }

    private void EndDialoge()
    {
        endOf.SetActive(false);
    }
}
