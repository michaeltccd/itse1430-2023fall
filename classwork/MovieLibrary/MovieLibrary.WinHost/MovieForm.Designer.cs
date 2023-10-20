namespace MovieLibrary.WinHost
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this._txtTitle = new System.Windows.Forms.TextBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._cbRating = new System.Windows.Forms.ComboBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtReleaseYear = new System.Windows.Forms.TextBox();
            this._txtGenre = new System.Windows.Forms.TextBox();
            this._chkIsBlackAndWhite = new System.Windows.Forms.CheckBox();
            this._txtRunLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtTitle
            // 
            this._txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTitle.Location = new System.Drawing.Point(89, 28);
            this._txtTitle.Name = "_txtTitle";
            this._txtTitle.Size = new System.Drawing.Size(327, 23);
            this._txtTitle.TabIndex = 0;
            this._txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateTitle);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnSave.Location = new System.Drawing.Point(284, 323);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 7;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.CausesValidation = false;
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(365, 323);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 8;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // _cbRating
            // 
            this._cbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbRating.FormattingEnabled = true;
            this._cbRating.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R"});
            this._cbRating.Location = new System.Drawing.Point(89, 65);
            this._cbRating.Name = "_cbRating";
            this._cbRating.Size = new System.Drawing.Size(87, 23);
            this._cbRating.TabIndex = 1;
            this._cbRating.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRating);
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(89, 256);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(327, 37);
            this._txtDescription.TabIndex = 6;
            // 
            // _txtReleaseYear
            // 
            this._txtReleaseYear.Location = new System.Drawing.Point(89, 103);
            this._txtReleaseYear.Name = "_txtReleaseYear";
            this._txtReleaseYear.Size = new System.Drawing.Size(87, 23);
            this._txtReleaseYear.TabIndex = 2;
            this._txtReleaseYear.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateReleaseYear);
            // 
            // _txtGenre
            // 
            this._txtGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtGenre.Location = new System.Drawing.Point(89, 144);
            this._txtGenre.Name = "_txtGenre";
            this._txtGenre.Size = new System.Drawing.Size(127, 23);
            this._txtGenre.TabIndex = 3;
            // 
            // _chkIsBlackAndWhite
            // 
            this._chkIsBlackAndWhite.AutoSize = true;
            this._chkIsBlackAndWhite.Location = new System.Drawing.Point(89, 180);
            this._chkIsBlackAndWhite.Name = "_chkIsBlackAndWhite";
            this._chkIsBlackAndWhite.Size = new System.Drawing.Size(127, 19);
            this._chkIsBlackAndWhite.TabIndex = 4;
            this._chkIsBlackAndWhite.Text = "Is Black and White?";
            this._chkIsBlackAndWhite.UseVisualStyleBackColor = true;
            // 
            // _txtRunLength
            // 
            this._txtRunLength.Location = new System.Drawing.Point(89, 215);
            this._txtRunLength.Name = "_txtRunLength";
            this._txtRunLength.Size = new System.Drawing.Size(87, 23);
            this._txtRunLength.TabIndex = 5;
            this._txtRunLength.Text = "0";
            this._txtRunLength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRunLength);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rating";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Release Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Genre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Run Length";
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // MovieForm
            // 
            this.AcceptButton = this._btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(459, 361);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtRunLength);
            this.Controls.Add(this._chkIsBlackAndWhite);
            this.Controls.Add(this._txtGenre);
            this.Controls.Add(this._txtReleaseYear);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._cbRating);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtTitle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 400);
            this.Name = "MovieForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Movie";
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox _txtTitle;
        private Button _btnSave;
        private Button _btnCancel;
        private ComboBox _cbRating;
        private TextBox _txtDescription;
        private TextBox _txtReleaseYear;
        private TextBox _txtGenre;
        private CheckBox _chkIsBlackAndWhite;
        private TextBox _txtRunLength;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ErrorProvider _errors;
    }
}