using UnityEngine;

public class ZombieSkinRandomizer : MonoBehaviour
{
    [Header("Zombie Parts")]
    public GameObject Hair;
    public GameObject Head;
    public GameObject Body;
    public GameObject ArmsR;
    public GameObject ArmsL;
    [Header("Zombie Sprites")]
    public Sprite[] ListOfHair;
    public Sprite[] ListOfHead;
    public Sprite[] ListOfBody;
    public Sprite[] ListOfArmsR;
    public Sprite[] ListOfArmsL;



    void Start()
    {
       RandomizedSkin(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizedSkin()
    {
        Hair.GetComponent<SpriteRenderer>().sprite = ListOfHair[Random.Range(0, ListOfHair.Length)];
        Head.GetComponent<SpriteRenderer>().sprite = ListOfHead[Random.Range(0, ListOfHead.Length)];
        Body.GetComponent<SpriteRenderer>().sprite = ListOfBody[Random.Range(0, ListOfBody.Length)];
        ArmsR.GetComponent<SpriteRenderer>().sprite = ListOfArmsR[Random.Range(0, ListOfArmsR.Length)];
        ArmsL.GetComponent<SpriteRenderer>().sprite = ListOfArmsL[Random.Range(0, ListOfArmsL.Length)];
    }
}
