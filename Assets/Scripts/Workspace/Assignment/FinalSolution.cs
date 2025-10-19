using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class FinalSolution : IAssignment
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public void LCT01_StackSyntax()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Debug.Log($"Count: {stack.Count}");

            var popped = stack.Pop();
            Debug.Log($"Popped: {popped}");

            var top = stack.Peek();
            Debug.Log($"Peek: {top}");
            Debug.Log($"Count after peek: {stack.Count}");

            stack.Clear();
        }

        public void LCT02_QueueSyntax()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Debug.Log($"Count: {queue.Count}");

            var dequeued = queue.Dequeue();
            Debug.Log($"Dequeue: {dequeued}");

            var front = queue.Peek();
            Debug.Log($"Peek: {front}");

            Debug.Log($"Count after dequeue: {queue.Count}");

            queue.Clear();
        }

        public void LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };

            Stack<Action> actionStack = new Stack<Action>();
            actionStack.Push(action1);
            actionStack.Push(action2);
            actionStack.Push(action3);

            while (actionStack.Count > 0)
            {
                var action = actionStack.Pop();
                Debug.Log($"Executing {action.Name}");
            }
        }

        public void LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };

            Queue<Action> actionQueue = new Queue<Action>();
            actionQueue.Enqueue(action1);
            actionQueue.Enqueue(action2);
            actionQueue.Enqueue(action3);

            while (actionQueue.Count > 0)
            {
                var action = actionQueue.Dequeue();
                Debug.Log($"Executing {action.Name}");
            }
        }

        #endregion

        #region Assignment

        public void ASN01_ReverseString(string str)
        {
            Stack<string> stack = new Stack<string>();
            foreach (var c in str)
            {
                stack.Push(c.ToString());
            }
            string reversed = "";
            while (stack.Count > 0)
            {
                reversed += stack.Pop();
            }
            Debug.Log(reversed);
        }

        public void ASN02_StackPalindrome(string str)
        {
            Stack<string> stack = new Stack<string>();
            foreach (var c in str)
            {
                stack.Push(c.ToString());
            }
            string reversed = "";
            while (stack.Count > 0)
            {
                reversed += stack.Pop();
            }
            bool isPalindrome = str == reversed;
            if (isPalindrome)
                Debug.Log("is a palindrome");
            else
                Debug.Log("is not a palindrome");
        }

        #endregion

        #region Extra

        public void EX01_ParenthesesChecker(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }
                    char top = stack.Pop();
                    if (!Matches(top, c))
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }
                }
            }
            if (stack.Count == 0)
                Debug.Log("Balanced");
            else
                Debug.Log("Unbalanced");
        }

        private bool Matches(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '[' && close == ']') ||
                   (open == '{' && close == '}');
        }

        #endregion
    }
}
