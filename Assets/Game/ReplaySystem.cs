﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {
    
    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;

    private GameManager gameManager;

    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update () {
        if (gameManager.recording) {
            Record();
        }
        else {
            PlayBack();
        }
        
    }

    void Record() {
        rigidBody.isKinematic = false;

        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("Writing Frame: " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    void PlayBack () {
        rigidBody.isKinematic = true;

        int frame = Time.frameCount % bufferFrames;
        print("Reading Frame: " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    /// <summary>
    /// A structure for storing time, rotation and position.
    /// </summary>
    public struct MyKeyFrame {
        public float frameTime;
        public Vector3 position;
        public Quaternion rotation;

        public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
            frameTime = aTime;
            position = aPosition;
            rotation = aRotation;
        }
    }
}
