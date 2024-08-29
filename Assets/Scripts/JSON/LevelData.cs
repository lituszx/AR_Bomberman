using UnityEngine;
[System.Serializable]
public class LevelData
{
    public int level;
    public Vector3[] boxes;
    public Vector3[] bricks;
    public EnemyData[] enemies;

    public LevelData Null
    {
        get
        {
            this.level = 0;
            this.boxes = null;
            this.bricks = null;
            this.enemies = null;
            return this;
        }
    }
    public void NewBoxes(int lenght)
    {
        boxes = new Vector3[lenght];
    }
    public void NewBricks(int lenght)
    {
        bricks = new Vector3[lenght];
    }
    public void NewEnemies(int lenght)
    {
        enemies = new EnemyData[lenght];
    }
}
[System.Serializable]
public struct EnemyData
{
    public Vector3 position;
    public Color color;
}
