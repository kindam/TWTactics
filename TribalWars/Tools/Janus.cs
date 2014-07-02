﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Janus.Windows.UI.CommandBars;
using CommandType = System.Data.CommandType;

namespace TribalWars.Tools
{
    /// <summary>
    /// WinForms extensions for Janus controls
    /// </summary>
    public static class Janus
    {
        #region GridEX
        public static DataRow GetDataRow(this GridEXRow row)
        {
            return ((DataRowView)row.DataRow).Row;
        }
        #endregion

        #region UIContextMenu
        public static void AddSeparator(this UIContextMenu menu)
        {
            var sep = new UICommand("SEP", string.Empty, global::Janus.Windows.UI.CommandBars.CommandType.Separator);
            menu.Commands.Add(sep);
        }

        public static UICommand AddCommand(this UIContextMenu menu, string text, CommandEventHandler handler, Icon icon)
        {
            return AddCommand(menu, text, handler, null, icon);
        }

        public static UICommand AddCommand(this UIContextMenu menu, string text, CommandEventHandler handler = null, Shortcut? shortcut = null, Icon icon = null)
        {
            var cmd = new UICommand("", text, global::Janus.Windows.UI.CommandBars.CommandType.Command);
            cmd.Click += handler;
            if (shortcut.HasValue)
            {
                cmd.Shortcut = shortcut.Value;
            }
            cmd.Icon = icon;

            menu.Commands.Add(cmd);

            return cmd;
        }

        public static void AddTextBoxCommand(this UIContextMenu menu, string text, string defaultTextBoxValue, EventHandler handler)
        {
            var txtBox = new TextBox();
            txtBox.Text = defaultTextBoxValue;
            txtBox.TextChanged += handler;

            var cmd = new UICommand("", text, global::Janus.Windows.UI.CommandBars.CommandType.TextBoxCommand);
            cmd.Control = txtBox;
            menu.Commands.Add(cmd);
        }
        #endregion
    }
}
