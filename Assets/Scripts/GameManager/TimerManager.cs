using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour {


    [SerializeField]
    private Text sureText;
    int kalanSure;

    bool sureSaysinMi;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    void Start () {
        kalanSure = 90;
        sureSaysinMi = true;
        
	}

    public void SureyiBaslat()
    {
        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinMi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinMi = false;
                sureText.text = "";
                gameManager.OyunBitti();

            }

            kalanSure--;
        }
    }

    
	
	
}
