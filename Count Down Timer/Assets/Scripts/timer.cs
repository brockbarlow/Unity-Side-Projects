using UnityEngine;
using System.Collections;

//using delta time

public class timer : MonoBehaviour
{
    public float countdownValue = 10;
    public float countdown;

    void Start()
    {
        countdown = countdownValue;
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        while (countdown >= 0)
        {
            Debug.Log(countdown);
            yield return null;
            countdown -= Time.deltaTime;
        }

        if (countdown < 0)
        {
            countdown = 0f;
        }
    }
}

//----------------------------------------------------------//
//without using delta time

//public class timer : MonoBehaviour
//{
//    public float countdownValue = 10;
//    public float countdown;

//    void Start()
//    {
//        StartCoroutine(StartCountdown());
//    }

//    public IEnumerator StartCountdown()
//    {
//        countdown = countdownValue;

//        while (countdown >= 0)
//        {
//            Debug.Log(countdown);
//            yield return new WaitForSeconds(1.0f);
//            countdown--;
//        }
//    }
//}
//----------------------------------------------------------//