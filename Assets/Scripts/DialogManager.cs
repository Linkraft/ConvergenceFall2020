using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    DialogTree dt;

    public class Dialog
    {
        public string id;
        public bool fromUser;
        public List<string> keyPhrases;
        public readonly string dialogText;
        public List<Dialog> children;
        public int numChildren;
        public AudioClip audioClip;
        public bool hasPlayed;

        public Dialog(string id, bool fromUser, string dialogText)
        {
            keyPhrases = new List<string>();
            children = new List<Dialog>();
            this.id = id;
            this.fromUser = fromUser;
            this.dialogText = dialogText;
            if (!fromUser)
            {
                audioClip = Resources.Load("AudioClips\\" + id) as AudioClip;
            }
        }

        public void AddChild( Dialog child)
        {
            children.Add(child);
            numChildren++;
        }

        public Dialog GetChild(int index)
        {
            if (children.Count != 0)
                return children[index];
            else
                return null;
        }
    }

    public class DialogTree
    {
        public Dialog currentDialog;

        public DialogTree(Dialog root)
        {
            this.currentDialog = root;
        }

        public void SetDialog(int childIndex)
        {
            if (childIndex < currentDialog.numChildren)
                currentDialog = currentDialog.children[childIndex];
        }

        public List<Dialog> NextDialogs()
        {
            return currentDialog.children;
        }

        public string[] NextDialogTexts()
        {
            string[] dialogTexts = new string[currentDialog.numChildren];
            for (int i = 0; i < currentDialog.numChildren; i++)
                dialogTexts[i] = currentDialog.children[i].dialogText;
            return dialogTexts;
        }
    }

    public void BuildDialogTree()
    {
        #region Build dialogs
        // First, build all the dialogs for all of the user's possible inputs and their static responses
        Dialog user1 = new Dialog("user1", true, "Good morning, Mr. Andrews."); // Root node
        user1.keyPhrases = new List<string>(){"good morning", "good", "morning"};
        dt = new DialogTree(user1);

        Dialog resp11 = new Dialog("resp1", false, "Is it? I have been coming here for 2 years and I still don't have proper teeth.");

        Dialog user21 = new Dialog("user2", true, "We will have time to discuss that, let's start with updating your medical history. I will now take your blood pressure.");
        user21.keyPhrases = new List<string>(){ "updating", "medical", "history", "blood", "pressure" };
        Dialog user22 = new Dialog("user3", true, "I'm sorry to hear that. May I know what the problem is?");
        user22.keyPhrases = new List<string>(){"sorry", "problem"};

        Dialog resp21 = new Dialog("resp2", false, "Why? I'm fine. I don't want you to take my blood pressure.");
        Dialog resp22 = new Dialog("resp3", false, "This is crazy! Fine, go ahead.");
        Dialog resp23 = new Dialog("resp4", false, "My student doctor is bad, I have tried to call my student doctor, but he never returned my call.");
        Dialog resp24 = new Dialog("resp5", false, "I have spent so much time and money, but my treatment never finishes.");

        Dialog user31 = new Dialog("user4", true, "As I said, this is to protect you.");
        user31.keyPhrases = new List<string>(){"protect"};
        Dialog user32 = new Dialog("user5", true, "I am sorry, but this is the clinic's protocol.");
        user32.keyPhrases = new List<string>() {"sorry", "clinic", "protocol"};
        Dialog user33 = new Dialog("user6", true, "Thank you. Do you have any medical problems that I should be aware of?");
        user33.keyPhrases = new List<string>() {"medical", "problem", "aware"};
        Dialog user34 = new Dialog("user7", true, "Thank you. How's your general health condition?");
        user34.keyPhrases = new List<string>() {"general", "health", "condition"};
        Dialog user35 = new Dialog("user8", true, "Oh I am sorry to hear that, he has graduated and I will be your next student doctor.");
        user35.keyPhrases = new List<string>() {"graduated", "doctor"};
        Dialog user36 = new Dialog("user9", true, "Oh I'm sorry. I will make sure that you will be taken care of right now.");
        user36.keyPhrases = new List<string>() {"sure", "care"};
        Dialog user37 = new Dialog("user10", true, "Oh I am sorry to hear that, let me look at your dental treatment history.");
        user37.keyPhrases = new List<string>() {"look", "dental", "treatment", "history"};
        Dialog user38 = new Dialog("user11", true, "Oh I apologize for that. Do you mind if I ask you some questions?");
        user38.keyPhrases = new List<string>() {"mind", "ask", "questions"};

        Dialog resp31 = new Dialog("resp6", false, "Ok, fine.");
        Dialog resp32 = new Dialog("resp7", false, "Really? Fine then.");
        Dialog resp33 = new Dialog("resp8", false, "No, I am fine.");
        Dialog resp34 = new Dialog("resp9", false, "Yes, I have high blood pressure.");
        Dialog resp35 = new Dialog("resp10", false, "I am fine. Thank you.");
        Dialog resp36 = new Dialog("resp11", false, "Well, I had colon cancer three years ago.");
        Dialog resp37 = new Dialog("resp12", false, "Okay, can I trust you?");
        Dialog resp38 = new Dialog("resp13", false, "Okay, thank you.");
        Dialog resp39 = new Dialog("resp14", false, "Okay, thank God.");
        Dialog resp310 = new Dialog("resp15", false, "Okay, I hope so too.");
        Dialog resp311 = new Dialog("resp16", false, "Can I talk to your instructor?");
        Dialog resp312 = new Dialog("resp17", false, "Okay, I hope you can find a solution for me.");
        Dialog resp313 = new Dialog("resp18", false, "Yes, please.");
        Dialog resp314 = new Dialog("resp19", false, "I thought I had explained everything to you already.");
        #endregion

        #region Link dialogs
        // Then, link them together appropriately in the list
        user1.AddChild( resp11);
        resp11.AddChild( user21);
        resp11.AddChild( user22);
        user21.AddChild( resp21);
        user21.AddChild( resp22);
        user22.AddChild( resp23);
        user22.AddChild( resp24);
        resp21.AddChild( user31);
        resp21.AddChild( user32);
        resp22.AddChild( user33);
        resp22.AddChild( user34);
        resp23.AddChild( user35);
        resp23.AddChild( user36);
        resp24.AddChild( user37);
        resp24.AddChild( user38);
        user31.AddChild( resp31);
        user32.AddChild( resp32);
        user33.AddChild( resp33);
        user33.AddChild( resp34);
        user34.AddChild( resp35);
        user34.AddChild( resp36);
        user35.AddChild( resp37);
        user35.AddChild( resp38);
        user36.AddChild( resp39);
        user36.AddChild( resp310);
        user37.AddChild( resp311);
        user37.AddChild( resp312);
        user38.AddChild( resp313);
        user38.AddChild( resp314);
        #endregion
    }

    public AudioClip CurrentClip()
    {
        dt.currentDialog.hasPlayed = true;
        return dt.currentDialog.audioClip;
    }

    public Dialog CurrentDialog()
    {
        return dt.currentDialog;
    }

    // Start is called before the first frame update
    void Start()
    {
        BuildDialogTree();
    }

    public void UpdateDialog(string userSpeech)
    {
        Dialog dialog = dt.currentDialog;
        // If the last person to speak wasn't the patient
        //if (!dialog.fromUser) return;
        // If the first dialog, update to first patient response
        if (dialog.id == "user1")
        {
            dt.currentDialog = dt.currentDialog.children[0];
            return;
        }

        // Figure out which option the user chose based on what they said
        // Look through the possible responses and switch the dialog to the one that the user probably chose
        foreach(Dialog c in dialog.children) {
            for (int i = 0; i < c.keyPhrases.Count; i++)
            {
                if (userSpeech.Contains(c.keyPhrases[i]))
                {
                    dt.currentDialog = ChooseRandomChild(c);
                    break;
                }
            }
        }
        Debug.Log("Current dialog: " + dt.currentDialog.id);
    }

    public List<string> GetNextDialogOptions()
    {
        List<string> options = new List<string>();
        if (dt.currentDialog.id == "user1")
        {
            options.Add(dt.currentDialog.dialogText);
        }
        if (!dt.currentDialog.fromUser)
        {
            foreach(Dialog c in dt.currentDialog.children)
            {
                Debug.Log(c.dialogText);
                options.Add(c.dialogText);
            }
        }
        return options;
    }

    public Dialog ChooseRandomChild(Dialog dialog)
    {
        int child = Random.Range(0, dialog.numChildren - 1);
        return dialog.children[child];
    }
}
