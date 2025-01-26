using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour {

    [SerializeField]
    private Text sonucText;

    int puanSure = 10;
    bool sureBittimi = true;
    int toplamPuan, yazdirilacakPuan, artisPuani;

    private void Awake()
    {
        sureBittimi = true;
    }

    private void Start()
    {
        
    }

    public void SonuclariGöster(int puan)
    {

        
        toplamPuan = puan;
        artisPuani = toplamPuan / puanSure;
        StartCoroutine(PuaniYazdirRoutine());
    }

    IEnumerator PuaniYazdirRoutine()
    {
        while (sureBittimi)
        {
            yield return new WaitForSeconds(0.1f);
            yazdirilacakPuan += artisPuani;
            if (yazdirilacakPuan >= toplamPuan)
            {
                yazdirilacakPuan = toplamPuan;
            }
            sonucText.text = yazdirilacakPuan.ToString();
            if (puanSure < 0)
            {
                sureBittimi = false;
            }
            puanSure--;
        }
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
