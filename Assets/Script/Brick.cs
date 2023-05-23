using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameManager.instance.bricksList.Remove(gameObject);

            int bricksLeft = GameManager.instance.bricksList.Count;
            if (bricksLeft <= 0)
            {
                GameManager.instance.Win();
            }
            else
            {
                GameManager.instance.SetMessage(string.Format("{0} brick{1} left", bricksLeft, (bricksLeft==1?"":"s") ));
            }

            Destroy(gameObject);
        }
    }
}
