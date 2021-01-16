#nullable enable
using System;

namespace Bme121
{
    partial class LinkedList< TData >
    {
        // Determine whether the linked list contains a target TData object.

        public bool Contains( Predicate< TData > IsTarget )
        {
            Node? currentNode = Head;
            while( currentNode != null )
            {
                if( IsTarget( currentNode.Data ) ) return true;

                currentNode = currentNode.Next;
            }

            return false;
        }

        // Remove from the linked list the first instance of a target TData object.

        public TData Remove( Predicate< TData > IsTarget )
        {
            Remove( out TData removedData, IsTarget );
            return removedData;
        }

        public bool Remove( out TData removedData, Predicate< TData > IsTarget )
        {
            Node? previousNode = null;
            Node? currentNode = Head;
            while( currentNode != null )
            {
                if( IsTarget( currentNode.Data ) )
                {
                    Node? nextNode = currentNode.Next;

                    if( currentNode == Head ) Head = nextNode;
                    else previousNode!.Next = nextNode;
                    if( currentNode == Tail ) Tail = previousNode;
                    currentNode.Next = null;

                    Count --;

                    removedData = currentNode.Data;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            removedData = default( TData )!;
            return false;
        }
    }
}
