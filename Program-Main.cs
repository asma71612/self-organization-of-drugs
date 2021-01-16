#nullable enable
using System;
using static System.Console;
using MediCal;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            // Initialize a list of 'Drug' objects from a file.
            
            LinkedList< Drug > drugList = new LinkedList< Drug >( );
            foreach( Drug d in Drug.ArrayFromFile( "RXQT1503-10.txt" ) ) drugList.AddLast( d );
            
            // Display the list of 'Drug' objects in the order they appear on the list.
            
            WriteLine( );
            WriteLine( "drugList as read from the file" );
            foreach( Drug d in drugList ) WriteLine( d );
            WriteLine( );
            
            // Search for a 'Drug' object by the start of the drug name.
            // Redisplay the list of 'Drug' objects in the order they appear on the list.
           
            Write( "Enter the start of a drug name to find: " );
            string start = ReadLine( )!;
            
            Write( "Enter the self-organizing move [None, Back, Head]: " );
            SelfOrgMove selfOrgMove = ( SelfOrgMove )Enum.Parse( typeof( SelfOrgMove ), 
                ReadLine( )!, ignoreCase: true );
            
            bool DrugNameMatch( Drug d ) 
                { return d.Name.StartsWith( start, StringComparison.OrdinalIgnoreCase ); }
            
            bool found = drugList.Contains( DrugNameMatch, selfOrgMove );
            WriteLine( );
            WriteLine( "Drug name starting with \"{0}\" found: {1}", start, found );
            WriteLine( );
            WriteLine( "drugList after self-organizing move" );
            foreach( Drug d in drugList ) WriteLine( d );
            WriteLine( );
        }
    }
}
