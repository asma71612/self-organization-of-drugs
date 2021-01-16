#nullable enable
using System.Collections;
using System.Collections.Generic;

namespace Bme121
{
    partial class LinkedList< TData > : IEnumerable< TData >
    {
        // Convert the linked list to an array of its data elements.

        public TData[ ] ToArray( )
        {
            TData[ ] result = new TData[ Count ];

            int i = 0;
            Node? currentNode = Head;
            while( currentNode != null )
            {
                result[ i ] = currentNode.Data;

                i ++;
                currentNode = currentNode.Next;
            }

            return result;
        }

        // Implement the 'IEnumerable< TData >' interface.
        // This requires implementing the 'IEnumerable' interface.

        IEnumerator< TData > IEnumerable< TData >.GetEnumerator( )
        {
            Node? currentNode = Head;
            while( currentNode != null )
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return ( ( IEnumerable< TData > ) this).GetEnumerator( );
        }
    }
}
