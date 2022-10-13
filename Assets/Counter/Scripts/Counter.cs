using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    private GameManager gameManager;
    private int Count = 0;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Count = 0;
        StartCoroutine(MyCoroutine());

    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        gameManager.GameOver();
    }

    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Test");
        StartCoroutine(MyCoroutine());
    }
}
