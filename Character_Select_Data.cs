using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Select_Data : MonoBehaviour
{
    [SerializeField]
    private SelectedHero selected_Hero;

    public SelectedHero Selected_Hero => selected_Hero;

    public void SelectSasha() => selected_Hero = SelectedHero.Sasha;

    public void SelectAnne() => selected_Hero = SelectedHero.Anne;

    public void SelectMarcy() => selected_Hero = SelectedHero.Marcy;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
