using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Solution
{
    public class ActionHistoryManager : MonoBehaviour
    {
        // 1. Undo System using Stack
        private Stack<Vector2> undoStack = new Stack<Vector2>();
        private Stack<Vector2> redoStack = new Stack<Vector2>();

        // 2. Auto-Move System using Queue
        private Queue<Vector2> autoMoveQueue = new Queue<Vector2>();

        #region "This Is undoStack Function"

        /// Saves the current player state (position) to the undo stack.
        public void SaveStateForUndo(Vector2 currentPosition)
        {
            // Only push a state if it's different from the last saved state 
            // (optional optimization, but good practice for movement)
            if (undoStack.Count == 0 || !undoStack.Peek().Equals(currentPosition))
            {
                undoStack.Push(currentPosition);
                
                if (redoStack.Count > 0)
                {
                    redoStack.Clear();
                    Debug.Log("New move detected. Redo stack cleared.");
                }
                
                Debug.Log($"State saved: Position {currentPosition}. Stack size: {undoStack.Count}");
            }
        }
        /// Reverts the player's state to the previous one using the undo stack.
        /// </summary>
        public void UndoLastMove(OOPPlayer player)
        {
            // Need at least two states: the current one, and the one to revert to.
            if (undoStack.Count > 1)
            {
                // Pop the current state
                Vector2 currentState = undoStack.Pop();
                redoStack.Push(currentState);

                // Peek at the previous state
                Vector2 previousState = undoStack.Peek();

                // Revert the player's position
                transform.position = previousState;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;

                player.UpdatePosition(toX, toY);
                Debug.Log($"Undo successful! Reverted to position: {previousState}. Stack size: {undoStack.Count}");
            }
            else
            {
                Debug.Log("Cannot undo: No previous states saved.");
            }
        }
        public void RedoLastMove(OOPPlayer player)
        {
            if (redoStack.Count > 0)
            {
                // 1. �֧ʶҹз��¡��ԡ�����ش�ҡ Redo Stack
                Vector2 stateToRedo = redoStack.Pop();

                // 2. ��ѡʶҹй����� Undo Stack ��Ѻ�
                undoStack.Push(stateToRedo);

                // 3. �ѻവ���˹觼�����
                transform.position = stateToRedo;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;

                player.UpdatePosition(toX, toY);
                Debug.Log($"Redo successful! Reverted to position: {stateToRedo}. Undo size: {undoStack.Count}, Redo size: {redoStack.Count}");
            }
            else
            {
                Debug.Log("Cannot redo: No undone states available.");
            }
        }
        #endregion

        #region "This Is autoMoveQueue Function"

        public void StartAutoMoveSequence(OOPPlayer player)
        {
            List<Vector2> sequence = new List<Vector2>
            {
                Vector2.right,
                Vector2.right,
                Vector2.up,
                Vector2.left,
                Vector2.up,
                Vector2.down
            };
            StartCoroutine(ProcessAutoMoveSequence(sequence, player));
        }
        public IEnumerator ProcessAutoMoveSequence(List<Vector2> moves, OOPPlayer player)
        {
            player.isAutoMoving = true;

            // 1. ����� Queue: ��ҧ Queue �����������ӴѺ�������͹�������
            autoMoveQueue.Clear();
            foreach (var move in moves)
            {
                autoMoveQueue.Enqueue(move);
            }

            Debug.Log($"Auto-move sequence started with {autoMoveQueue.Count} steps.");

            // 2. �����ż� Queue ���Т�鹵͹
            while (autoMoveQueue.Count > 0)
            {
                // �֧��ȷҧ�Ѵ仨ҡ Queue (Dequeue)
                Vector2 nextDirection = autoMoveQueue.Dequeue();

                // �ӡ������͹��� (�������� TryMove() ���� Move() ������ʹ�����)
                player.Move(nextDirection);

                // �� (Yield) ������ moveDelay �Թҷ� ��͹���Թ��â�鹵͹�Ѵ�
                // �������繡������͹�����Т�鹵͹
                yield return new WaitForSeconds(0.5f);
            }
            player.isAutoMoving = false;
            Debug.Log("Auto-move sequence finished.");
        }

        #endregion

    }
}

