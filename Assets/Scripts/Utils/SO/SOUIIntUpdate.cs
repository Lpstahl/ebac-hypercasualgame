using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTExtValue;
    public GameObject Coin;

    // Start is called before the first frame update
    void Start()
    {
        uiTExtValue.text = soInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTExtValue.text = soInt.value.ToString();
    }
}
