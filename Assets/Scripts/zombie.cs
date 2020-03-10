using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    //public Animator anim;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        RagDoll(true);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if ((transform.position - player.transform.position).sqrMagnitude < dist * dist)
        {
            OnRun();
        }
    }

    void OnRun()
    {
        transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;
        transform.position += Time.deltaTime * transform.forward * 5;
    }

    void RagDoll(bool val)
    {
        var bodyParts = GetComponentsInChildren<Rigidbody>();

        foreach(var part in bodyParts)
        {
            part.isKinematic = val;
        }
    }

    void Die(RaycastHit info)
    {
        GetComponent<Animator>().enabled = false;
        RagDoll(false);

        Vector3 hit = info.point;

        var colliders = Physics.OverlapSphere(hit, 0.5f);

        foreach(var collider in colliders)
        {
            var body = collider.GetComponent<Rigidbody>();
            if(body)
            {
                body.AddExplosionForce(1000, hit, 0.5f);
            }
        }
        this.enabled = false;
    }
}
