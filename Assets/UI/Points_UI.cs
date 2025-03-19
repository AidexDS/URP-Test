using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points_UI : MonoBehaviour
{
    public InteractionTest interTest;
    
    public TextMeshProUGUI Textelement;


void Update()
{
    Textelement.text = interTest.points.ToString();
}    

   
}
