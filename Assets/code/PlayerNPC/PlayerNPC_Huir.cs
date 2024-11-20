using UnityEngine;

public class PlayerNPC_Huir : StateMachineBehaviour
{
    private Transform npc;
    private Transform[] enemigos;
    private float distanciaSegura;
    private Rigidbody2D rb;
    private float velocidad = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject.transform;
        PlayerNPC playerNPC = npc.GetComponent<PlayerNPC>();
        enemigos = playerNPC.enemigos;
        distanciaSegura = playerNPC.distanciaSegura;
        rb = npc.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direccionHuida = Vector2.zero;

        foreach (var enemigo in enemigos)
        {
            float distancia = Vector2.Distance(npc.position, enemigo.position);
            if (distancia < distanciaSegura)
            {
                // Calcular dirección opuesta al enemigo
                direccionHuida += (Vector2)(npc.position - enemigo.position).normalized;
            }
        }

        if (direccionHuida != Vector2.zero)
        {
            rb.velocity = direccionHuida.normalized * velocidad;
        }
        else
        {
            // Seguro, vuelve a alerta.
            rb.velocity = Vector2.zero;
            animator.SetBool("distanciaSegura", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Detener al NPC al salir del estado.
        rb.velocity = Vector2.zero;
    }
}
