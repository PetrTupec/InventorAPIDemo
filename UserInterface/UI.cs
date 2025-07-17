namespace InventorAPIDemoApp.UserInterface
{
    public class UI
    {
        public void Welcome() => Console.WriteLine("Welcome to the Inventor API example application. \n\n" +
            "Trying to start Autodesk Inventor...");
        public void WriteInventorReady() => PositiveMessage("Autodesk Inventor is ready.\n");
        
        public void WriteClosingInventor() => Console.WriteLine("\nClosing Autodesk Inventor...");
        public void WriteInventorClose() => PositiveMessage("Autodesk Inventor was closed.\n");
        
        public void WriteOpening() => Console.WriteLine("\nOpening document...");
        public void WriteDocumentOpen() => PositiveMessage("Document is open.");
        
        public void WriteReadingDocument() => Console.WriteLine("\nReading data from document...");
        public void WriteReadingDone() => PositiveMessage("Document reading done.\n");

        public void WriteExportingData(string extention) => Console.WriteLine($"\nExporting data to {extention.ToUpper()} file...");

        public void WriteExportDone(string path) => PositiveMessage($"Exported file is save to {path}");

        public void WriteMessage(string message) => Console.WriteLine(message);


        public bool WantUserContinue()
        {
            return ReadConsole("Do you want to export the data? Type 'yes' to continue, or anything else to exit.")
                .Equals("yes");
        }
        public string GetFilePath()
        {
            return ReadConsole("Please enter the full path to an IPT or IAM file:");
        }

        public string GetPreferFormat() {
            return ReadConsole("Please choose output data format. JSON or CSV.");
        }

        private string ReadConsole(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine()?.Trim().ToLower();
        }

        private void PositiveMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Success: {message}");
            Console.ResetColor();
        }
        public void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }
    }
}
