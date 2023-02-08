using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using System.Drawing;

public class ResourceBar : MonoBehaviour
{
   
    [SerializeField] private Image bar;
    [SerializeField] public float barSize;
    [SerializeField] public Vector2 barRatio;
    public Vector3 Pos { get; private set; }
    public UnityEngine.Color color;
    private static RectTransform rt;
    private static Slider slider;
    void Start()
    {
        rt = GetComponent<RectTransform>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            slider.value = 100;
            slider.maxValue = 100;
            rt.sizeDelta = barRatio * barSize;
            rt.SetLocalPositionAndRotation(Pos, Quaternion.identity);
        }
       

    }

    public void AssignHealth(float hp)
    {
        //health = hp;
    }

    public void SetSize(float size)
    {
        barSize = size;
    }

    public void InitBar()
    {
        slider.colors.disabledColor.Equals(color);
        slider.colors.normalColor.Equals(color);
    }

    public void SetPos(Vector3 pos)
    {
        Pos = pos;
    }

}
