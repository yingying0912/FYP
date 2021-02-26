using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeHand : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftAttachment;
    public GameObject RightAttachment;

    //public GameObject Attachment;

    public GameObject FakeLeftHand;
    public GameObject FakeRightHand;
    public GameObject FakeLeftAttachment;
    public GameObject FakeRightAttachment;

    Transform LeftHandInfo;
    Transform RightHandInfo;
    Transform LeftAttachmentInfo;
    Transform RightAttachmentInfo;

    bool LeftHandStatus;
    bool RightHandStatus;

    // Update is called once per frame
    void Update()
    {
        LeftHandInfo = LeftHand.transform;
        RightHandInfo = RightHand.transform;
        LeftAttachmentInfo = LeftAttachment.transform;
        RightAttachmentInfo = RightAttachment.transform;

        //LeftHandStatus = LeftHand.active;
        //RightHandStatus = RightHand.active;

        if (!LeftHand.active)
        {
            FakeLeftHand.transform.position = LeftHandInfo.position;
            FakeLeftHand.transform.rotation = LeftHandInfo.rotation;
            FakeLeftAttachment.transform.position = LeftAttachmentInfo.position;
            FakeLeftAttachment.transform.rotation = LeftAttachmentInfo.rotation;
            
            FakeLeftHand.SetActive(true);
            FakeLeftAttachment.SetActive(true);
        }
        
        if (!RightHand.active)
        {
            FakeRightHand.transform.position = RightHandInfo.position;
            FakeRightHand.transform.rotation = RightHandInfo.rotation;
            FakeRightAttachment.transform.position = RightAttachmentInfo.position;
            FakeRightAttachment.transform.rotation = RightAttachmentInfo.rotation;
            
            FakeRightHand.SetActive(true);
            FakeRightAttachment.SetActive(true);
        }
    }
}
