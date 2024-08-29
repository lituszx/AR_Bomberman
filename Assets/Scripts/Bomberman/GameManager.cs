using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Vector3>    bricksPositions = new List<Vector3>();
    public List<Vector3>    boxes;

    public Text             scoreText;
    public Text             textWin, textLoose;
    private int[]           powerups = new int[(int)BoxGift.NONE];
    private int             _score = 0;

    public CustomController horizontal, vertical;

    private void Awake()
    {

        Screen.orientation = ScreenOrientation.Landscape;

        powerups[(int)BoxGift.SPEED] = 2;
        powerups[(int)BoxGift.BOMB]  = 2;
        powerups[(int)BoxGift.RANGE] = 2;
        powerups[(int)BoxGift.EXIT]  = 1;

        GameObject[] bricks = GameObject.FindGameObjectsWithTag(Constants.TAG_BRICK);
        for (int i = 0; i < bricks.Length; i++)
        {
            bricksPositions.Add(bricks[i].transform.position);
        }

        Box[] allBoxes = GameObject.FindObjectsOfType<Box>();

        for (int i = 0; i < allBoxes.Length; i++)
        {
            int tmp = Random.Range(0, 100);
            if (tmp < 90 && powerups[(int)BoxGift.SPEED] > 0)
            {
                powerups[(int)BoxGift.SPEED]--;
                allBoxes[i].gift = BoxGift.SPEED;
            }
            else if (tmp < 80 && powerups[(int)BoxGift.BOMB] > 0)
            {
                powerups[(int)BoxGift.BOMB]--;
                allBoxes[i].gift = BoxGift.BOMB;
            }
            else if (tmp < 70 && powerups[(int)BoxGift.RANGE] > 0)
            {
                powerups[(int)BoxGift.RANGE]--;
                allBoxes[i].gift = BoxGift.RANGE;
            }
            else if (tmp < 10 && powerups[(int)BoxGift.EXIT] > 0)
            {
                powerups[(int)BoxGift.EXIT]--;
                allBoxes[i].gift = BoxGift.EXIT;
            }

            boxes.Add(allBoxes[i].transform.position);
        }

        if (powerups[(int)BoxGift.EXIT] > 0)
        {
            powerups[(int)BoxGift.EXIT]--;
            allBoxes[allBoxes.Length-1].gift = BoxGift.EXIT;
        }
    }


    public bool IsOutOfBricks(Vector3 newPos, int limit = Constants.SCENERY_LIMIT)
    {

        if (newPos.x < -limit || newPos.x > limit)
            return true;

        if (newPos.z < -limit || newPos.z > limit)
            return true;

        return (bricksPositions.Contains(newPos));
    }


    public bool IsOutOfBoxes(Vector3 newPos, int limit = Constants.SCENERY_LIMIT)
    {
        return (boxes.Contains(newPos));
    }


    public void SetScore(int value = 0)
    {
        _score = value;
        scoreText.text = _score.ToString();
    }

    public void AddPoints(int value = 0)
    {
        _score += value;
        scoreText.text = _score.ToString();
    }


    public void RemoveBox(Vector3 pos)
    {
        boxes.Remove(pos);
    }

    public void Win()
    {
        textWin.gameObject.SetActive(true);
        StartCoroutine(ReturnToMenu());
    }

    public void Loose()
    {
        textLoose.gameObject.SetActive(true);
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        ScriptableDDBB.Instance.ClearList();
        yield return new WaitForSeconds(Constants.BACK_TO_MENU_TIME);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
