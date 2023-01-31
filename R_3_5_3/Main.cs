﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_3_5_3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // Сама вкладка - лента
            string tabName = "RevitAPI";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITrainig\";

            // Панель - часть вкладки-ленты
            var panel = application.CreateRibbonPanel(tabName, "Трубы и стены");

            // кнопка приложения
            var button = new PushButtonData("Типы", "Типы стен", Path.Combine(utilsFolderPath, "R_3_5_1.dll"), "R_3_5_1.Main");
            panel.AddItem(button);
            return Result.Succeeded;
        }
    }
}
