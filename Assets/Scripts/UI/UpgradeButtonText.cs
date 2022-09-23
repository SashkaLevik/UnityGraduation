using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonText : MonoBehaviour
{
    [SerializeField] private GameObject _buttonText;
    

    public void OnMouseEnter()
    {
        _buttonText.SetActive(true);
    }

    public void OnMouseExit()
    {
        _buttonText.SetActive(false);
    }
}
