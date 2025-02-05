using UnityEngine;
using UnityEngine.UI;

public class LifeSpriteChanger : MonoBehaviour
{
    [SerializeField] private int jogador;
    [SerializeField] private Image spritePanel;
    [SerializeField] private Sprite fullLifeSprite;
    [SerializeField] private Sprite halfLifeSprite;
    [SerializeField] private Sprite emptyLifeSprite;

    [SerializeField] private GameController gameController;

    private int userLife;

    void Update()
    {
        if(jogador == 1)
        {
            userLife = gameController.getLifePlayer();
        }
        else
        {
            userLife = gameController.getLifeAdversario();
        }
        UpdateSpriteBasedOnLife();
    }

    void UpdateSpriteBasedOnLife()
    {
        if (userLife > 6)
        {
            spritePanel.sprite = fullLifeSprite;
        }
        else if (userLife > 2)
        {
            spritePanel.sprite = halfLifeSprite;
        }
        else
        {
            spritePanel.sprite = emptyLifeSprite;
        }
    }
}