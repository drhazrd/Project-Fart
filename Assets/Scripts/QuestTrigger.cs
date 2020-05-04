using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestTrigger : MonoBehaviour
{
    //    public Quest quest;

    public Quest quest;
    public PlayerStats player;
    public GameObject questWindow;

    public Text questTitleText;
    public Text questDesriptionText;
    public GameObject questImageHolder;
    public Text questExpText;
    public Text questScoreText;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        questDesriptionText.text = quest.questDesription;
        questTitleText.text = quest.questTitle;
        questExpText.text = quest.questExp.ToString();
        questScoreText.text = quest.questExp.ToString();
    }
    public void AcceptQuest()
    {
        questWindow.SetActive(true);
        quest.isActive = true;
        player.quest = quest;
    }
}
