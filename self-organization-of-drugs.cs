#nullable enable
using System;
using static System.Console;
using MediCal;

namespace Bme121
{
    public enum SelfOrgMove { None, Back, Head }

    partial class LinkedList< TData >
    {
        // Determine whether the linked list contains a target TData object.
        // The search is self-organizing so the found element is moved towards the list head.
        // The parameter-variable 'move' controls the self-organization.
        // SelfOrgMove.None - the list is not changed.
        // SelfOrgMove.Back - the target node is swapped with the node before it
        // SelfOrgMove.Head - the target node is swapped with the node at the list head

        public bool Contains( Predicate< TData > IsTarget, SelfOrgMove move )
        {
            Node? currentNode = Head;
            Node? previousNode = null;
            Node? backTwo = null;
            
            while ( currentNode != null ) // while valid 
            {
                if ( IsTarget ( currentNode.Data ) ) // when the target is found and it is the current node
                {
                    if ( move == SelfOrgMove.Back ) // when user enters back
                    {
                        // previous node is null so it returns the list unchanged
                        if ( currentNode == Head ) return true;
                        
                        // back2 node is null so your new head is currentNode
                        // back2.next doesnt work 
                        else if ( previousNode == Head )
                        {
                            previousNode!.Next = currentNode!.Next;
                            //backTwo!.Next = currentNode;
                            Head = currentNode;
                            currentNode!.Next = previousNode;
                        }
                        
                        // swapping the current node and previous node in the middle of the list 
                        else 
                        {
                            previousNode!.Next = currentNode!.Next; 
                            backTwo!.Next = currentNode; // this was the old previous node
                            currentNode!.Next = previousNode; 
                        }
                    }
                    
                    // moves the target to the front of the list 
                    else if ( move == SelfOrgMove.Head ) // when user enters head 
                    {
                        // nothing to move - current node is already head
                        if ( currentNode == Head ) return true;
                        
                        // moves it from the middle or end of the list to the beginning 
                        // current node is now your head
                        previousNode!.Next = currentNode!.Next;
                        currentNode!.Next = Head;
                        Head = currentNode;
                    }
                    return true;
                }
                // advances through the list 
                backTwo = previousNode;
                previousNode = currentNode;
                currentNode = currentNode!.Next;
            }
            return false;
        }
    }
}
