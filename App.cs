using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace YourNamespace
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "YourTabNameHere"; // Set the name of the tab in the Revit ribbon

            // Attempt to create a new tab in the Revit ribbon
            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                // If the tab already exists, do nothing
            }

            // Create a new section in the tab for your tools
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "YourPanelNameHere");

            // Define a new button to execute the Dynamo script
            PushButtonData buttonData = new PushButtonData(
                "YourButtonNameHere", // Unique identifier for the button
                "YourButtonLabelHere", // Text displayed on the button
                Assembly.GetExecutingAssembly().Location,
                "YourNamespace.YourCommandHere"); // Full namespace and class of the command

            // Add the button to the Ribbon Panel
            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            // Set the icon and tooltip for the button
            pushButton.LargeImage = PngImageSource("Resources/YourIconHere.png"); // Path to your image resource
            pushButton.ToolTip = "YourTooltipHere: \n\n" +
                                 "- Description of feature 1.\n" +
                                 "- Description of feature 2.\n" +
                                 "- Description of feature 3.\n" +
                                 "- Description of feature 4.";

            // Add a help page link if needed
            ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "YourHelpFilePathHere"); // Set the URL or file path to documentation
            pushButton.SetContextualHelp(help);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // No special actions required on shutdown
            return Result.Succeeded;
        }

        private BitmapImage PngImageSource(string embeddedPath)
        {
            // Helper method to load an image for the button
            try
            {
                Uri uri = new Uri($"pack://application:,,,/YourAssemblyName;component/{embeddedPath}", UriKind.Absolute);
                return new BitmapImage(uri);
            }
            catch
            {
                // Return null if the image cannot be loaded
                return null;
            }
        }
    }
}
