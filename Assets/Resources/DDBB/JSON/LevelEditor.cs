using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject prefabBrick;
    public GameObject prefabBox;
    public GameObject enemyYellow, enemyRed, enemyBlue;
    [Header("Enemy Colors")]
    public Color enemyYellowColor, enemyRedColor, enemyBlueColor;
    [Header("Transforms references")]
    public Transform bricksParent;
    public Transform boxesParent;
    public Transform enemiesParent;
    ////////////////////////////////////
    [Header("Data Info")]
    private LevelData _levelData = new LevelData();
    public LevelData LevelData
    {
        set { _levelData = value; }
        get { return _levelData; }
    }
    public void SetBoxes()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        _levelData.NewBoxes(boxes.Length);
        for (int i = 0; i < boxes.Length; i++)
        {
            _levelData.boxes[i] = boxes[i].transform.position;
        }
    }
    public void SetBricks()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag(Constants.TAG_BRICK);
        _levelData.NewBricks(bricks.Length);
        for (int i = 0; i < bricks.Length; i++)
        {
            _levelData.bricks[i] = bricks[i].transform.position;
        }
    }
    public void SetEnemys()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.TAG_ENEMY);
        _levelData.NewEnemies(enemies.Length);
        for (int i = 0; i < enemies.Length; i++)
        {
            _levelData.enemies[i].position = enemies[i].transform.position;
            _levelData.enemies[i].color = enemies[i].GetComponent<MeshRenderer>().sharedMaterial.color;
        }
    }
    public void SaveData()
    {
        JSONDDBB.SaveFile(_levelData);
    }
    public void LoadData()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag(Constants.TAG_BRICK);
        for (int i = 0; i < bricks.Length; i++)
        {
            DestroyImmediate(bricks[i].gameObject);
        }
        Box[] boxes = FindObjectsOfType<Box>();
        for (int i = 0; i < boxes.Length; i++)
        {
            DestroyImmediate(boxes[i].gameObject);
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.TAG_ENEMY);
        for (int i = 0; i < enemies.Length; i++)
        {
            DestroyImmediate(enemies[i].gameObject);
        }
        _levelData = JSONDDBB.LoadData(_levelData.level);
        if(_levelData.bricks != null)
        {
            for (int i = 0; i < _levelData.bricks.Length; i++)
            {
                Instantiate(prefabBrick, _levelData.bricks[i], Quaternion.identity, bricksParent);
            }
        }
        if (_levelData.boxes != null)
        {
            for (int i = 0; i < _levelData.boxes.Length; i++)
            {
                Instantiate(prefabBox, _levelData.boxes[i], Quaternion.identity, boxesParent);
            }
        }
        if(_levelData.enemies != null)
        {
            for (int i = 0; i < _levelData.enemies.Length; i++)
            {
                if(_levelData.enemies[i].color == enemyYellowColor)
                {
                    Instantiate(enemyYellow, _levelData.enemies[i].position, Quaternion.identity, enemiesParent);
                }
                else if (_levelData.enemies[i].color == enemyRedColor)
                {
                    Instantiate(enemyRed, _levelData.enemies[i].position, Quaternion.identity, enemiesParent);
                }
                else if (_levelData.enemies[i].color == enemyBlueColor)
                {
                    Instantiate(enemyBlue, _levelData.enemies[i].position, Quaternion.identity, enemiesParent);
                }
            }
        }
    }
}
