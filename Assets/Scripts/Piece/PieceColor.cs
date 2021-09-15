using UnityEngine;

public class PieceColor : MonoBehaviour
{
    [SerializeField]
    private Sprite blueColor;
    [SerializeField]
    private Sprite redColor;
    [SerializeField]
    private Sprite greenColor;
    [SerializeField]
    private Sprite purpleColor;
    [SerializeField]
    private Sprite goldColor;
    [SerializeField]
    private Sprite greyColor;
    [SerializeField]
    private Sprite brownColor;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    
    private void Awake()
    {
        ChooseColor();
    }

    private void ChooseColor()
    {
        //TODO
        // set spriteRenderer.sprite to a random sprite that is present above

        //uses a switch statement to determine which sprite the piece will use.
        //there are seven outcomes so there are seven different cases.
        //default is blue just to make sure that no problems can possibly occur.
        var randNum = Random.Range(0, 6);
        switch (randNum) { 
            
            case 1:
                spriteRenderer.sprite = redColor;
                break;
            case 2:
                spriteRenderer.sprite = greenColor;
                break;
            case 3:
                spriteRenderer.sprite = purpleColor;
                break;
            case 4:
                spriteRenderer.sprite = goldColor;
                break;
            case 5:
                spriteRenderer.sprite = greyColor;
                break;
            case 6:
                spriteRenderer.sprite = brownColor;
                break;
            default:
                spriteRenderer.sprite = blueColor;
                break;
        }
    }
}
