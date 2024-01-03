using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private Image imgShow;
    [SerializeField] private Transform list;
    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            btn.interactable = false;
            ShowPanel();
        });
    }

    private void ShowPanel()
    {
        
        list.DOScaleY(1, 0.25f);
    }

    public void HideList(Sprite spr)
    {
        list.DOScaleY(0, 0.25f);
        imgShow.sprite = spr;
        imgShow.transform.DOScaleY(1, 0.25f).OnComplete(() =>
        {
            ScaleImg();
        });
        Invoke(nameof(HideImg),Random.Range(3.5f,8.2f));
        
        
    }

    void ScaleImg()
    {
        imgShow.transform.DOScale(Vector3.one * 1.2f, 0.5f).OnComplete(() =>
        {
            imgShow.transform.DOScale(Vector3.one, 0.5f).OnComplete(() => { ScaleImg(); });
        });
    }

    void HideImg()
    {
        DOTween.KillAll(imgShow);
        imgShow.transform.DOScaleY(0, 0.15f).OnComplete(() =>
        {
            list.DOScaleY(1, 0.15f);
            //btn.interactable = true;
        });
    }
}
