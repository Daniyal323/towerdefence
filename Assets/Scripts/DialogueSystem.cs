using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private Coroutine typingCoroutine;
    private bool isDialoguebox = true;

    public Button continueButton; 

    // Start is called before the first frame update
    void Start()
    {
        textcomponent.text = string.Empty;
        if (isDialoguebox ==true)
        {
            Time.timeScale = 0;
        }
        StartDialogue();

        continueButton.onClick.AddListener(ContinueButtonClicked);
    }

    void ContinueButtonClicked()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            textcomponent.text = lines[index]; 
            typingCoroutine = null; 
        }
        else if (index < lines.Length - 1)
        {
            NextLine();
        }
        else
        {
            isDialoguebox = false;
            if(isDialoguebox == false)
            {
                Time.timeScale = 1;
            }
            gameObject.SetActive(false);
        }
    }

    void StartDialogue()
    {
        index = 0;
        isDialoguebox = true;
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        typingCoroutine = null;
    }

    void NextLine()
    {
        index++;
        textcomponent.text = string.Empty;
        typingCoroutine = StartCoroutine(TypeLine());
    }
}
