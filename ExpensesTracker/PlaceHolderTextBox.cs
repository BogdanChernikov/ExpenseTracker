using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpensesTracker
{
    /// <summary>
    /// Initializes a new instance of the System.Windows.Forms.PlaceHolderTextBox class
    /// Is a text box with a function "placeholder".
    /// </summary>
    internal sealed class PlaceHolderTextBox : TextBox
    {
        private string _placeHolderText;
        private Color _placeHolderTextColor;
        private Color _foreColor;
        private bool _isPlaceHolder;
        public bool IsPlaceHolderActive => _isPlaceHolder;

        /// <summary>
        /// For correct work it is necessary to call a method and to transfer to it parameters after loading of all basic parameters.
        /// </summary>
        /// <param name="placeHolderText"></param>
        /// <param name="placeHolderTextColor"></param>
        public void SetupPlaceHolder(string placeHolderText, Color placeHolderTextColor)
        {
            _placeHolderText = placeHolderText;
            _placeHolderTextColor = placeHolderTextColor;
            _foreColor = ForeColor;

            Enter += EnterPlaceHolder;
            Leave += ExitPlaceHolder;

            ExitPlaceHolder();
        }

        private void EnterPlaceHolder()
        {
            if (_isPlaceHolder)
            {
                _isPlaceHolder = false;
                Text = string.Empty;
                ForeColor = _foreColor;
            }
        }

        private void ExitPlaceHolder()
        {
            if (string.IsNullOrEmpty(Text))
            {
                _isPlaceHolder = true;
                Text = _placeHolderText;
                ForeColor = _placeHolderTextColor;
            }
        }

        private void EnterPlaceHolder(object sender, EventArgs e)
        {
            EnterPlaceHolder();
        }

        private void ExitPlaceHolder(object sender, EventArgs e)
        {
            ExitPlaceHolder();
        }
    }
}
