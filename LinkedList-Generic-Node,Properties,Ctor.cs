#nullable enable

namespace Bme121
{
    partial class LinkedList< TData >
    {
        // Define the 'Node' class used to form the linked list.

        class Node
        {
            public Node? Next { get;         set; }
            public TData Data { get; private set; }

            public Node( TData newData )
            {
                Next = null;
                Data = newData;
            }
        }

        // Define the properties (fields) and constructor for the linked list.

        Node? Tail { get; set; }
        Node? Head { get; set; }
        public int Count { get; private set; }

        public LinkedList( )
        {
            Tail = null;
            Head = null;
            Count = 0;
        }
    }
}
