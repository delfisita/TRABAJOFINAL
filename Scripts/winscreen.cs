using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winscreen : MonoBehaviour
{

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }

        Debug.Log(enemies.Length);
    }
}