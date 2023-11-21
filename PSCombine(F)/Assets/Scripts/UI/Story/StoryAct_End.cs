using KoreanTyper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryAct_End : MonoBehaviour
{
    [SerializeField] private GameObject skipBtn;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject[] scene;

    [SerializeField] private Text[] textBox;
    [SerializeField] private Text[] outtroTexts;

    private bool isActive_s1 = true;
    private bool isActive_s2 = true;
    private bool isActive_s3 = true;

    private void Start()
    {
        skipBtn.SetActive(false);
        dialog.SetActive(false);
        scene[0].SetActive(true);

        for (int i = 1; i < scene.Length; i++)
        {
            scene[i].SetActive(false);
        }

        StartCoroutine(Take1());
        StopCoroutine(Take1());
    }

    private void Update()
    {
        if (!isActive_s1)
        {
            scene[1].SetActive(false);
            scene[2].SetActive(true);
            isActive_s1 = true;

            StartCoroutine(Take2());
            StopCoroutine(Take2());
        }
        else if (!isActive_s2)
        {
            scene[4].SetActive(false);
            scene[5].SetActive(true);

            isActive_s2 = true;

            StartCoroutine(Take3());
            StopCoroutine(Take3());

        }
        else if (!isActive_s3)
        {
            SceneManager.LoadScene("Victory");
        }

    }

    IEnumerator Take1()
    {
        string[] strings = new string[3]{ "Űű... �� ������ ���̾�...",
                                          "�� ��������ΰ�...",
                                          "ũ�ƾ�..."};

        foreach (Text t in textBox)
            t.text = "";

        dialog.SetActive(true);
        skipBtn.SetActive(true);

        for (int t = 0; t < textBox.Length && t < strings.Length; t++)
        {
            int strTypingLength = strings[t].GetTypingLength();

            for (int i = 0; i <= strTypingLength; i++)
            {
                textBox[t].text = strings[t].Typing(i);
                yield return YieldCache.WaitForSeconds(0.05f);
            }

            yield return YieldCache.WaitForSeconds(1.5f);

            switch (t)
            {
                case 1:
                    scene[0].SetActive(false);
                    scene[1].SetActive(true);

                    yield return YieldCache.WaitForSeconds(1f);
                    break;
            }
        }

        yield return YieldCache.WaitForSeconds(2f);

        isActive_s1 = false;
    }

    IEnumerator Take2()
    {
        string[] strings = new string[2]{ "��... ��ġ����? ���� �����ǰ�?",
                                          "�� �ڳ� �����ϼ�, �ڳ��� �Ƿ°� ���� ���� �̰ܳ¾�! �����߳�!"};

        foreach (Text t in textBox)
            t.text = "";


        for (int t = 0; t < textBox.Length && t < strings.Length; t++)
        {
            int strTypingLength = strings[t].GetTypingLength();

            for (int i = 0; i <= strTypingLength; i++)
            {
                textBox[t].text = strings[t].Typing(i);
                yield return YieldCache.WaitForSeconds(0.05f);
            }

            yield return YieldCache.WaitForSeconds(1.5f);

            switch (t)
            {
                case 0:
                    scene[2].SetActive(false);
                    scene[3].SetActive(true);
                    break;
            }
        }
        dialog.SetActive(false);
        scene[3].SetActive(false);
        scene[4].SetActive(true);

        yield return YieldCache.WaitForSeconds(2f);

        isActive_s2 = false;
    }

    IEnumerator Take3()
    {
        string[] strings = new string[3]{ "�׷��� �ڱ׸��� �Ҿ��� ���۵�",
                                          "1�⿡ ��ģ �⳪�� ������",
                                          "���̳���."};

        foreach (Text t in outtroTexts)
            t.text = "";

        for (int t = 0; t < outtroTexts.Length && t < strings.Length; t++)
        {
            int strTypingLength = strings[t].GetTypingLength();

            for (int i = 0; i <= strTypingLength; i++)
            {
                outtroTexts[t].text = strings[t].Typing(i);
                yield return YieldCache.WaitForSeconds(0.06f);
            }

            yield return YieldCache.WaitForSeconds(1f);
        }

        yield return YieldCache.WaitForSeconds(1.5f);

        isActive_s3 = false;
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("Victory");
    }


}