using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject enemyPrefab;

    public BattleState state;

    public Transform EnemyBattleStation;
    Enemy_unit enemyUnit;
    
    public Enemy_Hud enemyHUD;
    public TMP_Text DialogueText;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        GameObject enemyGO = Instantiate(enemyPrefab, EnemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Enemy_unit>();

        enemyHUD.SetHUD(enemyUnit);
        DialogueText.text = "oh shit its a " + enemyUnit.unitName + " better kill it before it eats your cheese";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    public void PlayerTurn()
    {
        DialogueText.text = "ey mate its your turn do something";
    }

    public void OnAttack()
    {
        Destroy(gameObject);
    }
    
}
