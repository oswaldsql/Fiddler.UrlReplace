namespace UrlReplace
{
    partial class EditUrlReplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkIsRegEx = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeek = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.chkHostrOnly = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbxIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkIsRegEx
            // 
            this.chkIsRegEx.AutoSize = true;
            this.chkIsRegEx.Location = new System.Drawing.Point(97, 35);
            this.chkIsRegEx.Name = "chkIsRegEx";
            this.chkIsRegEx.Size = new System.Drawing.Size(128, 17);
            this.chkIsRegEx.TabIndex = 1;
            this.chkIsRegEx.Text = "Is Regular &Expression";
            this.toolTip.SetToolTip(this.chkIsRegEx, "Sets if the search and replace should be done using regular expressions");
            this.chkIsRegEx.UseVisualStyleBackColor = true;
            this.chkIsRegEx.Leave += new System.EventHandler(this.ValidateRegEx);
            this.chkIsRegEx.CheckedChanged += new System.EventHandler(this.ChkIsRegExCheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "&Seek :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Replace :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSeek
            // 
            this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeek.Location = new System.Drawing.Point(97, 104);
            this.txtSeek.Name = "txtSeek";
            this.txtSeek.Size = new System.Drawing.Size(298, 20);
            this.txtSeek.TabIndex = 5;
            this.txtSeek.Leave += new System.EventHandler(this.ValidateRegEx);
            // 
            // txtReplace
            // 
            this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplace.Location = new System.Drawing.Point(97, 131);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(298, 20);
            this.txtReplace.TabIndex = 7;
            this.txtReplace.Leave += new System.EventHandler(this.ValidateRegEx);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Group :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.Location = new System.Drawing.Point(97, 157);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(298, 20);
            this.txtGroup.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "&Comment :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(97, 183);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(298, 20);
            this.txtComment.TabIndex = 11;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(97, 12);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(67, 17);
            this.chkActive.TabIndex = 0;
            this.chkActive.Text = "Is &Active";
            this.toolTip.SetToolTip(this.chkActive, "Sets if the replace should be checked");
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(319, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(238, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(97, 57);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(82, 17);
            this.chkIgnoreCase.TabIndex = 2;
            this.chkIgnoreCase.Text = "&Ignore case";
            this.toolTip.SetToolTip(this.chkIgnoreCase, "Set if the search should be done case insensitive");
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // chkHostrOnly
            // 
            this.chkHostrOnly.AutoSize = true;
            this.chkHostrOnly.Location = new System.Drawing.Point(97, 80);
            this.chkHostrOnly.Name = "chkHostrOnly";
            this.chkHostrOnly.Size = new System.Drawing.Size(70, 17);
            this.chkHostrOnly.TabIndex = 3;
            this.chkHostrOnly.Text = "&Host only";
            this.toolTip.SetToolTip(this.chkHostrOnly, "Sets if the search and replace should be done only in the domain part of the url");
            this.chkHostrOnly.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTipPopup);
            // 
            // cbxIndex
            // 
            this.cbxIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxIndex.DisplayMember = "Key";
            this.cbxIndex.FormattingEnabled = true;
            this.cbxIndex.Location = new System.Drawing.Point(97, 209);
            this.cbxIndex.Name = "cbxIndex";
            this.cbxIndex.Size = new System.Drawing.Size(297, 21);
            this.cbxIndex.TabIndex = 13;
            this.cbxIndex.ValueMember = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Execution &order :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EditUrlReplace
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(409, 270);
            this.Controls.Add(this.cbxIndex);
            this.Controls.Add(this.chkHostrOnly);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.chkIgnoreCase);
            this.Controls.Add(this.chkIsRegEx);
            this.MaximumSize = new System.Drawing.Size(1024, 306);
            this.MinimumSize = new System.Drawing.Size(306, 306);
            this.Name = "EditUrlReplace";
            this.Text = "Edit UrlReplace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsRegEx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeek;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.CheckBox chkHostrOnly;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cbxIndex;
        private System.Windows.Forms.Label label5;
    }
}