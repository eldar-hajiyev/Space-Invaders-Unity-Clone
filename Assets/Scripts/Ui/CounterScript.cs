using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

    private Text counterLabel;

    void Awake () {
        counterLabel = GetComponent<Text> ();
    }

    public IEnumerator GameStartTimer(int startSeconds) {
        var waiter = new WaitForSeconds(1f);
        for (int i = 0; i < startSeconds; i++)
        {
            counterLabel.text = (startSeconds - i).ToString();
            yield return waiter;
        }
        counterLabel.text = "";
    }
}