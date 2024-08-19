using System;
using TMPro;
using UnityEngine;

namespace OtherScripts
{
    public class ScoreBoard : MonoBehaviour
    {
        public int score = 0;
        private TMP_Text scoreText;

        private void Start()
        {
            scoreText = GetComponent<TMP_Text>();
            scoreText.text = "0";
        }

        public void IncreaseScore(int amountToScore)
        {
            score += amountToScore;
            scoreText.text = score.ToString();
        }

    }
}