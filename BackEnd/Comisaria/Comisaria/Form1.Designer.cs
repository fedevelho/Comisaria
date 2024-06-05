namespace Comisaria
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webViewInicio = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewInicio).BeginInit();
            SuspendLayout();
            // 
            // webViewInicio
            // 
            webViewInicio.AllowExternalDrop = true;
            webViewInicio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webViewInicio.CreationProperties = null;
            webViewInicio.DefaultBackgroundColor = Color.White;
            webViewInicio.Location = new Point(3, -1);
            webViewInicio.Name = "webViewInicio";
            webViewInicio.Size = new Size(1282, 695);
            webViewInicio.TabIndex = 0;
            webViewInicio.ZoomFactor = 1D;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1283, 694);
            Controls.Add(webViewInicio);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)webViewInicio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewInicio;
    }
}
