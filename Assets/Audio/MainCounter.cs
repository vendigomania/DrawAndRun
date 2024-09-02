using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MainCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Transform npcRoot;

    [SerializeField] private UnityEvent OnLose = new UnityEvent();

    public static MainCounter Instance { get; private set; }


    private int peopleCount = 0;
    public int PeopleCount
    {
        get => peopleCount;
        set
        {
            peopleCount = value;
            if(value <= 0)
            {
                OnLose.Invoke();
            }
        }
    }

    public int Level
    {
        get => PlayerPrefs.GetInt("Level", 1);
        set
        {
            PlayerPrefs.SetInt("Level", Mathf.Max(value, 1));
            levelText.text = Level.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        levelText.text = Level.ToString();
    }

    public void CheckPeopleCount()
    {
        PeopleCount = npcRoot.childCount;
    }
}
