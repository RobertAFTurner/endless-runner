﻿
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    GameObject textObject;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        GlobalGameStats.score += GlobalGameStats.platformSpeed * 100f;
        text.text = "Score: " + GlobalGameStats.score;
    }
}
