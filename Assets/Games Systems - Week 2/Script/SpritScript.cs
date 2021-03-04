using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritScript : MonoBehaviour
{ 
    public List<Sprite> sprites;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().wholeNumbers = true;
        GetComponent<Slider>().maxValue = sprites.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomSprite();
        }
    }

    // Changing different sprites
    public void RandomSprite()
    {
        int rand = Random.Range(0, sprites.Count);
        rend.sprite = sprites[rand];
        GetComponent<Slider>().value = rand;
    }

    public void ChangeSprite(float value)
    {
        int roundValue = Mathf.RoundToInt(value); //Lists won't work with array
        rend.sprite = sprites[roundValue];
    }
}
