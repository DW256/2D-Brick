using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public GameObject brickPrefab;
    public Transform brickParent;
    public TextMeshProUGUI messageBar;

    public List<GameObject> bricksList = new List<GameObject>();
    public int xAmount;
    public int yAmount;

    private void Start()
    {
        GenerateBricks();
        int bricksLeft = GameManager.instance.bricksList.Count;
        SetMessage(string.Format("{0} brick{1} left", bricksLeft, (bricksLeft == 1 ? "" : "s")));
    }

    private void GenerateBricks()
    {
        for (int y = 0; y < yAmount; y++)
        {
            for (int x = -(xAmount / 2); x < (xAmount / 2); x++)
            {
                Vector3 pos = new Vector3(1.25f + (x * 2.5f), 1 + (y * 0.5f), 0);
                GameObject brick = Instantiate(brickPrefab, pos, Quaternion.identity, brickParent) as GameObject;
                bricksList.Add(brick);
            }
        }
    }

    public void SetMessage(string message)
    {
        messageBar.text = message;
    }

    public void Lose()
    {
        SetMessage("You Lose");
        Time.timeScale = 0;
    }

    public void Win()
    {
        SetMessage("You Win");
        Time.timeScale = 0;
    }

}
