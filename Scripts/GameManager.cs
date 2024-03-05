using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance {  get; private set; }


    public Text healthText;

    public int health = 100;

    private void Awake()
    {
        
        instance = this; 
    }

    private void Update()
    {
        healthText.text = health.ToString();
    }





















}
