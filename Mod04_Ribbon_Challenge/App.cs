#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Markup;

#endregion

namespace Mod04_Ribbon_Challenge
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            // Create ribbon tab
            string tabName = "Revit Add-in Bootcamp";
            try
            {
                app.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists.");
            }

            // Create ribbon panel 
            RibbonPanel panel = Utils.CreateRibbonPanel(app, tabName, "Revit Tools");


            // Create button data instances
            ButtonDataClass myButtonData1 = new ButtonDataClass("Tool1", "Tool 1", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 1");
            ButtonDataClass myButtonData2 = new ButtonDataClass("Tool2", "Tool 2", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 2");
            ButtonDataClass myButtonData3 = new ButtonDataClass("Tool3", "Tool 3", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Green_32, Properties.Resources.Green_16, "Tooltip 3");
            ButtonDataClass myButtonData4 = new ButtonDataClass("Tool4", "Tool 4", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 4");
            ButtonDataClass myButtonData5 = new ButtonDataClass("Tool5", "Tool 5", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 5");
            ButtonDataClass myButtonData6 = new ButtonDataClass("Tool6", "Tool 6", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Red_32, Properties.Resources.Red_16, "Tooltip 6");
            ButtonDataClass myButtonData7 = new ButtonDataClass("Tool7", "Tool 7", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Green_32, Properties.Resources.Green_16, "Tooltip 7");
            ButtonDataClass myButtonData8 = new ButtonDataClass("Tool8", "Tool 8", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Yellow_32, Properties.Resources.Yellow_16, "Tooltip 8");
            ButtonDataClass myButtonData9 = new ButtonDataClass("Tool9", "Tool 9", MethodBase.GetCurrentMethod().DeclaringType?.FullName, Properties.Resources.Blue_32, Properties.Resources.Blue_16, "Tooltip 9");

            // Create buttons
            PushButton myButton1 = panel.AddItem(myButtonData1.Data) as PushButton;
            PushButton myButton2 = panel.AddItem(myButtonData2.Data) as PushButton;

            // Create stacked buttons
            panel.AddStackedItems(myButtonData3.Data, myButtonData4.Data, myButtonData5.Data);

            // Create split button
            SplitButtonData splitButtonData = new SplitButtonData("Split1", "Split\rButton");
            SplitButton splitButton = panel.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(myButtonData6.Data);
            splitButton.AddPushButton(myButtonData7.Data);

            // Create a pulldown button
            PulldownButtonData pulldownData = new PulldownButtonData("More Tools", "More\rTools");
            pulldownData.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_32);
            pulldownData.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_16);

            PulldownButton pullDownButton = panel.AddItem(pulldownData) as PulldownButton;
            pullDownButton.AddPushButton(myButtonData8.Data);
            pullDownButton.AddPushButton(myButtonData9.Data);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }


    }
}
