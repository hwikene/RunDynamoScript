# 🚀 RunDynamoScript - Revit Add-in for Automating Dynamo Script Execution

## 📖 Description  
RunDynamoScript is a **Revit add-in** designed to automate the execution of a predefined **Dynamo script**. This tool allows users to run Dynamo scripts directly from Revit with a **single button click**, eliminating the need to manually open Dynamo.

The add-in is structured to:  
- ✅ Execute a specified **Dynamo (.dyn) script** automatically without requiring manual input.  
- ✅ Run in **automation mode**, ensuring efficient and consistent execution.  
- ✅ Provide a **Revit Ribbon button** for easy access to the script execution.  

This add-in is particularly useful for **Revit users** who need to streamline **repetitive Dynamo workflows**, improving efficiency and accuracy.

---

## 🔥 Features  
✔ **Automated Execution** – Runs a Dynamo script seamlessly in the background.  
✔ **No UI Interruptions** – Ensures a smooth Revit workflow by suppressing Dynamo’s interface.  
✔ **Integrated in Revit Ribbon** – Adds a dedicated button in the Revit UI for quick execution.  
✔ **Supports Large-Scale Projects** – Ideal for automating complex workflows.  

---

## 🛠 Installation & Setup  

### **1️⃣ Download and Extract**  
Download the latest release from **[GitHub Releases](https://github.com/hwikene/RunDynamoScript/releases)**.  

### **2️⃣ Required Dependencies**  
This add-in relies on **Dynamo for Revit libraries**. Ensure you have the necessary **.dll** files installed.  
You can download them from the **official NuGet package**:  

🔗 **[DynamoVisualProgramming.Revit NuGet Package](https://www.nuget.org/packages/DynamoVisualProgramming.Revit)**  

This package includes:
- `RevitNodes.dll`
- `RevitServices.dll`
- `DynamoRevitDS.dll`
- `DSRevitNodesUI.dll`

These files are required for Dynamo to interact with Revit properly.

### **3️⃣ Copy Files**  
Copy the required files (`.dll` and `.addin`) into:  
