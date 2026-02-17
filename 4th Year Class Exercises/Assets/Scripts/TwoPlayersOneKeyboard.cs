using UnityEngine;
using UnityEngine.InputSystem;

public class TwoPlayersOneKeyboard : MonoBehaviour
{
    [Header("Actions (drag from your Input Actions asset")] // Adds a label in the inspector for organisation
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;

    [Header("Players")]
    [SerializeField] private Transform p1;       //Transform for Player One
    [SerializeField] private Transform p2;       //Transform for Player Two

    [SerializeField] private float speed = 5f;

    private void OnEnable()        //Called when the component becomes enabled/active
    {
        p1Move.action.Enable();          //Enables player One's input action so it can read input
        p2Move.action.Enable();          //Enables player Two's input action so it can read input
    }

    private void OnDisable()        //Called when the component becomes disabled/inactive
    {
        p1Move.action.Disable();        //Disables player One's action (stops reading input)
        p2Move.action.Disable();        //Disables player Two's action (stops reading input)
    }

    private void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();
        var m2 = p2Move.action.ReadValue<Vector2>();

        if (p1) p1.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;       //Only move player 1 if the transform reference exists;
        if (p2) p2.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;       //Only move player 2 if the transform reference exists;
    }

}
