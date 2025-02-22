using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Dynamo.Applications.Models; // Ensure this is the correct namespace for your version
using System;
using System.Collections.Generic;
using System.Windows.Forms; // For UI components
using Dynamo.Applications;
using Autodesk.Revit.Attributes;

namespace YourNamespace
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RunDynamoScript : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Get application and document objects and start transaction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            // Define the path to the Dynamo script (update this in configuration)
            string dynamoScriptPath = "YourDynamoScriptPathHere";
            DynamoRevit dynamoRevit = new DynamoRevit();

            DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();
            dynamoRevitCommandData.Application = commandData.Application;
            IDictionary<string, string> journalData = new Dictionary<string, string>
            {
                { Dynamo.Applications.JournalKeys.ShowUiKey, false.ToString() }, // Hide Dynamo UI at runtime
                { Dynamo.Applications.JournalKeys.AutomationModeKey, true.ToString() }, // Run in automation mode
                { Dynamo.Applications.JournalKeys.DynPathKey, dynamoScriptPath }, // Set path to Dynamo script
                { Dynamo.Applications.JournalKeys.DynPathExecuteKey, true.ToString() }, // Execute the script
                { Dynamo.Applications.JournalKeys.ForceManualRunKey, false.ToString() }, // Do not force manual run mode
                { Dynamo.Applications.JournalKeys.ModelShutDownKey, true.ToString() }, // Shut down model after execution
                { Dynamo.Applications.JournalKeys.ModelNodesInfo, false.ToString() } // Disable node information logging
            };

            dynamoRevitCommandData.JournalData = journalData;
            Result externalCommandResult = dynamoRevit.ExecuteCommand(dynamoRevitCommandData);
            return externalCommandResult;
        }
    }
}
