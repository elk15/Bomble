using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    public List<Button> numberKeys = new List<Button>();
    public Button okKey;
    public Button delKey;
    private string numbers = "1234567890";
    public Gameplay gameplay;
    public Timer timer;


    void Start()
    {
        SetupKeys();
    }

    void SetupKeys()
    {
        for(int i = 0; i < numberKeys.Count; i++)
        {
            numberKeys[i].transform.GetChild(0).GetComponent<Text>().text = numbers[i].ToString();
        }

        foreach (var key in numberKeys)
        {
            string number = key.transform.GetChild(0).GetComponent<Text>().text;
            key.GetComponent<Button>().onClick.AddListener(() => ClickNumKey(number));
        }

        okKey.GetComponent<Button>().onClick.AddListener(() => ClickOkKey());
        delKey.GetComponent<Button>().onClick.AddListener(() => ClickDelKey());
    }

    public void ClickOkKey()
    {
        if(gameplay.currentNumBox < 5 && gameplay.numberBoxes[gameplay.currentNumBox].text.Length == 4)
        {
            gameplay.CheckPassword();
            gameplay.currentNumBox++;
        }
    }

    public void ClickDelKey()
    {
        if(gameplay.numberBoxes[gameplay.currentNumBox].text.Length > 0)
        {
            string result = gameplay.numberBoxes[gameplay.currentNumBox].text.Remove(gameplay.numberBoxes[gameplay.currentNumBox].text.Length-1);
            gameplay.numberBoxes[gameplay.currentNumBox].text = result;
        }
    }

    public void ClickNumKey(string numKey)
    {
        // Debug.Log(numKey);
        if(gameplay.currentNumBox < 5)
        {
            gameplay.AddNumberToDisplay(numKey);
        }
    }

    void Update()
    {
        
    }
}
