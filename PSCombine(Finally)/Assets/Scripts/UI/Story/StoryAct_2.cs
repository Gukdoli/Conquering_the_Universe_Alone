using KoreanTyper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryAct_2 : MonoBehaviour
{
    [SerializeField] private GameObject skipBtn;
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject[] scene;

    [SerializeField] private Text[] textBox;

    private bool isActive_s1 = true;
    private bool isActive_s2 = true;
    private bool isActive_s3 = true;

    private void Start()
    {
        skipBtn.SetActive(false);
        dialog.SetActive(false);
        scene[0].SetActive(true);

        for(int i = 1; i < scene.Length; i++)
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
            scene[0].SetActive(false);
            scene[2].SetActive(true);

            isActive_s1 = true;

            StartCoroutine(Take2());
            StopCoroutine(Take2());
        }
        else if (!isActive_s2)
        {
            scene[4].SetActive(false);
            scene[1].SetActive(true);

            isActive_s2 = true;

            StartCoroutine(Take3());
            StopCoroutine(Take3());

        }
        else if (!isActive_s3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    IEnumerator Take1()
    {
        string[] strings = new string[4]{ "�ӹ��� ���� �Ǹ��ϰ� �ϼ��߱�!",
                                          "������ ���� �����ϱ� �Ϸ�...",
                                          "���� ���� ���ΰ� ������ �˾ƾ���.",
                                          "���� �ı��� ������ ������ ������ �˾ƿ��Գ�."};

        foreach (Text t in textBox)
            t.text = "";

        skipBtn.SetActive(true);
        dialog.SetActive(true);

        for (int t = 0; t < textBox.Length && t < strings.Length; t++)
        {
            int strTypingLength = strings[t].GetTypingLength();

            for (int i = 0; i <= strTypingLength; i++)
            {
                textBox[t].text = strings[t].Typing(i);
                yield return YieldCache.WaitForSeconds(0.05f);
            }

            yield return YieldCache.WaitForSeconds(1.5f);
        }
        
        yield return YieldCache.WaitForSeconds(2f);

        dialog.SetActive(false);

        isActive_s1 = false;
    }

    IEnumerator Take2()
    {
        string[] strings = new string[4]{ "���� ħ������ �ٸ� ������ ���ּ�...?",
                                          "�̷��� ��Ը� ������ ������ �ִٴ�...",
                                          "����ü �������� �Ͼ�� �ִ°���?",
                                          "�� ���ο� �˷��� �ھ�..."};

        foreach (Text t in textBox)
            t.text = "";


        yield return YieldCache.WaitForSeconds(2f);
        scene[2].SetActive(false);
        scene[3].SetActive(true);

        yield return YieldCache.WaitForSeconds(2f);
        scene[3].SetActive(false);
        scene[4].SetActive(true);
        dialog.SetActive(true);

        for (int t = 0; t < textBox.Length && t < strings.Length; t++)
        {
            int strTypingLength = strings[t].GetTypingLength();

            for (int i = 0; i <= strTypingLength; i++)
            {
                textBox[t].text = strings[t].Typing(i);
                yield return YieldCache.WaitForSeconds(0.05f);
            }

            yield return YieldCache.WaitForSeconds(1.5f);
        }

        yield return YieldCache.WaitForSeconds(2f);

        dialog.SetActive(false);

        isActive_s2 = false;
    }

    IEnumerator Take3()
    {
        string[] strings = new string[4]{ "��Ȯ�� ���� ��Ը� ������ �ı��� ������ �������Դϴ�!",
                                          "��... �׷��� ������...",
                                          "�̹����� ���� �̼��̴�. ���� ������ �����ϰ� ���� �߰��ϴ� ��� �ı��϶�",
                                          "ŰŰű, �� ������ �߹��� ó����."};

        foreach (Text t in textBox)
            t.text = "";

        yield return YieldCache.WaitForSeconds(2f);
        dialog.SetActive(true);
        scene[1].SetActive(false);
        scene[5].SetActive(true);

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
                    scene[5].SetActive(false);
                    scene[0].SetActive(true);
                    break;

                case 2:
                    yield return YieldCache.WaitForSeconds(2f);
                    dialog.SetActive(false);
                    scene[0].SetActive(false);
                    scene[2].SetActive(true);

                    yield return YieldCache.WaitForSeconds(2f);
                    dialog.SetActive(true);
                    scene[2].SetActive(false);
                    scene[6].SetActive(true);

                    break;
                case 3:
                    scene[5].SetActive(false);
                    scene[0].SetActive(true);
                    break;
            }
        }

        yield return YieldCache.WaitForSeconds(4f);

        isActive_s3 = false;
    }

    public void SkipButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
