public static class Constants
{
    //config values
    public const float  INCREMENT_BOMB_ANIMATION = 0.1f;
    public const float  POWERUP_Y_POSITION       = 0.1f;
    
    //Dimensions
    public const float  BOMB_Y_POSITION          = 0.5f;
    public const int    SCENERY_LIMIT            = 7;

    //Times
    public const float  EXPLOSION_TIME          = 1f;
    public const float  DESTROY_EXPLOSION_TIME  = 1.5f;
    public const float  MIN_STATE_TIME          = 5f;
    public const float  MAX_STATE_TIME          = 10f;
    public const float  BACK_TO_MENU_TIME       = 2f;

    //Tags,Layers and names
    public const string TAG_EXPLOSION           = "Explosion";
    public const string TAG_BRICK               = "Brick";
    public const string TAG_PLAYER              = "Player";
    public const string TAG_EXIT                = "Exit";
    public const string TAG_WALL                = "Wall";
    public const string TAG_ENEMY               = "Enemy";

    //Config player
    public const int    MIN_SPEED_PLAYER        = 6;
    public const int    MIN_RANGE_PLAYER        = 1;

    //points
    public const int KILL_BOX_POINTS            = 5;
    public const int KILL_ENEMY_POINTS          = 100;

    //folders and extensions
    public const string FOLDER_SCRIPTABLE_OBJECTS = "DDBB/ScriptableObj/";
    public const string FOLDER_JSON_FILES = "DDBB/JSON/";
    public const string FOLDER_RESOURCES = "/Resources/";
    public const string EXTENSION_JSON = ".json";
    //key words
    public const string KEY_LANGUAGE = "Language";
    //levelEditor

}

//Enums
public enum EnemyState      { IDLE, MOVE, CHASE };
public enum BoxGift         { SPEED = 0, RANGE = 1, BOMB = 2, EXIT = 3, NONE = 4 };
public enum Direction       { UP = 0 , DOWN = 1, LEFT = 2, RIGHT = 3};
public enum ControllerType  { Vertical, Horizontal};
public enum Language        { Spanish, English, Catalonian };
