using John_Project;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Card cardData;
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

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public IEnumerator PlayerAttack()
    {
        Debug.Log(cardData.damageMax);
        bool IsDead = enemyUnit.TakeDamage(9);
        enemyHUD.SetHp(enemyUnit.unitCurrenthp);


        yield return new WaitForSeconds(2f);

        if (IsDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn() 
    {
        DialogueText.text = enemyUnit.unitName + "has attacked you";
        yield return new WaitForSeconds(1f);
        
        bool IsDead = enemyUnit.PlayerTakeDamage(enemyUnit.unitDamage);

        if (IsDead == true)
        {
            state = BattleState.LOST;
            SceneManager.LoadScene("DeathScene");
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            DialogueText.text = "you've won good job!";
        }
        else if (state == BattleState.LOST)
        {
            DialogueText.text = "you starved to death on you skill issue";
        }
    } 
    public void PlayerTurn()
    {
        DialogueText.text = "ey mate its your turn do something";
    }

    public void OnAttack()
    {

        /*if (state != BattleState.PLAYERTURN)
        {
            Debug.Log("before");
            return;
            Debug.Log("after");

        }*/
        Debug.Log("outside");
        Debug.Log(cardData);
        StartCoroutine(PlayerAttack());
        Destroy(gameObject);
    }
    
}
