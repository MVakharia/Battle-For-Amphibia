using UnityEngine;

public class Character_Rendering : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spRenderer_Sasha, spRenderer_Anne, spRenderer_Marcy, 
        spRenderer_Aura_Sasha, spRenderer_Aura_Anne, spRenderer_Aura_Marcy;

    private Color32 HairColour_Sasha => new(222, 194, 108, 255);
    private Color32 HairColour_Anne => new(92, 48, 42, 255);
    private Color32 HairColour_Marcy => new(36, 34, 46, 255);

    private Color32 DefaultColor_SpRenderer_Sasha => new(255, 0, 255, 255);
    private Color32 DefaultColor_SpRenderer_Anne => new(0, 255, 255, 255);
    private Color32 DefaultColor_SpRenderer_Marcy => new(0, 255, 0, 255);

    private Color32 DefaultColor_SpRenderer_Aura_Sasha => new(255, 0, 114, 50);
    private Color32 DefaultColor_SpRenderer_Aura_Anne => new(0, 177, 255, 50);
    private Color32 DefaultColor_SpRenderer_Aura_Marcy => new(192, 255, 0, 50);

    public void SetPropertiesOnDeath ()
    {
        spRenderer_Sasha.color = HairColour_Sasha;

        spRenderer_Aura_Sasha.gameObject.SetActive(false);

        spRenderer_Anne.color = HairColour_Anne;

        spRenderer_Aura_Anne.gameObject.SetActive(false);

        spRenderer_Marcy.color = HairColour_Marcy;

        spRenderer_Aura_Marcy.gameObject.SetActive(false);
    }

    public void SetPropertiesOnRoundStart ()
    {
        spRenderer_Sasha.color = DefaultColor_SpRenderer_Sasha;

        spRenderer_Aura_Sasha.color = DefaultColor_SpRenderer_Aura_Sasha;

        spRenderer_Anne.color = DefaultColor_SpRenderer_Anne;

        spRenderer_Aura_Anne.color = DefaultColor_SpRenderer_Aura_Anne;

        spRenderer_Marcy.color = DefaultColor_SpRenderer_Marcy;

        spRenderer_Aura_Marcy.color = DefaultColor_SpRenderer_Aura_Marcy;
    }
}