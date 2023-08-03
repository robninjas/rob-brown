using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    List<GameObject> tempObstacles;
    public List<GameObject> Obstacles;
    public List<GameObject> ObstaclesShuffled;

    List<Color> tempColors;
    public List<Color> Colors;
    public List<Color> ColorsShuffled;

    List<string> tempColorTags;
    public List<string> ColorTags;
    public List<string> ColorTagsShuffled;

    public Transform generationPoint;
    public float distBetween;
    private float obstacleLength = 3.5f;
    private float obstacleWidth = 1;

    SpriteRenderer sr;

    Color randomColor;
    string randomTag;
    GameObject randomObstacle;
    int randomColorIndex;
    int randomObstacleIndex;

    Vector3 instanPos;

    void Start()
    {

    }

    void Update()
    {
        if( transform.position.x < generationPoint.position.x)
        {
            //move obstacleGenPoint
            transform.position = new Vector3(transform.position.x + obstacleWidth + distBetween, transform.position.y, transform.position.z);
            
            //create copy of list, then empty the shuffled list
            tempObstacles = Obstacles.GetRange(0, Obstacles.Count);  
            ObstaclesShuffled = new List<GameObject>();

            tempColors = Colors.GetRange(0, Colors.Count);
            ColorsShuffled = new List<Color>();

            tempColorTags = ColorTags.GetRange(0, ColorTags.Count);  
            ColorTagsShuffled = new List<string>();

            //shuffle obstacle and colors with their tags
            while(tempColors.Count > 0 && tempColorTags.Count > 0 && tempObstacles.Count > 0){
                //get random number from 0 to length of list
                randomColorIndex = Random.Range(0, tempColors.Count);
                randomObstacleIndex = Random.Range(0, tempObstacles.Count);

                //assign number to color/tag/obstacle
                randomColor = tempColors[randomColorIndex];
                randomTag = tempColorTags[randomColorIndex]; 
                randomObstacle = tempObstacles[randomObstacleIndex]; 

                //add that random number to the new list for shuffle
                ColorsShuffled.Add(randomColor);
                ColorTagsShuffled.Add(randomTag);
                ObstaclesShuffled.Add(randomObstacle);

                //remove it from old list so can't pick it again/no color repeats in row
                tempColors.Remove(randomColor);
                tempColorTags.Remove(randomTag);
                tempObstacles.Remove(randomObstacle);
            }
    
            for(int i = 0; i < 3; i++)
            {
                sr = ObstaclesShuffled[i].GetComponent<SpriteRenderer>(); //get that obstacle's Sprite Renderer
                sr.color = ColorsShuffled[i]; //assign the color from your randomly shuffled color list
                ObstaclesShuffled[i].gameObject.tag = ColorTagsShuffled[i]; //assigns corresponding tag

                //make 3 obstacles in a vertical line
                instanPos = new Vector3 (transform.position.x, transform.position.y + ((i - 1) * obstacleLength), transform.position.z);
                Instantiate(ObstaclesShuffled[i], instanPos, transform.rotation); 
            }
        }
    }
}
