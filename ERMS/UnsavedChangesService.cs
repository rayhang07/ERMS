using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMS
{
    public static class UnsavedChangesService
    {
        public static bool HasUnsavedChanges(Control control)
        {
            // Checks every control in the Child Form
            foreach (Control c in control.Controls)
            {
                // Checks for textboxes
                if (c is TextBox textBox)
                {
                    // Ignore empty textboxes
                    if (textBox.Enabled &&!string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return true;
                    }
                }

                else if (c.HasChildren)
                {
                    // Recursively call the function on the child controls
                    if (HasUnsavedChanges(c))
                        return true;
                }
            }
            return false;
        }



        public static bool HasUnsavedChanges(Form form)
        {
            

            return HasUnsavedChanges((Control)form);
        }

        public static bool ConfirmCloseIfUnsaved(Form form)
        {
            // If form has unsaved changes
            if (HasUnsavedChanges(form))
            {
                // Present the alert message
                Sound.PlayError();
                var result = MessageBox.Show(
                    "You have unsaved changes. Do you want to close without saving?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question

                );

                return result == DialogResult.Yes;
            }
            return true;

        }

    }
}
