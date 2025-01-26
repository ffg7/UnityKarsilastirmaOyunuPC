using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject puanSurePaneli;

    [SerializeField]
    private GameObject pausePaneli;

    [SerializeField]
    private GameObject puaniKapPaneli,buyukOlaniSecYazisi,sonucPaneli;
    [SerializeField]
    private GameObject ustDikdortgen;
    [SerializeField]
    private GameObject altDikdortgen;

    [SerializeField]
    private Text ustText, altText, puanText;


    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager trueFalseManager;
    SonucManager sonucManager;

    int oyunSayac, kacinciOyun;
    int ustDeger, altDeger, buyukDeger;
    int butonDegeri;
    int toplamPuan, artisPuanı;

    AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi, dogruSesi, yanlisSesi, bitisSesi;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
        dairelerManager = Object.FindObjectOfType<DairelerManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start () {
        oyunSayac = 0;
        kacinciOyun = 0;
        ustText.text = "";
        altText.text = "";
        puanText.text = "0";
        toplamPuan = 0;
        SahneEkraniniGuncelle();
	}

    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puaniKapPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
    }

    public void OyunaBasla()
    {
        audioSource.PlayOneShot(baslangicSesi);
        puaniKapPaneli.GetComponent<CanvasGroup>().DOFade(0, 1f);
        buyukOlaniSecYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);
        KacinciOyun();
        timerManager.SureyiBaslat();

    }

    void KacinciOyun()
    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
            artisPuanı = 25;
        }
        else if (oyunSayac >= 5 && oyunSayac < 10)
        {
            kacinciOyun = 2;
            artisPuanı = 50;
        }
        else if (oyunSayac >= 10 && oyunSayac < 15)
        {
            kacinciOyun = 3;
            artisPuanı = 75;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
            artisPuanı = 100;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
            artisPuanı = 125;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6);
            artisPuanı = 150;
        }

        switch (kacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;
            case 2:
                İkinciFonksiyon();
                break;
            case 3:
                UcuncuFonksiyon();
                break;
            case 4:
                DorduncuFonksiyon();
                break;
            case 5:
                BesinciFonksiyon();
                break;
            }
    }

    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(0, 50);

        if (rastgeleDeger <= 25)
        {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 15);
        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 15));
        }

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            BirinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();

        
    }

    void İkinciFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        ustText.text = birinciSayi + " + " + ikinciSayi;
        altDeger = ucuncuSayi + dorduncuSayi;
        altText.text = ucuncuSayi + " + " + dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            İkinciFonksiyon();
            return;
        }
    }
    void UcuncuFonksiyon()
    {
        int birinciSayi = Random.Range(11, 40);
        int ikinciSayi = Random.Range(1, 11);
        int ucuncuSayi = Random.Range(11, 40);
        int dorduncuSayi = Random.Range(1, 11);

        ustDeger = birinciSayi - ikinciSayi;
        ustText.text = birinciSayi + " - " + ikinciSayi;
        altDeger = ucuncuSayi - dorduncuSayi;
        altText.text = ucuncuSayi + " - " + dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            UcuncuFonksiyon();
            return;
        }
    }

    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 10);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 10);

        ustDeger = birinciSayi * ikinciSayi;
        ustText.text = birinciSayi + " * " + ikinciSayi;
        altDeger = ucuncuSayi * dorduncuSayi;
        altText.text = ucuncuSayi + " * " + dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            DorduncuFonksiyon();
            return;
        }
    }
    
    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);
        int bolunen1 = bolen1 * ustDeger;
        ustText.text = bolunen1 + " / " + bolen1;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);
        int bolunen2 = bolen2 * altDeger;
        altText.text = bolunen2+ " / " + bolen2;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            BesinciFonksiyon();
            return;
        }


    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if (butonAdi == "ustButon")
        {
            butonDegeri = ustDeger;
        }
        else if (butonAdi == "altButon")
        {
            butonDegeri = altDeger;
        }

        if (butonDegeri == buyukDeger)
        {
            
            dairelerManager.DairelerinScalaAc(oyunSayac % 5);
            oyunSayac++;
            trueFalseManager.TrueFalseScaleAc(true);
            toplamPuan += artisPuanı;
            puanText.text = toplamPuan.ToString();
            audioSource.PlayOneShot(dogruSesi);
            KacinciOyun();
        }
        else
        {
            trueFalseManager.TrueFalseScaleAc(false);
            HatayaGoreSayaciAzalt();
            toplamPuan -= artisPuanı;
            puanText.text = toplamPuan.ToString();
            audioSource.PlayOneShot(yanlisSesi);
            KacinciOyun();
        }
    }

    void HatayaGoreSayaciAzalt()
    {
        oyunSayac -= (oyunSayac % 5 + 5);

        if (oyunSayac < 0)
        {
            oyunSayac = 0;
        }

        dairelerManager.DairelerinScalaKapat();
    }

    public void PausePaneliniAc()
    {
        pausePaneli.SetActive(true);
    }

    public void OyunBitti()
    {
        audioSource.PlayOneShot(bitisSesi);
        sonucPaneli.SetActive(true);

        sonucManager = Object.FindObjectOfType<SonucManager>();

        sonucManager.SonuclariGöster(toplamPuan);
        
    }
	
	
}
