/*

   Copyright 2019 Esri

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

   See the License for the specific language governing permissions and
   limitations under the License.

*/
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

namespace GraphicsLayerToolControl
{
  /// <summary>
  /// ToolControl implementation
  /// </summary>
  [Guid("f6d7f99f-2a94-472c-9981-b7d7d6edc518")]
  [ClassInterface(ClassInterfaceType.None)]
  [ProgId("GraphicsLayerToolControl.GraphicsLayersListToolCtrl")]
  public sealed class GraphicsLayersListToolCtrl : BaseCommand, IToolControl
  {
    #region COM Registration Function(s)
    [ComRegisterFunction()]
    [ComVisible(false)]
    static void RegisterFunction(Type registerType)
    {
      // Required for ArcGIS Component Category Registrar support
      ArcGISCategoryRegistration(registerType);

      //
      // TODO: Add any COM registration code here
      //
    }

    [ComUnregisterFunction()]
    [ComVisible(false)]
    static void UnregisterFunction(Type registerType)
    {
      // Required for ArcGIS Component Category Registrar support
      ArcGISCategoryUnregistration(registerType);

      //
      // TODO: Add any COM unregistration code here
      //
    }

    #region ArcGIS Component Category Registrar generated code
    /// <summary>
    /// Required method for ArcGIS Component Category registration -
    /// Do not modify the contents of this method with the code editor.
    /// </summary>
    private static void ArcGISCategoryRegistration(Type registerType)
    {
      string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
      ControlsCommands.Register(regKey);
      MxCommands.Register(regKey);

    }
    /// <summary>
    /// Required method for ArcGIS Component Category unregistration -
    /// Do not modify the contents of this method with the code editor.
    /// </summary>
    private static void ArcGISCategoryUnregistration(Type registerType)
    {
      string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
      ControlsCommands.Unregister(regKey);
      MxCommands.Unregister(regKey);

    }

    #endregion
    #endregion

    #region class members
    private IHookHelper m_hookHelper = null;
    private GraphicsLayersListCtrl m_graphicsLayerListCtrl = null;
    #endregion

    #region constructor
    public GraphicsLayersListToolCtrl()
    {
      base.m_category = ".NET Samples";
      base.m_caption = "Graphics Layers";
      base.m_message = "Active Graphics Layer";
      base.m_toolTip = "Active Graphics Layer";
      base.m_name = "ToolControlSample_GraphicsLayersListToolCtrl";

      try
      {
        string bitmapResourceName = GetType().Name + ".bmp";
        base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
      }
    }
    #endregion

    #region Overriden Class Methods

    /// <summary>
    /// Occurs when this command is created
    /// </summary>
    /// <param name="hook">Instance of the application</param>
    public override void OnCreate(object hook)
    {
      if (hook == null)
        return;

      if (m_hookHelper == null)
        m_hookHelper = new HookHelperClass();

      m_hookHelper.Hook = hook;

      //make sure that the usercontrol has been initialized
      if (null == m_graphicsLayerListCtrl)
      {
        m_graphicsLayerListCtrl = new GraphicsLayersListCtrl();
        m_graphicsLayerListCtrl.CreateControl();
      }
      //set the Map property of the control
      m_graphicsLayerListCtrl.Map = m_hookHelper.FocusMap;
    }

    /// <summary>
    /// Occurs when this command is clicked
    /// </summary>
    public override void OnClick()
    {
      //not much to do here
    }

    #endregion

    #region IToolControl Members

    public bool OnDrop(esriCmdBarType barType)
    {
      return true;
    }

    public void OnFocus(ICompletionNotify complete)
    {

    }

    public int hWnd
    {
      get
      {
        //pass the handle of the usercontrol
        if (null == m_graphicsLayerListCtrl)
        {
          m_graphicsLayerListCtrl = new GraphicsLayersListCtrl();
          m_graphicsLayerListCtrl.CreateControl();
        }

        return m_graphicsLayerListCtrl.Handle.ToInt32();

      }
    }

    #endregion
  }
}
