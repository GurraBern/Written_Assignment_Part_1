using UnityEngine;
using UnityEngine.AI;


public class DestroyTimer : MonoBehaviour
{
    public Rigidbody rb;
    public NavMeshAgent nav;

    public float timeleft;
    private float timeleft2;
    public ParticleSystem psDirt;
    public float growthRate = 3;
    private void Start()
    {
        psDirt.Play();
        timeleft2 = 1.5f;
        Destroy(rb);
        Destroy(nav);
        Destroy(GetComponent<ZombieMovement>());
        Destroy(GetComponent<Collider>());

    }
    void Update()
    {
        timeleft2 -= Time.deltaTime;
        if(timeleft2 <= 0)
        {
            if (transform.localScale.x > 0)
                transform.localScale += new Vector3(0.1F, .1f, .1f) * growthRate * Time.deltaTime;

            timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}