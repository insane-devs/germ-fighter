using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBookManager : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page9;
    public GameObject page10;

    private int pageCtr;

    public void nextPage()
    {
        if (pageCtr < 5) pageCtr += 1;
    }

    public void prevPage()
    {
        if (pageCtr > 1) pageCtr -= 1;
    }

    void Start()
    {
        pageCtr = 1;
    }

    void Update()
    {
        switch (pageCtr)
        {
            case 1:
                page1.SetActive(true);
                page2.SetActive(true);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
                page6.SetActive(false);
                page7.SetActive(false);
                page8.SetActive(false);
                page9.SetActive(false);
                page10.SetActive(false);
                break;
            case 2:
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(true);
                page4.SetActive(true);
                page5.SetActive(false);
                page6.SetActive(false);
                page7.SetActive(false);
                page8.SetActive(false);
                page9.SetActive(false);
                page10.SetActive(false);
                break;
            case 3:
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(true);
                page6.SetActive(true);
                page7.SetActive(false);
                page8.SetActive(false);
                page9.SetActive(false);
                page10.SetActive(false);
                break;
            case 4:
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
                page6.SetActive(false);
                page7.SetActive(true);
                page8.SetActive(true);
                page9.SetActive(false);
                page10.SetActive(false);
                break;
            case 5:
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
                page6.SetActive(false);
                page7.SetActive(false);
                page8.SetActive(false);
                page9.SetActive(true);
                page10.SetActive(true);
                break;
        }
    }
}
