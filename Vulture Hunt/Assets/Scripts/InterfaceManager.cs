using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public Image seekImage;
    public GameObject npc;
    public GameObject randomSpawn;

    public Image collectible;
    public GameObject showSprite;

    [SerializeField]
    private Sprite[] collectibleSource;

    // Start is called before the first frame update
    void Start()
    {
        //dialogBox.SetActive(true);
        //showSprite.SetActive(false);

        //if (npc.GetComponent<DialogOpen>().begin)
        //{
        //    scatterCoins();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Submit") == 1 && dialogBox.activeInHierarchy == true)
        {
            dialogBox.SetActive(false);
        }
    }

    public void CollectibleUpdate(int item)
    {
        showSprite.SetActive(true);
        collectible.GetComponent<Image>().sprite = collectibleSource[item];
    }

    public void ShowBox(string dialog, int item)
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        seekImage.GetComponent<Image>().sprite = collectibleSource[item];

        if (npc.GetComponent<DialogOpen>().begin)
        {
            scatterCoins();
        }
    }

    public void scatterCoins()
    {
        randomSpawn.GetComponent<RandomSpawn>().DistributeCollectibles();
        npc.GetComponent<DialogOpen>().coinsScattered();
    }
}
