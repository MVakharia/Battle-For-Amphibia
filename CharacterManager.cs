using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Character_Select_Data data;

    [SerializeField] private SelectedHero defaultHero;

    private SelectedHero selectedHero;

    private Vector3 OffScreenSpawnLocation => new Vector3(-20, 0);
    private Vector3 StartingLocation => new Vector3(-2.79F, -3, 5);

    [SerializeField] private GameObject prefab_Sasha;

    [SerializeField] private GameObject prefab_Anne;

    [SerializeField] private GameObject prefab_Marcy;

    private void Awake()
    {
        GameObject _ = GameObject.FindGameObjectWithTag("Character Select Data")/*.GetComponent<Character_Select_Data>()*/;

        if (_ != null)
        {
            data = _.GetComponent<Character_Select_Data>();

            selectedHero = data.Selected_Hero;
        }
        else
        {
            Debug.LogWarning("No character select data found. Selecting default hero.");

            if (defaultHero == SelectedHero.None)
            {
                int id = Random.Range(0, 3);

                switch (id)
                {
                    case 0: selectedHero = SelectedHero.Sasha; Debug.LogWarning("Default hero not selected. Sasha selected at random."); break;
                    case 1: selectedHero = SelectedHero.Anne; Debug.LogWarning("Default hero not selected. Anne selected at random."); break;
                    case 2: selectedHero = SelectedHero.Marcy; Debug.LogWarning("Default hero not selected. Marcy selected at random."); break;
                }
            }
            else
            {
                selectedHero = defaultHero;
            }
        }

        switch (selectedHero)
        {
            case SelectedHero.Sasha:
                {
                    //Instantiate Sasha off-screen. 



                    //Play the following animation routine:                    
                    //An animation-only trio flies in from below, in the order Marcy - Sasha - Anne.
                    //Marcy flies off to the left, and Anne flies off to the right, leaving Sasha on her own.
                    //At the end of the routine, disable the animated trio and replace the animated Sasha with the playable Sasha. 
                    //Start the round. 
                    break;
                }
            case SelectedHero.Anne:
                {
                    //Instantiate Anne off-screen. 

                    Instantiate(prefab_Anne, StartingLocation, Quaternion.identity);

                    //Play the following animation routine:                    
                    //An animation-only trio flies in from below, in the order Sasha - Anne - Marcy.
                    //Sasha flies off to the left, and Marcy flies off to the right, leaving Anne on her own.
                    //At the end of the routine, disable the animated trio and replace the animated Anne with the playable Anne. 
                    //Start the round. 

                    break;
                }
            case SelectedHero.Marcy:
                {
                    //Instantiate Marcy off-screen. 

                    //Play the following animation routine:                    
                    //An animation-only trio flies in from below, in the order Anne - Marcy - Sasha.
                    //Sasha flies off to the left, and Marcy flies off to the right, leaving Anne on her own.
                    //At the end of the routine, disable the animated trio and replace the animated Anne with the playable Anne. 
                    //Start the round. 

                    break;
                }
        }
    }
}