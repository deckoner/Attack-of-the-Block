using UnityEngine;

public class Alerta_PlayerNPC : StateMachineBehaviour
{
    private Transform npc;
    private Transform[] enemigos;
    private float distanciaDeteccion;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject.transform;
        PlayerNPC playerNPC = npc.GetComponent<PlayerNPC>();
        enemigos = playerNPC.enemigos;
        distanciaDeteccion = playerNPC.distanciaDeteccion;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Recalcular distancias y actualizar parámetros
        bool enemigoCerca = false;

        foreach (var enemigo in enemigos)
        {
            if (Vector2.Distance(npc.position, enemigo.position) < distanciaDeteccion)
            {
                enemigoCerca = true;
                break;
            }
        }

        animator.SetBool("enemigoCerca", enemigoCerca);
    }
}
