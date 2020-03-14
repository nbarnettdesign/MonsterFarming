using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;
    public float attackRange;
    public float baseAttackRange = 0f;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    if(interactable.tag == "Enemy")
                    {
                        Debug.Log("i mean i guess you hit");
                        //RangeAttack(interactable);
                    }else SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);

    }

    /*public void RangeAttack(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.AttackTarget(newFocus, attackRange,baseAttackRange);
        }

        newFocus.OnFocused(transform);

    }*/

    /*public void SkillUsed()
    {
        motor.SkillUsed();
        RemoveFocus();
    }*/

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}
