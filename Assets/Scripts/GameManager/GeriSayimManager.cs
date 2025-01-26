using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour {

    [SerializeField]
    private GameObject geriSayimObje;
    [SerializeField]
    private Text geriSayimText;

    GameManager gameManager;
    AudioSource audioSource;

    [SerializeField]
    private AudioClip geriSayim;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start () {
        StartCoroutine(GeriSayRoutine());
        
	}

    IEnumerator GeriSayRoutine()
    {
        audioSource.PlayOneShot(geriSayim);
        geriSayimText.text = "3";
        yield return new WaitForSeconds(0.5f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.6f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriSayimText.text = "2";
        yield return new WaitForSeconds(0.5f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.6f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriSayimText.text = "1";
        yield return new WaitForSeconds(0.5f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.6f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        audioSource.Stop();
        StopAllCoroutines();

        gameManager.OyunaBasla();
    }
	
	
}
