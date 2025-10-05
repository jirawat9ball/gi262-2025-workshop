using Solution;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class NPC : Identity
{
    public DialogueUI dialogueUI;
    public DialogueManager dialogueManager;
    public bool canTalk = true;

    public override bool Hit()
    {
        // ��Ǩ�ͺ��Ҽ����������������ͧ����������
        if (canTalk)
        {
            dialogueUI.Setup(dialogueManager);
            DialogueNode currentNode = dialogueManager.tree.root;
            dialogueUI.ShowDialogue(currentNode);
            return false;
        }
        else
        {
            Debug.Log("I not neet to talk to you");
            return false;
        }
    }
}
