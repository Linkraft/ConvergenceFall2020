using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpeechDialog : MonoBehaviour
{
    public class Dialog
    {
        public bool fromUser;
        public readonly string dialogText;
        public readonly List<Dialog> children;

        public Dialog(bool fromUser, string dialogText)
        {
            this.fromUser = fromUser;
            this.dialogText = dialogText;
        }

        public void AddChild(ref Dialog child)
        {
            children.Add(child);
        }

        public Dialog GetChild(int index)
        {
            if (children.Count != 0)
                return children[index];
            else
                return null;
        }
    }

    public void BuildDialogTree()
    {
        #region Build dialogs
        // First, build all the dialogs for all of the user's possible inputs and their static responses
        Dialog user1 = new Dialog(true, "Good morning, Mr. Andrews."); // Root node
        Dialog resp11 = new Dialog(false, "Is it? I have been coming here for 2 years and I still don't have proper teeth.");
        Dialog user21 = new Dialog(true, "We will have time to discuss that, let's start with updating your medical history.");
        Dialog user22 = new Dialog(true, "I'm sorry to hear that. May I know what the problem is?");
        Dialog resp21 = new Dialog(false, "Why? I'm fine. I don't want you to take my blood pressure.");
        Dialog resp22 = new Dialog(false, "This is crazy! Fine, go ahead.");
        Dialog resp23 = new Dialog(false, "My student doctor is bad, I have tried to call my student doctor, but he never returned my call.");
        Dialog resp24 = new Dialog(false, "I have spent so much time and money, but my treatment never finishes.");
        Dialog user31 = new Dialog(true, "As I said, this is to protect you.");
        Dialog user32 = new Dialog(true, "I am sorry, but this is the clinic's protocol.");
        Dialog user33 = new Dialog(true, "Thank you. Do you have any medical problems that I should be aware of?");
        Dialog user34 = new Dialog(true, "Thank you. How's your general health condition?");
        Dialog user35 = new Dialog(true, "Oh I am sorry to hear that, he has graduated and I will be your next student doctor.");
        Dialog user36 = new Dialog(true, "Oh I'm sorry. I will make sure that you will be taken care of right now.");
        Dialog user37 = new Dialog(true, "Oh I am sorry to hear that, let me look at your dental treatment history.");
        Dialog user38 = new Dialog(true, "Oh I apologize for that. Do you mind if I ask you some questions?");
        Dialog resp31 = new Dialog(false, "Ok, fine.");
        Dialog resp32 = new Dialog(false, "Really? Fine then.");
        Dialog resp33 = new Dialog(false, "No, I am fine.");
        Dialog resp34 = new Dialog(false, "Yes, I have high blood pressure.");
        Dialog resp35 = new Dialog(false, "I am fine. Thank you.");
        Dialog resp36 = new Dialog(false, "Well, I had colon cancer three years ago.");
        Dialog resp37 = new Dialog(false, "Okay, can I trust you?");
        Dialog resp38 = new Dialog(false, "Okay, thank you.");
        Dialog resp39 = new Dialog(false, "Okay, thank God.");
        Dialog resp310 = new Dialog(false, "Okay, I hope so too.");
        Dialog resp311 = new Dialog(false, "Can I talk to your instructor?");
        Dialog resp312 = new Dialog(false, "Okay, I hope you can find a solution for me.");
        Dialog resp313 = new Dialog(false, "Yes, please.");
        Dialog resp314 = new Dialog(false, "I thought I had explained everything to you already.");
        #endregion

        #region Link dialogs
        // Then, link them together appropriately in the list
        user1.AddChild(ref resp11);
        resp11.AddChild(ref user21);
        resp11.AddChild(ref user22);
        user21.AddChild(ref resp21);
        user21.AddChild(ref resp22);
        user22.AddChild(ref resp23);
        user22.AddChild(ref resp24);
        resp21.AddChild(ref user31);
        resp21.AddChild(ref user32);
        resp22.AddChild(ref user33);
        resp22.AddChild(ref user34);
        resp23.AddChild(ref user35);
        resp23.AddChild(ref user36);
        resp24.AddChild(ref user37);
        resp24.AddChild(ref user38);
        user31.AddChild(ref resp31);
        user32.AddChild(ref resp32);
        user33.AddChild(ref resp33);
        user33.AddChild(ref resp34);
        user34.AddChild(ref resp35);
        user34.AddChild(ref resp36);
        user35.AddChild(ref resp37);
        user35.AddChild(ref resp38);
        user36.AddChild(ref resp39);
        user36.AddChild(ref resp310);
        user37.AddChild(ref resp311);
        user37.AddChild(ref resp312);
        user38.AddChild(ref resp313);
        user38.AddChild(ref resp314);
        #endregion
    }
}
