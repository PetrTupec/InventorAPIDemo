using System;

namespace InventorAPIDemoApp.UserInterface
{
    public class UI
    {
        public void Welcome() => Console.WriteLine("Welcome to the Inventor API example application. \n\n" +
            "Trying to start Autodesk Inventor...");
        public void WriteMessage(string message) => Console.WriteLine(message);

        public void WriteInventorReady() => PositiveMessage("Autodesk Inventor is ready.\n");
        public void WriteClosingInventor() => Console.WriteLine("Closing Autodesk Inventor...");

        public void WriteInventorClose() => PositiveMessage("Autodesk Invenotr was closed.\n");
        public void WriteOpening() => Console.WriteLine("\nOpening document...");
        public void WriteDocumentOpen() => PositiveMessage("Document is open.\n");
        public void WriteReadingDone() => PositiveMessage("Document reading done\n");
        public void WriteReadDocument() => Console.WriteLine("Reading data from document...");
        public string GetFilePath()
        {
            Console.WriteLine("Please enter the full path to an IPT or IAM file:");
            return Console.ReadLine()?.Trim();
        }
        public void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        private void PositiveMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Success: {message}");
            Console.ResetColor();
        }
    }
}
