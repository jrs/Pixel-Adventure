using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public float Speed;
    public float WaitTime;

    private int _currentPointIndex;
    private float _startWaitTime;

    private Animator _myAnim;


    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        transform.position = PatrolPoints[0].position;
        transform.rotation = PatrolPoints[0].rotation;
        _startWaitTime = WaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[_currentPointIndex].position, Speed * Time.deltaTime);

        if (transform.position == PatrolPoints[_currentPointIndex].position)
        {
            _myAnim.SetBool("IsMoving", false);

            if (_startWaitTime <= 0)
            {
                if (_currentPointIndex + 1 < PatrolPoints.Length)
                {
                    _currentPointIndex++;
                }
                else
                {
                    _currentPointIndex = 0;
                }
                _startWaitTime = WaitTime;
            }
            else
            {
                _startWaitTime -= Time.deltaTime;
            }
        }
        else
        {
            transform.rotation = PatrolPoints[_currentPointIndex].rotation;
            _myAnim.SetBool("IsMoving", true);
        }
    }
}
