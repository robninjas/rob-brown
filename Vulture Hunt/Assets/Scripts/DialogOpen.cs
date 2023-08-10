using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private string[] collectibleMessages;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        collectibleMessages = new string[] {
            "Film? FILM? FIIIIIILLLLLLMMMMMMMM FIIIIILLLLMMM",
            "I already got the monkeys and the darts all I need now are bloons.",
            "I need mints or something named after mints",
            "I need a target logo",
            "I'm not addicted! You're addicted to making me feel bad! I can quit whenever I want!",
            "remember when Jordan Peele was in a comedy duo with Mickal Key? I want something to remind me of that.",
            "What phish sounds like",
            "Think \"birdbox\" but not *birdbox*",
            "BWEAW BE BE BE BWEAWW",
            "With a tap of my wand I will make my.. uhh.. where's my hat?"
        };
        createClue();
    }

    public void searchDialogue()
    {
        dialog = collectibleMessages[clue];
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialogue();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "you found " + collectibles[clue] + "YAY";
            end = true;
        }
        else
        {
            dialog = "'zaz n't . " + collectibles[clue] + "!";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
