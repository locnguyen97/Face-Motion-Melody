using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgContent : MonoBehaviour
{
    [SerializeField] private UiManager _uiManager;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener((() =>
        {
            _uiManager.HideList(GetComponent<Image>().sprite);
        }));
    }
}
