using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

    public TMP_Text dialogueText;

    public float wordSpeed;
    int index = 0;


    void Start(){
        StartDialogue();
    }

    public void StartDialogue(){
        if(sentences!=null)
            dialogueText.text = sentences[0];
    }

    IEnumerator Typing(){
        foreach(char letter in sentences[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine(){
        Debug.Log("Next Line");
        if(index<sentences.Length-1){
            index++;
            dialogueText.text ="";
            StartCoroutine(Typing());
        }
    }
    
}
