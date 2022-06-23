using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Gameplay : MonoBehaviour
{
    private string correctPassword;
    public List<TextMeshProUGUI> numberBoxes = new List<TextMeshProUGUI>();
    public int currentNumBox;
    private int isWrong = 0;
    public int finalTime;
    public Timer timer;
    public Score score;
    public PopupWindow popupWindow;
    public AudioSource coreMusic;
    public AudioSource winSound;
    public AudioSource TickingSound;

    // Start is called before the first frame update
    void Start()
    {
        correctPassword = GetPassword();
    }


    string GetPassword()
    {
        string password = "";
        int num;
        for(int i=0; i<4; i++)
        {
            num = Random.Range(0, 10); 
            while (password.Contains(num.ToString()))
            {
              num = Random.Range(0, 10);  
            }
            password += num.ToString();
        }
        Debug.Log(password);
        return password;
    }

    public void AddNumberToDisplay(string num)
    {
        if( numberBoxes[currentNumBox].text.Length < 4)
        {
            numberBoxes[currentNumBox].text += num.ToString();
        }
    }

    public void CheckPassword()
    {
        string newText = "";
        string oldText = numberBoxes[currentNumBox].text;
        string tempPassword = correctPassword;
        for(int i=0; i<4; i++)
        {
            string digit = numberBoxes[currentNumBox].text[i].ToString();
            int frequency = 0;
            int correctSpot = 0;


            for(int j=0; j<4; j++)
            {
                if(digit == tempPassword[j].ToString())
                {
                    frequency++;
                    if(i==j)
                    {
                        correctSpot = 1;
                    }
                }

            }

            if(frequency == 0)
            {
                newText += "<color=#A9A9A9>" + digit.ToString() + "</color>";
            }
            else if(correctSpot==1)
            {
                newText += "<color=#00FF00>" + digit.ToString() + "</color>";
            }
            else
            {
                newText += "<color=#FFA500>" + digit.ToString() + "</color>";
            }

        }

        numberBoxes[currentNumBox].text = newText;

        if(oldText == correctPassword)
        {
            isWrong = 0;
            finalTime = Mathf.RoundToInt(timer.timeValue);
            score.CalculateScore();
            popupWindow.OpenPopUp();
            coreMusic.Stop();
            TickingSound.Stop();

            winSound.Play();
            //SceneManager.LoadScene("Win Screen");

        }
        else
        {
            isWrong = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentNumBox >= 5 && isWrong == 1)
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }
}
