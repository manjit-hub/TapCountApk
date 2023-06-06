using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
using System.Threading;

public class TimerScript : MonoBehaviour
{
    public float CurrentTime = 0f;
    public float StartingTime;

    public Text CountDownText;
    public GamePlayUI gamePlayUI; 
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -=1*Time.deltaTime;
        CountDownText.text = CurrentTime.ToString("0");

        if(CurrentTime <=0)
        {
            CurrentTime=0;
        }
    }
}
