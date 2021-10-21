/*
 *  File Name:   Program.cs
 *
 *  Copyright (c) 2021 Bradley Willcott
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ****************************************************************
 * Name: Bradley Willcott
 * ID:   M198449
 * Date: 21/10/2021
 * ****************************************************************
 */

namespace ConsoleApp
{
    using System;

    /// <summary>
    /// This is a console application that displays the keys that the user presses.
    /// Further, it monitors the Ctl-C/Break key sequence, and runs an event handler
    /// to intercept this.
    ///
    /// To terminate the while loop, press 'X'.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This is the work-horse method.
        /// </summary>
        public static void Main()
        {
            ConsoleKeyInfo cki;

            Console.Clear();

            // Establish an event handler to process key press events.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(MyHandler);

            while (true)
            {
                Console.Write("Press any key, or 'X' to quit, or ");
                Console.WriteLine("CTRL+C to interrupt the read operation:");

                // Start a console read operation. Do not display the input.
                cki = Console.ReadKey(true);

                // Announce the name of the key that was pressed .
                Console.WriteLine($"  Key pressed: {cki.Key}\n");

                // Exit if the user pressed the 'X' key.
                if (cki.Key == ConsoleKey.X) break;
            }
        }

        /// <summary>
        /// This handler is called when the user presses Ctl-C/Break.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="args">The args <see cref="ConsoleCancelEventArgs"/>.</param>
        private static void MyHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("\nThe read operation has been interrupted.");

            Console.WriteLine($"  Key pressed: {args.SpecialKey}");

            Console.WriteLine($"  Cancel property: {args.Cancel}");

            // Set the Cancel property to true to prevent the process from terminating.
            Console.WriteLine("Setting the Cancel property to true...");
            args.Cancel = true;

            // Announce the new value of the Cancel property.
            Console.WriteLine($"  Cancel property: {args.Cancel}");
            Console.WriteLine("The read operation will resume...\n");
        }
    }
}