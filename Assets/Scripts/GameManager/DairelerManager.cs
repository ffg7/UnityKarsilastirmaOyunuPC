using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DairelerManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] dairelerDizisi;

	void Start () {
        DairelerinScalaKapat();
	}
	
	public void DairelerinScalaKapat()
    {
        foreach (GameObject daire in dairelerDizisi)
        {
            daire.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    public void DairelerinScalaAc(int hangiDaire)
    {
        dairelerDizisi[hangiDaire].GetComponent<RectTransform>().DOScale(1, 0.3f);

        if (hangiDaire % 5 == 0)
        {
            DairelerinScalaKapat();
        }
    }
}
