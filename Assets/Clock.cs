using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;
    public bool continuous;

    float timer;
    int seconds;
    int minutes;
    int hours;

    const float degreesPerHour = 30;
    const float degreesPerMinute = 6;
    const float degreesPerSecond = 6;

    

    // Update is called once per frame
    void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }

        /*
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;

            secondHand.Rotate(new Vector3(0, 0, 6));

            seconds += 1;
            if (seconds >= 60)
            {
                seconds = 0;

                minuteHand.Rotate(new Vector3(0, 0, 6));

                minutes += 1;
                if (minutes >= 60)
                {
                    minutes = 0;

                    hourHand.Rotate(new Vector3(0, 0, 30));

                    hours += 1;

                    if (hours >= 12)
                    {
                        hours = 0;
                    }
                }
            }
        }
        */
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourHand.localRotation = Quaternion.Euler(0, 0, (float)time.TotalHours * degreesPerHour);
        minuteHand.localRotation = Quaternion.Euler(0, 0, (float)time.TotalMinutes * degreesPerMinute);
        secondHand.localRotation = Quaternion.Euler(0, 0, (float)time.TotalSeconds * degreesPerSecond);
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        secondHand.localRotation = Quaternion.Euler(0, 0, time.Second * 6);
        minuteHand.localRotation = Quaternion.Euler(0, 0, time.Minute * 6);
        hourHand.localRotation = Quaternion.Euler(0, 0, time.Hour * 30);
    }
}
