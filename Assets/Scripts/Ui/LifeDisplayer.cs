using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplayer : MonoBehaviour
{
    [SerializeField] GameObject[] lifeImages;
    [SerializeField] Text lifeLabel;
    
    void Start()
    {
        LifeManager lifeManager = LifeManager.Instance;
        lifeManager.OnLivesCountChanged += UpdateLivesCounter;
    }

    void UpdateLivesCounter(int lives)
    {
        for (int i = Mathf.Max(0, lives - 1); i < lifeImages.Length; i++)
            lifeImages[i].SetActive(false);
        lifeLabel.text = lives.ToString();
    }

}
